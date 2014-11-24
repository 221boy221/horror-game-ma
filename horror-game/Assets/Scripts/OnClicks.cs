using UnityEngine;
using System.Collections;

public class OnClicks : MonoBehaviour {

    private EventManager eventManager;
    private int[] clicks;
    private bool boxClickable = false;

    private void Start() {
        eventManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<EventManager>();

        clicks = new int[9];
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("--- Click ---");

            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            
            if (hit) {

                string t = hitInfo.transform.gameObject.tag;

                switch (GameManager.stage) {
                    case 1:
                        // Stage 1
                        Debug.Log("S1 Clicked on: " + t);
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
							case "Box":     // TODO: Find a better way to do this and the part at stage 2
								
                                if (boxClickable) {
                                    clicks[4]++;
								    Debug.Log(clicks[4]);
                                    GameManager.stage++;
                                    Application.LoadLevel("InsideBox");

                                }
								if (clicks[1] >= 10 && clicks[2] >= 10 && clicks[3] >= 10){
									
								}
								break;
                        }
                        break;
					//Stage 2
                    case 2:
						Debug.Log("S2 Clicked on: " + t);
						switch (t) {
							case "BoxNote":
								clicks[5]++;
								eventManager.BoxNote();
								break;
							case "Back":
								Application.LoadLevel("GameScene");
                                GameManager.stage--;
								break;
						}
                        break;
                    case 3:
                        // TODO: Stage 3
                        break;
                    default:
                        break;
                }
				if (clicks[1] >= 10 && clicks[2] >= 10 && clicks[3] >= 10) {
                    boxClickable = true;
					// TODO:play annimation of box falling
				}
            }
        }

    }


}