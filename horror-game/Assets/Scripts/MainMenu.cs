using UnityEngine;
using System.Collections;

// Gemaakt door Boy

public class MainMenu:MonoBehaviour {


	[SerializeField] private Texture2D logo;
    [SerializeField] private Texture2D menuBG;
	[SerializeField] private GUIStyle playStyle;
	[SerializeField] private GUIStyle quitStyle;

	private bool opened = true;
    private float screenResX = 1280.0f;
    private float screenResY = 720.0f;

    void OnGUI() {
        if (!opened) {
			return; 
        }
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), menuBG);
		GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3((float)Screen.width / screenResX, (float)Screen.height / screenResY, 1));
        // Logo
        GUI.DrawTexture(new Rect(screenResX / 2 - logo.width / 2, 25, logo.width + 100, logo.height + 100), logo);

        // Buttons
		if (GUI.Button(new Rect(screenResX / 2 - 75, screenResY / 2, 150, 150), new GUIContent(), playStyle)) {		
            Application.LoadLevel("prototype01"); // Run game
        } else if (GUI.Button(new Rect(screenResX / 2 - 75, screenResY / 2 + 100, 150, 150), new GUIContent(), quitStyle)) {
			Application.Quit(); // Quits the game
		}
    }

}