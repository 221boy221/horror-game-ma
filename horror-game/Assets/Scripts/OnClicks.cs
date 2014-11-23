using UnityEngine;
using System.Collections;

public class OnClicks : MonoBehaviour {

    private EventManager eventManager;
    private int stage = 1;
    private int[] clicks;


    void Start() {
        eventManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<EventManager>();

        clicks = new int[9];
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("--- Click ---");

            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            
            if (hit) {

                string t = hitInfo.transform.gameObject.tag;
<<<<<<< HEAD
                /*
                if (EventManager.firstClicked == null) {
                    EventManager.firstClicked = t;
                }
                
                if (t == EventManager.firstClicked) {
                */
				//if (clicks[1] >= 10 && clicks[2] >= 10 && clicks[3] >= 10){
=======

>>>>>>> origin/master
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
                                if (clicks[1] == 5) {
                                    eventManager.LightSwitch();
                                }
                                break;
                            case "Newspaper":
                                clicks[2]++;
                                Debug.Log(clicks[2]);
                                eventManager.Newspaper();
<<<<<<< HEAD
								if (clicks[2] == 5) {
									//eventManager.Newspaper();
								}
                                // TODO : Open up the Newspaper by switching scene? slide it in the screen.
=======
>>>>>>> origin/master
                                break;
                            case "Note":
                                clicks[3]++;
                                Debug.Log(clicks[3]);
                                eventManager.Note();
                                break;
                            case "InvButton":
                                clicks[4]++;
                                Debug.Log(clicks[4]);
                                eventManager.InvButton();
                                break;
							case "Box":
								clicks[4]++;
								Debug.Log(clicks[4]);
								if (clicks[1] >= 10 && clicks[2] >= 10 && clicks[3] >= 10){
									stage++;
									//eventManager.Box();
								}
								break;
                        }
                        break;
					//Stage 2
                    case 2:
						Debug.Log("Clicked on: " + t);
						Application.LoadLevel("InsideBox");
						switch (t) {
							case "BoxNote":
								clicks[5]++;
								Debug.Log("well fuck");
								eventManager.BoxNote();
								break;
							case "back":
								Application.LoadLevel("prototype01");
								break;
						}
                        break;
                    case 3:
                        // TODO: Stage 3
                        break;
                    default:
                        break;
                }
				/*if (clicks[1] >= 10 && clicks[2] >= 10 && clicks[3] >= 10){
					// TODO:play annimation of box falling
				}*/
            }
        }

    }


}