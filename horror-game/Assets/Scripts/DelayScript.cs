using UnityEngine;
using System.Collections;

public class DelayScript : MonoBehaviour {
	
    private SliderScript newspaperSlide;
    public string loadScene;
    public bool popupNewspaper = false;

	void Awake () {
        if (popupNewspaper) newspaperSlide = GameObject.FindGameObjectWithTag("NewspaperSlide").GetComponent<SliderScript>();
		Invoke("DelayInvoke",(10));
	}

    private void DelayInvoke() {
        if (popupNewspaper) newspaperSlide.TogglePopup();
        Invoke("LoadGame", 3);
	}

    private void LoadGame() {
        Application.LoadLevel(loadScene);
    }

}
