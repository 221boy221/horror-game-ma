using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {

    private SliderScript newspaperSlide;
    private SliderScript noteSlide;
    private SliderScript boxNoteSlide;
    private SliderScript ventNoteSlide;
    private SliderScript photoBoy;
    private SliderScript photoCerys;
    private SliderScript photoSusan;
    private SwitchSprite photoBoyScratched;
    private SwitchSprite photoCerysScratched;
    private SwitchSprite photoSusanScratched;
    //private SwitchSprite gameBG;
    private SwitchSprite boxFall;
    private GameObject tlLight;
    private GameObject lpLight;
    private GameObject creepWindow;
    private GameObject creepVent;
    private GameObject creepEndGame;
    private Animator laptop;
    private Animator boxAnim;
    private bool tlLightActive = true;
    private bool lpLightActive = false;
    private float randomizer;
    private float creepWindowNum;

    private AudioSource source;
    public AudioClip pageFlipAudio;
    public AudioClip lichtFlipAudio;
    public AudioClip boxOpeningAudio;

    private void Start() {
        source = GetComponent<AudioSource>();
        if (Application.loadedLevelName == "GameScene") {
            newspaperSlide  = GameObject.FindGameObjectWithTag("NewspaperSlide").GetComponent<SliderScript>();
            noteSlide       = GameObject.FindGameObjectWithTag("NoteSlide").GetComponent<SliderScript>();
            photoBoy        = GameObject.FindGameObjectWithTag("PhotoBoySlide").GetComponent<SliderScript>();
            photoCerys      = GameObject.FindGameObjectWithTag("PhotoCerysSlide").GetComponent<SliderScript>();
            photoSusan      = GameObject.FindGameObjectWithTag("PhotoSusanSlide").GetComponent<SliderScript>();
            photoBoyScratched   = GameObject.FindGameObjectWithTag("PhotoBoySlide").GetComponent<SwitchSprite>();
            photoCerysScratched = GameObject.FindGameObjectWithTag("PhotoCerysSlide").GetComponent<SwitchSprite>();
            photoSusanScratched = GameObject.FindGameObjectWithTag("PhotoSusanSlide").GetComponent<SwitchSprite>();
            //gameBG        = GameObject.FindGameObjectWithTag("GameBG").GetComponent<SwitchSprite>();
            boxFall         = GameObject.FindGameObjectWithTag("BoxFall").GetComponent<SwitchSprite>();
            laptop          = GameObject.FindGameObjectWithTag("LaptopStatic").GetComponent<Animator>();
            tlLight         = GameObject.FindGameObjectWithTag("TL Light");
            lpLight         = GameObject.FindGameObjectWithTag("LaptopLight");
            creepWindow     = GameObject.FindGameObjectWithTag("CreepWindow");
            creepEndGame    = GameObject.FindGameObjectWithTag("CreepEndGame");
            creepEndGame.SetActive(false);
            creepWindow.SetActive(false);
            lpLight.SetActive(lpLightActive);
            if (GameManager.laptopOff) laptop.Play("laptopOff");
            if (GameManager.stage == 6) {
                photoBoyScratched.NewSprite(3);
                photoCerysScratched.NewSprite(3);
                photoSusanScratched.NewSprite(3);
                //gameBG.NewSprite(4);
            }

        } else if (Application.loadedLevelName == "InsideBox") {
            boxNoteSlide    = GameObject.FindGameObjectWithTag("BoxNoteSlide").GetComponent<SliderScript>();
            boxAnim         = GameObject.FindGameObjectWithTag("BoxAnim").GetComponent<Animator>();
            CheckBoxAnim();
        } else if (Application.loadedLevelName == "InsideVent") {
            ventNoteSlide   = GameObject.FindGameObjectWithTag("VentNoteSlide").GetComponent<SliderScript>();
            creepVent       = GameObject.FindGameObjectWithTag("CreepVent");
            creepVent.SetActive(false);
        }
    }


    /*          All events will be in here           */


    // BOX
    public void BoxFall() {
        if (GameManager.popup) {
            Debug.Log("BoxFall();");
            GameManager.boxSwitch = true;
            boxFall.NewSprite(1);
            // TODO: boxFall sfx
            GameManager.boxClickable = true;
        }
    }

    public void BoxScene() {
        GameManager.scene = 2;
        Application.LoadLevel("InsideBox");
    }

    private void CheckBoxAnim() {
        if (GameManager.boxOpened) {
            boxAnim.Play("boxOpened");
        } else {
            boxAnim.Play("boxClosed");
            Invoke("BoxOpening", GameManager.boxOpenDelay);
        }
    }

    public void BoxOpening() {
        boxAnim.Play("boxOpening");
        //boxOpening sfx well (actually its the door open sfx)
        source.PlayOneShot(boxOpeningAudio, 1f);
        GameManager.boxOpened = true;
    }



    // LAPTOP
    public void LaptopStatic() {
        if (laptop && !GameManager.laptopStatic) { // Extra protection to avoid bugs
            // So that it won't be trigger-able again
            GameManager.laptopStatic = true;
            GameManager.boxClickable = false;
            laptop.Play("laptopStatic");
            // TODO: play static sfx
            Invoke("LaptopOff", 10);
        }
    }

    private void LaptopOff() {
        laptop.Play("laptopOff");
        lpLight.SetActive(false);
        GameManager.laptopOff = true;
        LightFlicker();
    }



    // LIGHTS
    public void LightSwitch() {
        if (!GameManager.lightsOff) {
            Debug.Log("On / Off");
            tlLightActive = tlLightActive ? false : true;
            tlLight.SetActive(tlLightActive);
            if (GameManager.stage < 3) {
                lpLightActive = lpLightActive ? false : true;
                lpLight.SetActive(lpLightActive);
            }
            //light switch sfx
            source.PlayOneShot(lichtFlipAudio, 1f);
        } else if (GameManager.stage == 3) {
            Debug.Log("LightSwitch(); can't click-> LightFlicker in 10 secs");
            tlLight.SetActive(false);
            lpLight.SetActive(false);
            // TODO: lights crash? sfx
            Invoke("LightFlicker", 5);

            PhotosScratched();
            GameManager.stage = 4;
        }

    }

    public void LightFlicker() {
        Debug.Log("LightFlicker();");

        GameManager.boxClickable = false;
        GameManager.lightsOff = true;
        if (GameManager.lightsOff) {
            StartCoroutine("LightFlick", 1);
        }

        Invoke("ResetLights", 10);
    }

    public IEnumerator LightFlick() {
        Debug.Log("LightFlick();");

        while (GameManager.lightsOff && GameManager.scene == 1) {
            randomizer = Random.Range(0.2f, 0.5f);
            yield return new WaitForSeconds(randomizer);
            tlLightActive = tlLightActive ? false : true;
            tlLight.SetActive(tlLightActive);
            if (tlLightActive) {
                // TODO: lights on sfx
            } else {
                // TODO: lights off sfx
            }
            StartCoroutine("LightFlick", randomizer);

            // Creep window for stage 4
            yield return new WaitForSeconds(5);
            // TODO: Creep jumpscare sfx
            if (GameManager.stage == 4 && creepWindowNum < 10) {
                creepWindow.SetActive(!tlLightActive);
                creepWindowNum++;
            } else {
                creepWindow.SetActive(false);
            }
            break;
        }
    }

    private void ResetLights() {
        // Temp light 'reset' function
        Debug.Log("ResetLights();");
        if (GameManager.stage == 2) GameManager.stage = 3;
        creepWindow.SetActive(false);
        tlLight.SetActive(true);
        // TODO: lights on sfx
        GameManager.lightsOff = false;
        GameManager.boxClickable = true;
    }



    // PHOTOS
    public void PhotosScratched() {
        Debug.Log("switch photos");
        GameManager.photoSwitch = true;
        photoBoyScratched.NewSprite(2);
        photoCerysScratched.NewSprite(2);
        photoSusanScratched.NewSprite(2);
    }



    // VENT
    public void VentScene() {
        GameManager.scene = 3;
        Application.LoadLevel("InsideVent");
        Debug.Log("inside vent");
        GameManager.stage = 5;

    }

    public void SpawnCreep() {
        RemoveCreepEvent();
        creepVent.SetActive(true);
        Invoke("RemoveCreepEvent", 1);
    }

    private void RemoveCreepEvent() {
        creepVent.SetActive(false);
        Invoke("NoiseInBG", 1);
    }

    private void NoiseInBG() {
        if (GameManager.scene == 3) {
            // TODO: window break noise sfx
        }
    }

    public void EndGameJumpscare() {
        creepEndGame.SetActive(true);
        Debug.Log("EndGameJumpscare();");
        // TODO: Jumpscare sfx
        Invoke("GameOver", 5);
    }

    private void GameOver() {
        Application.LoadLevel("MainMenu");
    }




    // POPUPS
    public void Popup(string t) {
        // swap page sfx
        source.PlayOneShot(pageFlipAudio, 1f);
        switch (t) {
            case "Newspaper":
                newspaperSlide.TogglePopup();
                break;
            case "Note":
                noteSlide.TogglePopup();
                break;
            case "PhotoBoyButton":
                photoBoy.TogglePopup();
                break;
            case "PhotoCerysButton":
                photoCerys.TogglePopup();
                break;
            case "PhotoSusanButton":
                photoSusan.TogglePopup();
                break;
            case "BoxNote":
                boxNoteSlide.TogglePopup();
                break;
            case "VentNote":
                ventNoteSlide.TogglePopup();
                break;
        }
    }



}
