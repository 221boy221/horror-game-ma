using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {
    
    //public static string firstClicked;
    private SliderScript newspaperSlide;
    private SliderScript noteSlide;
	private SliderScript boxNoteSlide;

    void Start() {
		//if ( != null) {
			newspaperSlide = GameObject.FindGameObjectWithTag ("NewspaperSlide").GetComponent<SliderScript> ();
			noteSlide = GameObject.FindGameObjectWithTag ("NoteSlide").GetComponent<SliderScript> ();
			boxNoteSlide = GameObject.FindGameObjectWithTag ("BoxNoteSlide").GetComponent<SliderScript> ();
		//}
    }
    

    /*          All events will be in here           */

    public void LaptopStatic() {
        Debug.Log("CRASH LAPTOP SCREEN ETC...");
        // TODO: Switch art of the laptop to the animation that has the static screen flickering stuff
    }

    public void LightSwitch() {
        Debug.Log("FLICKER THE LIGHT(S)");
        // TODO: Let the lights flicker for a certain amount of time
    }

    public void Newspaper() {
        Debug.Log("Scroll Newspaper into screen");
        newspaperSlide.TogglePopup();
    }

    public void Note() {
        Debug.Log("Scroll Note into screen");
        noteSlide.TogglePopup();
    }

	public void Box() {
		Debug.Log("drop this beat i mean box");
		// TODO: make the box drop
	}

	public void BoxNote() {
		Debug.Log("Scroll BoxNote into screen");
		boxNoteSlide.TogglePopup();
	}
}
