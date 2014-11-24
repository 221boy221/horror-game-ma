using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {

    // TODO: Remove the text and put real buttons/objects into the inventory

	public Rect rect;
	public Texture2D background;

    public GUIStyle picture;
    public GUIStyle key;
    public GUIStyle note;

    public GameObject objToFollow;
	
    private float screenResX = 1920.0f;
    private float screenResY = 1080.0f;
    private Vector3 scale;

    const int Rows = 3;
	Row[] rows = new Row[Rows];
    

	void Start() {
		for (int row=0; row < Rows; row++) 
		{
            rows[row] = new Row(picture, key, note);
		}
	}
    
	void OnGUI() {
        // Screen Ratio (16:9 -> 1920x1080 || 1280x720)
        scale.y = Screen.height / screenResY;
        scale.x = scale.y; 
        scale.z = 1;

        float scaleX = Screen.width / screenResX; // Store this for translate
        Matrix4x4 svMat = GUI.matrix; // Save current matrix

        // Matrix start //
        GUI.matrix = Matrix4x4.TRS(new Vector3((scaleX - scale.y) / 2 * screenResX, 0, 0), Quaternion.identity, scale);

        //GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3((float)Screen.width / screenResX, (float)Screen.height / screenResY, 1));

        //Vector3 posToFollow = Camera.main.WorldToScreenPoint(objToFollow.transform.position);
        //Rect rect = new Rect(posToFollow.x, Screen.height - posToFollow.y , size, size);
        //rect = new Rect(desiredPos.x, Screen.height - desiredPos.y, size.x, size.y);
        //rect = new Rect(transform.position.x, transform.position.y, 500, 500);

        rect = new Rect(screenResX / 3, screenResY / 3, screenResX / 3, screenResY / 3);

		GUILayout.BeginArea(rect, background);

		for (int row=0; row < Rows; row++) {
			GUILayout.BeginVertical();
			rows[row].Draw();
			GUILayout.EndVertical();
		}

		GUILayout.EndArea ();
        GUI.matrix = svMat; // Restore matrix
        // Matrix End //
	}

}
