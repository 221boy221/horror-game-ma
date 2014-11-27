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
    private SwitchSprite boxFall;
    private GameObject tlLight;
    private GameObject lpLight;
    private GameObject creepWindow;
    private Animator laptop;
    private Animator boxAnim;
    private bool tlLightActive = true;
    private bool lpLightActive = false;

    private void Start() {
        if (Application.loadedLevelName == "GameScene") {
            newspaperSlide  = GameObject.FindGameObjectWithTag("NewspaperSlide").GetComponent<SliderScript>();
            noteSlide       = GameObject.FindGameObjectWithTag("NoteSlide").GetComponent<SliderScript>();
            photoBoy        = GameObject.FindGameObjectWithTag("PhotoBoySlide").GetComponent<SliderScript>();
            photoCerys      = GameObject.FindGameObjectWithTag("PhotoCerysSlide").GetComponent<SliderScript>();
            photoSusan      = GameObject.FindGameObjectWithTag("PhotoSusanSlide").GetComponent<SliderScript>();
            photoBoyScratched   = GameObject.FindGameObjectWithTag("PhotoBoySlide").GetComponent<SwitchSprite>();
            photoCerysScratched = GameObject.FindGameObjectWithTag("PhotoCerysSlide").GetComponent<SwitchSprite>();
            photoSusanScratched = GameObject.FindGameObjectWithTag("PhotoSusanSlide").GetComponent<SwitchSprite>();
            boxFall         = GameObject.FindGameObjectWithTag("BoxFall").GetComponent<SwitchSprite>();
            laptop          = GameObject.FindGameObjectWithTag("LaptopStatic").GetComponent<Animator>();
            tlLight         = GameObject.FindGameObjectWithTag("TL Light");
            lpLight         = GameObject.FindGameObjectWithTag("LaptopLight");
            creepWindow     = GameObject.FindGameObjectWithTag("CreepWindow");

            creepWindow.SetActive(false);
            lpLight.SetActive(lpLightActive);

        } else if (Application.loadedLevelName == "InsideBox") {
            boxNoteSlide = GameObject.FindGameObjectWithTag("BoxNoteSlide").GetComponent<SliderScript>();
            boxAnim = GameObject.FindGameObjectWithTag("BoxAnim").GetComponent<Animator>();
            CheckBoxAnim();
        } else if (Application.loadedLevelName == "InsideVent") {
            ventNoteSlide = GameObject.FindGameObjectWithTag("VentNoteSlide").GetComponent<SliderScript>();
        }
    }
    

    /*          All events will be in here           */



    // BOX
    public void BoxFall() {
        if (GameManager.popup) {
            Debug.Log("Box fall animation");
            GameManager.boxSwitch = true;
            boxFall.NewSprite();
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
        // TODO: boxOpening sfx
        GameManager.boxOpened = true;
    }
    
    
    
    // LAPTOP
    public void LaptopStatic() {
        if (laptop) { // Extra protection to avoid bugs
            // So that it won't be trigger-able again
            GameManager.stage = 3;
            laptop.Play("laptopStatic");
            Invoke("LaptopOff", 10);
        }
    }

    private void LaptopOff() {
        // After the 10 secs:
        laptop.Play("laptopOff");
        lpLight.SetActive(false);
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
        } else {
            // Start a timer of 10 seconds, lights should remain off for that amount of time, after that, LightFlicker();
            tlLight.SetActive(false);
            lpLight.SetActive(false);
            Invoke("LightFlicker", 10);

            PhotosScratched();
            GameManager.stage = 4;
        }
        
    }

    public void LightFlicker() {

        // TODO: Flicker the light script here;

        if (GameManager.stage == 4) {
            // Run the extra events such as the creepWindow
            creepWindow.SetActive(true);
        }

        // After all that, the player can use the lightswitch again.
        Invoke("ResetLights", 10); 
    }

    private void ResetLights() {
        // Temp light 'reset' function
        creepWindow.SetActive(false);
        tlLight.SetActive(true);
        GameManager.lightsOff = false;
    }



    // PHOTOS
    public void PhotosScratched() {
        Debug.Log("switch photos");
        GameManager.photoSwitch = true;
        photoBoyScratched.NewSprite();
        photoCerysScratched.NewSprite();
        photoSusanScratched.NewSprite();
    }



    // POPUPS
    public void Popup(string t) {
        switch(t) {
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
