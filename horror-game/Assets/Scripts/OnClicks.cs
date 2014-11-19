using UnityEngine;
using System.Collections;

public class OnClicks : MonoBehaviour {

    private EventManager eventManager;
    private int stage = 1;
    private int clicksObj01 = 0;
    private int clicksObj02 = 0;
    private int clicksObj03 = 0;

    private int[] clicks;

    // Use this for initialization
    void Start() {
        eventManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<EventManager>();

        clicks = new int[5];
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("--- Click ---");

            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            
            if (hit) {

                string t = hitInfo.transform.gameObject.tag;

                if (EventManager.firstClicked == null) {
                    EventManager.firstClicked = t;
                }

                if (t == EventManager.firstClicked) {
                   
                    switch (t) { 
                        case "Laptop":
                            clicks[0]++;
                            break;
                        case "Light":
                            clicks[1]++;
                            break;
                        case "Newspaper":
                            clicks[2]++;
                            break;
                        case "Note":
                            clicks[3]++;
                            break;
                    }
                   
                }

              

                switch (stage) {
                    case 1:

                        //if (clicks[0] == 5)

                        /*
                        if (hitInfo.transform.gameObject.tag == "Obj01") {
                            clicksObj01++;
                            Debug.Log("clicks Obj 01: " + clicksObj01);
                            if (clicksObj01 == 5) {
                                Debug.Log("~ Trigger Event 01");
                            }

                        } else if (hitInfo.transform.gameObject.tag == "Obj02") {
                            if (clicksObj01 >= 5) {
                                clicksObj02++;
                                Debug.Log("clicks Obj 02: " + clicksObj02);
                                if (clicksObj02 == 5) {
                                    Debug.Log("~ Trigger Event 02 (switching to stage 2 now)");
                                    stage++;
                                }
                            }
                        }
                        */

                        break;
                    case 2:
                        if (hitInfo.transform.gameObject.tag == "Obj03") {
                            clicksObj03++;
                            Debug.Log("clicks Obj 03: " + clicksObj03);
                        }
                        break;
                    case 3:
                        break;
                    default:
                        break;
                }
            }
        }

    }

}