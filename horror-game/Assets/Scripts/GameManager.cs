using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    // This class keeps track of your progression throughout the game
    public static int scene = 1;
    public static int stage = 1;
    public static float boxOpenDelay = 5f;
    public static bool boxClickable  = false;
    public static bool ventClickable = false;
    public static bool dicSet = false;
    public static bool popup  = false;
    public static bool lightSwitchClicked = false;
    public static bool newspaperClicked   = false;
    public static bool photoBoyClicked    = false;
    public static bool photoCerysClicked  = false;
    public static bool photoSusanClicked  = false;
    public static bool noteClicked  = false;
    public static bool lightsOff    = false;
    public static bool boxOpened    = false;
    public static bool boxSwitch    = false;
    public static bool photoSwitch  = false;
    public static bool laptopStatic = false;
    public static bool laptopOff    = false;
    public static bool isInBox      = false;
    public static bool isInVent     = false;
    public static Dictionary<string, int> clickMap = new Dictionary<string, int>();

    public static void ResetAll() {
        scene   = 1;
        stage   = 1;
        boxClickable  = false;
        ventClickable = false;
        dicSet  = false;
        popup   = false;
        lightSwitchClicked  = false;
        newspaperClicked    = false;
        photoBoyClicked     = false;
        photoCerysClicked   = false;
        photoSusanClicked   = false;
        noteClicked  = false;
        lightsOff    = false;
        boxOpened    = false;
        boxSwitch    = false;
        photoSwitch  = false;
        laptopStatic = false;
        laptopOff    = false;
        isInBox      = false;
        isInVent     = false;
        clickMap     = new Dictionary<string, int>();
    }
}
