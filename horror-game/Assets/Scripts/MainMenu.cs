using UnityEngine;
using System.Collections;

// Gemaakt door Boy

public class MainMenu:MonoBehaviour {

	[SerializeField] private GUIStyle playStyle;
	[SerializeField] private GUIStyle quitStyle;

    private float screenResX = 1920.0f;
    private float screenResY = 1080.0f;

    private void OnGUI() {
        // Start matrix // 
		GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3((float)Screen.width / screenResX, (float)Screen.height / screenResY, 1));

        // Buttons
        if (GUI.Button(new Rect(screenResX / 2 - playStyle.fixedWidth / 2, screenResY / 2, playStyle.fixedWidth, playStyle.fixedHeight), new GUIContent(), playStyle)) {
            GameManager.ResetAll(); // Makes it so that the save data from the previous game is reset
            Application.LoadLevel("IntroNewspaper");
        } else if (GUI.Button(new Rect(screenResX / 2 - quitStyle.fixedWidth / 2, screenResY / 2 + quitStyle.fixedHeight / 2, quitStyle.fixedWidth, quitStyle.fixedHeight), new GUIContent(), quitStyle)) {
			Application.Quit();
		}
    }
}