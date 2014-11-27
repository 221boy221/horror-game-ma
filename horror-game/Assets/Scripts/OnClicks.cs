using UnityEngine;
using System.Collections;

public class OnClicks : MonoBehaviour {

    // TODO: 
    //      Find a better way to store the player's progression
    //


    private EventManager eventManager;

    private void Start() {
        eventManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<EventManager>();
        if (!GameManager.dicSet) {
            GameManager.clickMap.Add("Laptop", 0);
            GameManager.clickMap.Add("LightSwitch", 0);
            GameManager.clickMap.Add("Newspaper", 0);
            GameManager.clickMap.Add("Note", 0);
            GameManager.clickMap.Add("PhotoBoyButton", 0);
            GameManager.clickMap.Add("PhotoCerysButton", 0);
            GameManager.clickMap.Add("PhotoSusanButton", 0);
            GameManager.clickMap.Add("Box", 0);
            GameManager.clickMap.Add("Vent", 0);
            GameManager.dicSet = true;
        }
        
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("--- Click ---");

            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            
            if (hit) {

                string t = hitInfo.transform.gameObject.tag;
                
                switch (GameManager.scene) {
                    // Scene 1
                    case 1: 
                        Debug.Log("S1 Clicked on: " + t);
                        switch (t) {
                            case "Laptop":
                                GameManager.clickMap[t]++;
                                Debug.Log(GameManager.clickMap[t]);
                                break;
                            case "LightSwitch":
                                GameManager.clickMap[t]++;
                                Debug.Log(GameManager.clickMap[t]);
                                eventManager.LightSwitch();
                                if (GameManager.stage == 3 || GameManager.stage == 4) {
                                    GameManager.lightSwitchClicked = true;
                                }
                                break;
                            case "Newspaper":
                                GameManager.clickMap[t]++;
                                Debug.Log(GameManager.clickMap[t]);
                                eventManager.Popup(t);
                                if (GameManager.stage == 3 || GameManager.stage == 4) {
                                    GameManager.newspaperClicked = true;
                                }
                                break;
                            case "Note":
                                GameManager.clickMap[t]++;
                                Debug.Log(GameManager.clickMap[t]);
                                eventManager.Popup(t);
                                if (GameManager.stage == 3 || GameManager.stage == 4) {
                                    GameManager.noteClicked = true;
                                }
                                break;
                            case "PhotoBoyButton":
                                GameManager.clickMap[t]++;
                                Debug.Log(GameManager.clickMap[t]);
                                eventManager.Popup(t);
                                break;
                            case "PhotoCerysButton":
                                GameManager.clickMap[t]++;
                                Debug.Log(GameManager.clickMap[t]);
                                eventManager.Popup(t);
                                break;
                            case "PhotoSusanButton":
                                GameManager.clickMap[t]++;
                                Debug.Log(GameManager.clickMap[t]);
                                eventManager.Popup(t);
                                break;
                            case "Box":
                                if (GameManager.boxClickable) {
                                    GameManager.clickMap[t]++;
                                    Debug.Log(GameManager.clickMap[t]);
                                    eventManager.BoxScene();
                                }
								break;
                            case "Vent":
                                if (GameManager.ventClickable) {
                                    GameManager.clickMap[t]++;
                                    Debug.Log(GameManager.clickMap[t]);
                                    GameManager.scene = 3;
                                    Application.LoadLevel("InsideVent");
                                }
                                break;
                        }
                        break;
					// Scene 2
                    case 2:
						Debug.Log("S2 Clicked on: " + t);
						switch (t) {
							case "BoxNote":
                                eventManager.Popup(t);
								break;
							case "Back":
								Application.LoadLevel("GameScene");
                                GameManager.scene = 1;
                                if (GameManager.stage == 1) GameManager.stage = 2;
								break;
						}
                        break;
                    // Scene 3
                    case 3:
                        Debug.Log("S3 Clicked on: " + t);
						switch (t) {
						    case "VentNote":
							    eventManager.Popup(t);
							    break;
						    case "Back":
							    Application.LoadLevel("GameScene");
							    GameManager.scene = 1;
							    break;
						}
                        break;
                    // No Scene found
                    default:
                        break;
                }


                // TRIGGERS
                switch (GameManager.stage) {
                    // Stage 1  -   Box
                    case 1:
                        if (!GameManager.boxClickable) {
                            if (GameManager.clickMap["LightSwitch"] >= 3 && GameManager.clickMap["Newspaper"] >= 3 && GameManager.clickMap["Note"] >= 2) {
                                eventManager.BoxFall();
                                Debug.Log("Stage 1  -   Box");
                            }
                        }
                        break;
                    // Stage 2  -   Laptop Static
                    case 2:
                        if (GameManager.clickMap["LightSwitch"] >= 10 && GameManager.clickMap["Newspaper"] >= 4 && GameManager.clickMap["Note"] >= 3) {
                            eventManager.LaptopStatic();
                            Debug.Log("Stage 2  -   Laptop Static");
                        }
                        break;
                    // Stage 3  -   Blackout / Night adventure / Picture change
                    case 3:
                        if (GameManager.lightSwitchClicked && GameManager.newspaperClicked && GameManager.noteClicked) {    
                            GameManager.lightsOff = true;
                            GameManager.lightSwitchClicked = GameManager.newspaperClicked = GameManager.noteClicked = false;
                            eventManager.LightSwitch();
                            Debug.Log("Stage 3  -   Blackout / Night adventure / Picture change");
                        }
                        break;
                    // Stage 4  -   Vent system (opens when entering the boxScene)
                    case 4:
                        if (GameManager.lightSwitchClicked && GameManager.newspaperClicked && GameManager.noteClicked) {
                            // next event
                            Debug.Log("Stage 4  -   Vent system (opens when entering the boxScene)");
                        }
                        break;
                }


            }
        }

    }


}