using UnityEngine;
using System.Collections;

public class Inv : MonoBehaviour {

    private Transform goTransform;  // This object
    private Vector3 goScreenPos;    // On screenPos in Pixels
    //private Vector3 goViewportPos;  // On screenPos

    private int centerOffsetX;
    private int centerOffsetY;

    public int invWidth = 200;
    public int invHeight = 100;
    public float offsetX = 0;
    public float offsetY = 150;

    // For the grid
    const int Rows = 3;
    Row[] rows = new Row[Rows];

    void Awake() {
        goTransform = GetComponent<Transform>();
    }

    void Start() {
        // Loop through the rows array and make cols
        for (int row = 0; row < Rows; row++) {
        //    rows[row] = new Row("picture" + row, "key " + row, "note " + row);
        }

        // Center inventory onto object
        centerOffsetX = invWidth / 2;
        centerOffsetY = invHeight / 2;
    }

    // Once a frame, after update
    void LateUpdate() {
        // Find this object's pos on screen
        goScreenPos = Camera.main.WorldToScreenPoint(goTransform.position);
        //goViewportPos = Camera.main.WorldToViewportPoint(goTransform.position);
    }

    void OnGUI() {
        // Make a group so everything in it will be positioned correctly
        GUI.BeginGroup(new Rect(goScreenPos.x - centerOffsetX - offsetX, Screen.height - goScreenPos.y - centerOffsetY - offsetY, invWidth, invHeight));

        for (int row = 0; row < Rows; row++) {
            GUILayout.BeginVertical();
            rows[row].Draw();
            GUILayout.EndVertical();
        }

        if (GUI.Button(new Rect(50, 60, 100, 30), "Test button")) {
            Debug.Log("Test");
        }

        GUI.EndGroup();
    }
    
}