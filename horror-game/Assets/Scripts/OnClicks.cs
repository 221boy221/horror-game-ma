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
            GameManager.ResetDict();
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
                        switch (t) {
                            case "LightSwitch":
                                GameManager.clickMap[t]++;
                                Debug.Log(GameManager.clickMap[t]);
                                eventManager.LightSwitch();
                                break;
                            case "Newspaper":
                                GameManager.clickMap[t]++;
                                Debug.Log(GameManager.clickMap[t]);
                                eventManager.Popup(t);
                                break;
                            case "Note":
                                GameManager.clickMap[t]++;
                                Debug.Log(GameManager.clickMap[t]);
                                eventManager.Popup(t);
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
                                    eventManager.VentScene();
                                }
                                break;
                        }
                        break;
					// Scene 2
                    case 2:
                        GameManager.isInBox = true;
						switch (t) {
							case "BoxNote":
                                eventManager.Popup(t);
								break;
							case "Back":
								Application.LoadLevel("GameScene");
                                GameManager.scene = 1;
                                GameManager.isInBox = false;
                                if (GameManager.stage == 1) GameManager.stage = 2;
								break;
						}
                        break;
                    // Scene 3
                    case 3:
                        GameManager.isInVent = true;
						switch (t) {
						    case "VentNote":
                                GameManager.clickMap[t]++;
                                Debug.Log(GameManager.clickMap[t]);
							    eventManager.Popup(t);
							    break;
						    case "Back":
							    Application.LoadLevel("GameScene");
							    GameManager.scene = 1;
                                GameManager.isInVent = false;
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
                            if (GameManager.clickMap["LightSwitch"] >= 2 
                            && GameManager.clickMap["Newspaper"] >= 1 
                            && GameManager.clickMap["Note"] >= 2
                            && GameManager.popup) {
                                eventManager.BoxFall();
                                GameManager.ResetDict();
                            }
                        }
                        break;

                    // Stage 2  -   Laptop Static
                    case 2:
                        if (GameManager.clickMap["LightSwitch"] >= 3) {
                            eventManager.LaptopStatic();
                            GameManager.ResetDict();
                        }
                        break;

                    // Stage 3  -   Blackout / Night adventure / Picture change
                    case 3:
                        if (GameManager.clickMap["LightSwitch"] >= 1
                        && GameManager.clickMap["Newspaper"] >= 1
                        && GameManager.clickMap["Note"] >= 1) {
                            GameManager.lightsOff = true;
                            eventManager.LightSwitch();
                            GameManager.ResetDict();
                        }
                        break;

                    // Stage 4  -   Vent system (opens when entering the boxScene)
                    case 4:
                        if (GameManager.clickMap["LightSwitch"] >= 1
                        && GameManager.clickMap["Newspaper"] >= 1
                        && GameManager.clickMap["Note"] >= 1
                        && GameManager.isInBox) {
                            eventManager.VentOpen();
                            GameManager.ResetDict();
                        }
                        break;

                    // Stage 5  -   Vent note jumpscare
                    case 5:
                        if (GameManager.scene == 3
                        && GameManager.clickMap["VentNote"] >= 1
                        && !GameManager.popup) {
                            eventManager.SpawnCreep();
                            GameManager.stage = 6;
                            GameManager.ResetDict();
                        }
                        break;

                    // Stage 6  -   Endgame
                    case 6:
                        if (GameManager.scene == 1 
                        && GameManager.clickMap["LightSwitch"] >= 1 
                        && GameManager.clickMap["Newspaper"] >= 1
                        && GameManager.clickMap["Note"] >= 1
                        && GameManager.clickMap["PhotoBoyButton"] >= 1
                        && GameManager.clickMap["PhotoCerysButton"] >= 1
                        && GameManager.clickMap["PhotoSusanButton"] >= 1) {
                            eventManager.EndGameJumpscare();
                        }
                        break;
                }


            }
        }

    }


}