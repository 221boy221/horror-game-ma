using UnityEngine;
using System.Collections;

public class OnClick : MonoBehaviour {


    public int amountOfClicks;

    void OnMouseDown() {
        amountOfClicks++;
        Debug.Log(amountOfClicks);
    }

}
