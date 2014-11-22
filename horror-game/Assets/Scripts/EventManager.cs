using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {
    
    //public static string firstClicked;
    private SliderScript newspaperSlide;
    private SliderScript noteSlide;
    private SliderScript invSlide;

    void Start() {
        newspaperSlide = GameObject.FindGameObjectWithTag("NewspaperSlide").GetComponent<SliderScript>();
        noteSlide = GameObject.FindGameObjectWithTag("NoteSlide").GetComponent<SliderScript>();
        invSlide = GameObject.FindGameObjectWithTag("InvSlide").GetComponent<SliderScript>();
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

    public void InvButton() {
        Debug.Log("Scroll Note into screen");
        invSlide.TogglePopup();
    }
}
