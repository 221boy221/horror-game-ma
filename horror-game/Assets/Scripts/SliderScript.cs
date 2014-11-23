using UnityEngine;
using System.Collections;

public class SliderScript : MonoBehaviour {

	public Transform target;
	public float speed;

    public bool popup = false;
    private Vector3 originalPos;
    public bool clickAble = true;

    private void Start() {
        originalPos = transform.position;
    }

    private void Update() {
        float step = speed * Time.deltaTime;
        
        if (popup) {
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        } else {
            transform.position = Vector3.MoveTowards(transform.position, originalPos, step);
        }

	}

    private void OnMouseDown() {
        if (clickAble) popup = false;
    }

    public void TogglePopup() {
        if (popup) popup = false;
        else if (!popup) popup = true;
    }


}
