using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    // This class keeps track of your progression throughout the game
    public static int scene;
    public static int stage;
    public static float boxOpenDelay;
    public static bool boxClickable;
    public static bool ventClickable;
    public static bool dicSet;
    public static bool popup;
    public static bool lightsOff;
    public static bool boxOpened;
    public static bool boxSwitch;
    public static bool photoSwitch;
    public static bool laptopStatic;
    public static bool laptopOff;
    public static bool isInBox;
    public static bool isInVent;
    public static Dictionary<string, int> clickMap;

    public static void SetDefault() {
        scene               = 1;
        stage               = 1;
        boxOpenDelay        = 10f;
        boxClickable        = false;
        ventClickable       = false;
        dicSet              = false;
        popup               = false;
        lightsOff           = false;
        boxOpened           = false;
        boxSwitch           = false;
        photoSwitch         = false;
        laptopStatic        = false;
        laptopOff           = false;
        isInBox             = false;
        isInVent            = false;
        clickMap            = new Dictionary<string, int>();
    }

    public static void ResetDict() {
        clickMap.Clear();
        clickMap.Add("LightSwitch", 0);
        clickMap.Add("Newspaper", 0);
        clickMap.Add("Note", 0);
        clickMap.Add("PhotoBoyButton", 0);
        clickMap.Add("PhotoCerysButton", 0);
        clickMap.Add("PhotoSusanButton", 0);
        clickMap.Add("Box", 0);
        clickMap.Add("Vent", 0);
        clickMap.Add("VentNote", 0);
    }
}
