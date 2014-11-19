using UnityEngine;
using System.Collections;

public class SliderScript : MonoBehaviour {

	public Transform target;
	public float speed;

    private bool popup = false;
    private Vector3 originalPos;

    void Start() {
        originalPos = transform.position;
    }

	void Update() {
        float step = speed * Time.deltaTime;
        
        if (popup) {
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        } else {
            transform.position = Vector3.MoveTowards(transform.position, originalPos, step);
        }

	}
    
    void OnMouseDown() {
        popup = false;
    }

    public void TogglePopup() {
        if (popup) popup = false;
        else if (!popup) popup = true;
    }


}
