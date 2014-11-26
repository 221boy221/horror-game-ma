using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    // This class keeps track of your progression throughout the game
    public static int stage = 1;
    public static bool boxClickable = false;
    public static bool ventClickable = false;
    public static bool dicSet = false;
    public static Dictionary<string, int> clickMap = new Dictionary<string, int>();

}
