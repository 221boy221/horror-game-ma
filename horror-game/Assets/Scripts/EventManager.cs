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
        Debug.Log("CRASH LAPTOP SCREEN ETC...");
        // TODO: Switch art of the laptop to the animation that has the static screen flickering stuff
    }
    
    public void LightSwitch() {
        Debug.Log("On / Off");
        // TODO: Let the lights flicker for a certain amount of time
        tlLightActive = tlLightActive ? false : true;
        tlLight.SetActive(tlLightActive);
        lpLightActive = lpLightActive ? false : true;
        lpLight.SetActive(lpLightActive);
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

	public void Box() {
		Debug.Log("drop this beat i mean box");
		// TODO: make the box drop
	}

}
