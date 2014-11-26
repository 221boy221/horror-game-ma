using UnityEngine;
using System.Collections;

public class SpooksDelay : MonoBehaviour {
	
	private GameObject spawnObject;
	private bool ObjectActive = true;
	
	void Awake () {
		Debug.Log ("yeah hi i work? really awsome");
		spawnObject = GameObject.FindGameObjectWithTag ("DelayedObjects");

		Invoke("DelayTime",(5));
	}
	void Start() {
		ObjectActive = ObjectActive ? false : true;
		spawnObject.SetActive (ObjectActive);
	}
	private void DelayTime() {
		Debug.Log ("hi here i am again");
		ObjectActive = ObjectActive ? false : true;
		spawnObject.SetActive (ObjectActive);
	}

}