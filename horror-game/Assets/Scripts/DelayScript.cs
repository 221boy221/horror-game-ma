using UnityEngine;
using System.Collections;

public class DelayScript : MonoBehaviour {
	
    private SliderScript newspaperSlide;

	void Awake () {
        newspaperSlide = GameObject.FindGameObjectWithTag("NewspaperSlide").GetComponent<SliderScript>();
		Invoke("DelayInvoke",(5));
	}

    private void DelayInvoke() {
        newspaperSlide.TogglePopup();
        Invoke("LoadGame", (1));
	}

    private void LoadGame() {
        Application.LoadLevel("prototype01");
    }

}
