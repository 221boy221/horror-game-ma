using UnityEngine;
using System.Collections;

public class SwitchSprite : MonoBehaviour {

    public Sprite newSprite;
    public Sprite newSprite2;
    public Texture newTexture;
    public bool isBox = false;

    private void Start() {
        NewSprite(1);
    }

    public void NewSprite (int i) {
        switch (i) {
            case 1:
                if (GameManager.boxSwitch && isBox) {
                    GetComponent<SpriteRenderer>().sprite = newSprite;
                }
                break;
            case 2:
                if (GameManager.photoSwitch && !isBox) {
                    GetComponent<SpriteRenderer>().sprite = newSprite;
                }
                break;
            case 3:
                if (GameManager.photoSwitch && !isBox) {
                    GetComponent<SpriteRenderer>().sprite = newSprite2;
                }
                break;
            case 4:
                renderer.material.mainTexture = newTexture;
                break;
        }
        
    }
}
