using UnityEngine;
using System.Collections;

public class DelayScript : MonoBehaviour {
	
    private SliderScript newspaperSlide;

	void Awake () {
        newspaperSlide = GameObject.FindGameObjectWithTag("NewspaperSlide").GetComponent<SliderScript>();
		Invoke("DelayInvoke",(10));
	}

    private void DelayInvoke() {
        newspaperSlide.TogglePopup();
        Invoke("LoadGame", 3);
	}

    private void LoadGame() {
        Application.LoadLevel("GameScene");
    }

}
