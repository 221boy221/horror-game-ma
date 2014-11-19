using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {
    
    public static string firstClicked;
    

    /*          All events will be in here           */

    public void LaptopStatic() {
        Debug.Log("CRASH LAPTOP SCREEN ETC...");
        // TODO: Switch art of the laptop to the animation that has the static screen flickering stuff
    }

    public void LightSwitch() {
        Debug.Log("FLICKER THE LIGHT(S)");
        // TODO: Let the lights flicker for a certain amount of time
    }
}
