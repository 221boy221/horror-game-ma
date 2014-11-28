using UnityEngine;
using System.Collections;

public class SliderScript : MonoBehaviour {

	public Transform target;
	public float speed;

    public bool popup = false;
    public bool clickAble = true;
    private bool toggle;
    private Vector3 originalPos;

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
        if (clickAble) {
            popup = false;
            GameManager.popup = popup;
        }
    }

    public void TogglePopup() {
        toggle = popup ? false : true;
        popup = toggle;
        // Tell the GameManager that something is in the screen of the player
        GameManager.popup = popup;
    }


}
