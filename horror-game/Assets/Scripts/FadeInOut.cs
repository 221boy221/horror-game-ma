using UnityEngine;
using System.Collections;

public class FadeInOut : MonoBehaviour {

    public float fadeSpeed = 1.5f;
    public string loadApp;
    private bool sceneStarting = true;

    void Awake() {
        // Make texture fill screen
        guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
    }

    void Update() {
        if (sceneStarting) {
            StartScene();
        }
    }

    void FadeToClear() {
        // Slowly fade to clear
        guiTexture.color = Color.Lerp(guiTexture.color, Color.clear, fadeSpeed * Time.deltaTime);
    }

    void FadeToBlack() {
        // Slowly fade to black
        guiTexture.color = Color.Lerp(guiTexture.color, Color.black, (fadeSpeed * Time.deltaTime) / 2);
    }

    void StartScene() {
        FadeToClear();

        if (guiTexture.color.a <= 0.02f) {
            guiTexture.color = Color.clear;
            guiTexture.enabled = false;
            sceneStarting = false;
        }
    }

    public void EndScene() {
        guiTexture.enabled = true;
        FadeToBlack();

        // Load next scene
        if (guiTexture.color.a >= 0.6f) {
            Application.LoadLevel(loadApp);
        }
    }

}
