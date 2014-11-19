﻿using UnityEngine;
using System.Collections;

// Gemaakt door Boy

public class MainMenu:MonoBehaviour {


	[SerializeField] private Texture2D logo;
    [SerializeField] private Texture2D menuBG;
	[SerializeField] private GUIStyle playStyle;
	[SerializeField] private GUIStyle quitStyle;

	private bool opened = true;

    void OnGUI() {
        if (!opened) {
			return; 
        }
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), menuBG);
		GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3((float)Screen.width / 1920.0f, (float)Screen.height / 1080.0f, 1));
        GUI.DrawTexture(new Rect(350 - logo.width / 2, 25, logo.width + 100, logo.height + 100), logo);

        // Buttons
		if (GUI.Button(new Rect(1000, 700, 150, 150), new GUIContent(), playStyle)) {		
            Application.LoadLevel("testScene"); // Run game
        } else if (GUI.Button(new Rect(1400, 900, 150, 150), new GUIContent(), quitStyle)) {
			Application.Quit(); // Quits the game
		}
    }

}