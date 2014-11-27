using UnityEngine;
using System.Collections;

public class SpooksDelay : MonoBehaviour {

    private GameObject delayedObjects;

    void Awake() {
        delayedObjects = GameObject.FindGameObjectWithTag("DelayedObjects");
        delayedObjects.SetActive(false);

        if (!GameManager.boxOpened) {
            Invoke("ShowButtons", GameManager.boxOpenDelay + 1f);
        } else {
            delayedObjects.SetActive(true);
        }
    }

    void ShowButtons() {
        delayedObjects.SetActive(true);
    }
}