using UnityEngine;
using System.Collections;

public class Row {

    // Used to create the cols in the rows
	enum Cols {
		Picture,
		Key,
		Note,
		// ---
		NumCols
    }
    GUIStyle[] cols = new GUIStyle[(int)Cols.NumCols];
	//string[] cols = new string[(int)Cols.NumCols];

    public Row(GUIStyle picture, GUIStyle key, GUIStyle note) {
		cols [(int)Cols.Picture] = picture;
		cols [(int)Cols.Key] = key;
		cols [(int)Cols.Note] = note;
	}


	public void Draw() {
		GUILayout.BeginHorizontal ();
        if (GUILayout.Button(new GUIContent(), cols [(int)Cols.Picture])) {
            Debug.Log("Test");
        } else if (GUILayout.Button(new GUIContent(), cols[(int)Cols.Key])) {
            Debug.Log("Test");
        } else if (GUILayout.Button(new GUIContent(), cols[(int)Cols.Note])) {
            Debug.Log("Test");
        }
        
        
		//GUILayout.TextArea (cols [(int)Cols.Picture]);
		//GUILayout.TextArea (cols [(int)Cols.Key]);
		//GUILayout.TextArea (cols [(int)Cols.Note]);
		GUILayout.EndHorizontal ();
	}
}
