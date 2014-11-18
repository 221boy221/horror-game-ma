using UnityEngine;
using System.Collections;

public class OnClicks : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("--- Click ---");

            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit) {
                Debug.Log("Hit: " + hitInfo.transform.gameObject.name);

                if (hitInfo.transform.gameObject.tag == "Obj01") {
                    Debug.Log("Trigger event 01");
                } else if (hitInfo.transform.gameObject.tag == "Obj02") {
                    Debug.Log("Trigger event 02");
                } else if (hitInfo.transform.gameObject.tag == "Obj03") {
                    Debug.Log("Trigger event 03");
                } else {
                    Debug.Log("Do nothing");
                }

            }
        }
    }

}
