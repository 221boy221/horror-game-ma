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
            GameManager.clickMap.Add("LightSwitch", 0);
            GameManager.clickMap.Add("Newspaper", 0);
            GameManager.clickMap.Add("Note", 0);
            GameManager.clickMap.Add("PhotoBoyButton", 0);
            GameManager.clickMap.Add("PhotoCerysButton", 0);
            GameManager.clickMap.Add("PhotoSusanButton", 0);
            GameManager.clickMap.Add("Box", 0);
            GameManager.clickMap.Add("Vent", 0);
            GameManager.clickMap.Add("VentNote", 0);
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
                        //Debug.Log("S1 Clicked on: " + t);
                        switch (t) {
                            case "LightSwitch":
                                GameManager.clickMap[t]++;
                                Debug.Log(GameManager.clickMap[t]);
                                eventManager.LightSwitch();
                                if (GameManager.stage == 3 || GameManager.stage == 4 || GameManager.stage == 6) {
                                    GameManager.lightSwitchClicked = true;
                                }
                                break;
                            case "Newspaper":
                                GameManager.clickMap[t]++;
                                Debug.Log(GameManager.clickMap[t]);
                                eventManager.Popup(t);
                                if (GameManager.stage == 3 || GameManager.stage == 4 || GameManager.stage == 6) {
                                    GameManager.newspaperClicked = true;
                                }
                                break;
                            case "Note":
                                GameManager.clickMap[t]++;
                                Debug.Log(GameManager.clickMap[t]);
                                eventManager.Popup(t);
                                if (GameManager.stage == 3 || GameManager.stage == 4 || GameManager.stage == 6) {
                                    GameManager.noteClicked = true;
                                }
                                break;
                            case "PhotoBoyButton":
                                GameManager.clickMap[t]++;
                                Debug.Log(GameManager.clickMap[t]);
                                eventManager.Popup(t);
                                if (GameManager.stage == 6) {
                                    GameManager.photoBoyClicked = true;
                                }
                                break;
                            case "PhotoCerysButton":
                                GameManager.clickMap[t]++;
                                Debug.Log(GameManager.clickMap[t]);
                                eventManager.Popup(t);
                                if (GameManager.stage == 6) {
                                    GameManager.photoCerysClicked = true;
                                }
                                break;
                            case "PhotoSusanButton":
                                GameManager.clickMap[t]++;
                                Debug.Log(GameManager.clickMap[t]);
                                eventManager.Popup(t);
                                if (GameManager.stage == 6) {
                                    GameManager.photoSusanClicked = true;
                                }
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
                        if (GameManager.lightSwitchClicked && GameManager.newspaperClicked && GameManager.noteClicked && GameManager.isInBox) {
                            // TODO: vent open sfx
                            GameManager.ventClickable = true;
                            Debug.Log("Stage 4  -   Vent system");
                        }
                        break;
                    case 5:
                        if (GameManager.scene == 3 && GameManager.clickMap["VentNote"] >= 1 && !GameManager.popup) {
                            eventManager.SpawnCreep();
                            Debug.Log("case 5, scene is 3, popup true.");
                            GameManager.stage = 6;
                            GameManager.lightSwitchClicked = GameManager.newspaperClicked = GameManager.noteClicked = false;
                        }
                        break;
                    case 6:
                        Debug.Log("=- stage 6 -=");
                        Debug.Log(GameManager.scene);
                        Debug.Log(GameManager.lightSwitchClicked);
                        Debug.Log(GameManager.newspaperClicked);
                        Debug.Log(GameManager.noteClicked);
                        Debug.Log(GameManager.photoBoyClicked);
                        Debug.Log(GameManager.photoCerysClicked);
                        Debug.Log(GameManager.photoSusanClicked);
                        if (GameManager.scene == 1 && GameManager.lightSwitchClicked && GameManager.newspaperClicked && GameManager.noteClicked && GameManager.photoBoyClicked && GameManager.photoCerysClicked && GameManager.photoSusanClicked) {
                            eventManager.EndGameJumpscare();
                        }
                        break;
                }


            }
        }

    }


}