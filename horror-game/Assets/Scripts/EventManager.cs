using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {
    
    private SliderScript newspaperSlide;
    private SliderScript noteSlide;
    private SliderScript photoBoy;
    private SliderScript photoCerys;
    private SliderScript photoSusan;
    private SliderScript boxNoteSlide;
    private SliderScript ventNoteSlide;
    private GameObject tlLight;
    private GameObject lpLight;
    private bool tlLightActive = true;
    private bool lpLightActive = false;

    private void Start() {
        if (Application.loadedLevelName == "GameScene") {
            newspaperSlide  = GameObject.FindGameObjectWithTag("NewspaperSlide").GetComponent<SliderScript>();
            noteSlide       = GameObject.FindGameObjectWithTag("NoteSlide").GetComponent<SliderScript>();
            photoBoy        = GameObject.FindGameObjectWithTag("PhotoBoySlide").GetComponent<SliderScript>();
            photoCerys      = GameObject.FindGameObjectWithTag("PhotoCerysSlide").GetComponent<SliderScript>();
            photoSusan      = GameObject.FindGameObjectWithTag("PhotoSusanSlide").GetComponent<SliderScript>();
            tlLight         = GameObject.FindGameObjectWithTag("TL Light");
            lpLight         = GameObject.FindGameObjectWithTag("LaptopLight");

            lpLight.SetActive(lpLightActive);
        } else if (Application.loadedLevelName == "InsideBox") {
            boxNoteSlide = GameObject.FindGameObjectWithTag("BoxNoteSlide").GetComponent<SliderScript>();
        } else if (Application.loadedLevelName == "InsideVent") {
            ventNoteSlide = GameObject.FindGameObjectWithTag("VentNoteSlide").GetComponent<SliderScript>();
        }
    }
    

    /*          All events will be in here           */


    public void LaptopStatic() {
        // So that it won't be trigger-able again
        GameManager.stage = 3;
        
        // TODO: Enable the laptopStatic anim
        //       Timer of 10 secs, then disable.
        
        // After the 10 secs:
        LightFlicker();
    }
    
    public void LightSwitch() {
        Debug.Log("On / Off");

        if (!GameManager.lightsOff) {
            tlLightActive = tlLightActive ? false : true;
            tlLight.SetActive(tlLightActive);
            lpLightActive = lpLightActive ? false : true;
            lpLight.SetActive(lpLightActive);
        } else {
            // Start a timer of 10 seconds, lights should remain off for that amount of time
            // After the timer:
            LightFlicker();
            // red eyes through window art .setActive = true;

            // After all that, the player can use the lightswitch again.
            GameManager.lightsOff = false;

            // All photo's should now be changed to their scratched versions
            PhotosScratched();

            GameManager.stage = 4;
        }
        
    }

    public void LightFlicker() {
        // TODO: Flicker the lights
    }

    public void PhotosScratched() {
        // TODO: Change all photo's art to their scratched versions
    }

    public void BoxFall() {
        if (GameManager.popup) {
            Debug.Log("Box fall animation");
            // TODO: make the box drop

            // When falling anim is done:
            GameManager.boxClickable = true;
        }
	}

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
