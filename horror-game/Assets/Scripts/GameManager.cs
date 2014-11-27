using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    // This class keeps track of your progression throughout the game
    public static int scene = 1;
    public static int stage = 1;
    public static float boxOpenDelay = 10f;
    public static bool boxClickable  = false;
    public static bool ventClickable = false;
    public static bool dicSet = false;
    public static bool popup  = false;
    public static bool lightSwitchClicked = false;
    public static bool newspaperClicked   = false;
    public static bool noteClicked  = false;
    public static bool lightsOff    = false;
    public static bool boxOpened    = false;
    public static bool boxSwitch    = false;
    public static bool photoSwitch  = false;
    public static Dictionary<string, int> clickMap = new Dictionary<string, int>();

}
