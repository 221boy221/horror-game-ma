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
                                eventManager.LaptopStatic();
                                break;
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
                                    GameManager.scene++;
                                    Application.LoadLevel("InsideBox");
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
                                GameManager.stage = 2;
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
                    // Stage 1
                    case 1:
                        if (!GameManager.boxClickable) {
                            if (GameManager.clickMap["LightSwitch"] >= 3 && GameManager.clickMap["Newspaper"] >= 3 && GameManager.clickMap["Note"] >= 2) {
                                eventManager.BoxFall();
                            }
                        }
                        break;
                    // Stage 2
                    case 2:
                        if (GameManager.clickMap["LightSwitch"] >= 10 && GameManager.clickMap["Newspaper"] >= 5 && GameManager.clickMap["Note"] >= 5) {
                            eventManager.LaptopStatic();
                        }
                        break;
                    // Stage 3
                    case 3:

                        break;
                }


            }
        }

    }


}