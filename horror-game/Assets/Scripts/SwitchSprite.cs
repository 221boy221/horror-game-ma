using UnityEngine;
using System.Collections;

public class SwitchSprite : MonoBehaviour {

	public Sprite newSprite;
    public bool isBox = false;

    private void Start() {
        NewSprite();
    }

    public void NewSprite () {
        if (GameManager.boxSwitch && isBox) {
            GetComponent<SpriteRenderer>().sprite = newSprite;
        } else if (GameManager.photoSwitch && !isBox) {
            GetComponent<SpriteRenderer>().sprite = newSprite;
        }
    }
}
