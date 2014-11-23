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

	string[] cols = new string[(int)Cols.NumCols];

	public Row( string picture, string key, string note ) {
		cols [(int)Cols.Picture] = picture;
		cols [(int)Cols.Key] = key;
		cols [(int)Cols.Note] = note;
	}


	public void Draw() {
		GUILayout.BeginHorizontal ();
		GUILayout.TextArea (cols [(int)Cols.Picture]);
		GUILayout.TextArea (cols [(int)Cols.Key]);
		GUILayout.TextArea (cols [(int)Cols.Note]);
		GUILayout.EndHorizontal ();
	}
}
