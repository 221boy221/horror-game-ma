using UnityEngine;
using System.Collections;

public class OnClicks : MonoBehaviour {

    private EventManager eventManager;
    private int stage = 1;
    private int[] clicks;


    void Start() {
        eventManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<EventManager>();

        clicks = new int[5];
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("--- Click ---");

            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            
            if (hit) {

                string t = hitInfo.transform.gameObject.tag;

                /*
                if (EventManager.firstClicked == null) {
                    EventManager.firstClicked = t;
                }
                
                if (t == EventManager.firstClicked) {
                */

                switch (stage) {
                    case 1:
                        // Stage 1
                        Debug.Log("Clicked on: " + t);
                        switch (t) { 
                            case "Laptop":
                                clicks[0]++;
                                Debug.Log(clicks[0]);
                                if (clicks[0] == 10) {
                                    eventManager.LaptopStatic();
                                }
                                break;
                            case "LightSwitch":
                                clicks[1]++;
                                Debug.Log(clicks[1]);
                                if (clicks[1] == 10) {
                                    eventManager.LightSwitch();
                                }
                                break;
                            case "Newspaper":
                                clicks[2]++;
                                Debug.Log(clicks[2]);
                                eventManager.Newspaper();
                                // TODO : Open up the Newspaper by switching scene? slide it in the screen.
                                break;
                            case "Note":
                                clicks[3]++;
                                Debug.Log(clicks[3]);
                                eventManager.Note();
                                // TODO : Open up the Note by switching scene? slide it in the screen.
                                break;
                        }
                        break;
                    case 2:
                        // TODO: Stage 2
                        break;
                    case 3:
                        // TODO: Stage 3
                        break;
                    default:
                        break;
                }
            }
        }

    }


}