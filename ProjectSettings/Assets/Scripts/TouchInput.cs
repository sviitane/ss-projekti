using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TouchInput : MonoBehaviour {

	//TODO: Add this to a persistent object that goes through all scenes without being destroyed.
	public bool isTutorial = true;
	public LayerMask touchInputMask;
	private bool tutorialClear = false;
	// In this list, we put the touches that are currently happening
	private List<GameObject> touchList = new List<GameObject>();

	private bool touchedCat = false;
	private bool inspectedCat = false;
	private bool talkedCat = false;

	// We save old touches in this list, because there are situations where touch should be exited
	// but you cant just check if touch has ended. (You press a button, but slide your finger off the button,
	// then the button is no longer pressed but you are still touching the screen)
	private GameObject[] touchesOld;

	private RaycastHit hit;

	// Update is called once per frame
	void Update () {

#if UNITY_EDITOR
		// Only run this code if the screen has been touched
		if(Input.GetMouseButton(0) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0)){
			// Save all touches in the old list
			touchesOld = new GameObject[touchList.Count];
			touchList.CopyTo(touchesOld);
			touchList.Clear();
			Ray ray = camera.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray, out hit, touchInputMask)){
				GameObject recipient = hit.transform.gameObject;
				Debug.Log("Click recipient: " + recipient.name);
				changeGuiText(recipient);
				// Add the touch to our touchList
				touchList.Add (recipient);
				
				if(Input.GetMouseButtonDown(0)){
					recipient.SendMessage("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
				}
				
				if(Input.GetMouseButtonUp(0)){
					recipient.SendMessage("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver);
				}
				
				if(Input.GetMouseButton(0)){
					recipient.SendMessage("OnTouchStay", hit.point, SendMessageOptions.DontRequireReceiver);
				}
			}
			/*
			foreach(GameObject g in touchesOld){
				if(!touchList.Contains(g)){
					g.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
				}
			}
			*/
		}
#endif

		// Only run this code if the screen has been touched
		if(Input.touchCount > 0){

			// Save all touches in the old list
			touchesOld = new GameObject[touchList.Count];
			touchList.CopyTo(touchesOld);
			touchList.Clear();

			foreach (Touch touch in Input.touches) {
				Ray ray = camera.ScreenPointToRay(touch.position);
				if(Physics.Raycast(ray, out hit, touchInputMask)){
					GameObject recipient = hit.transform.gameObject;
					// Add the touch to our touchList
					touchList.Add (recipient);

					changeGuiText(recipient);

					if(touch.phase == TouchPhase.Began){
						recipient.SendMessage("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
					}

					if(touch.phase == TouchPhase.Ended){
						recipient.SendMessage("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver);
					}

					if(touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved){
						recipient.SendMessage("OnTouchStay", hit.point, SendMessageOptions.DontRequireReceiver);
					}

					if(touch.phase == TouchPhase.Canceled){
						recipient.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
					}

				}
			}

			foreach(GameObject g in touchesOld){
				if(!touchList.Contains(g)){
					g.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
				}
			}
		}
	}

	private void changeGuiText(GameObject recipient){
	// A framework for changing the gui text in our tutorial.
		Debug.Log ("Attempting to change text");
		GameObject gui = GameObject.Find ("GUILoader") as GameObject;
		if (gui != null) {
			string info = "";
		
			if(recipient.GetComponent<Touchable>() != null){
				info = recipient.GetComponent<Touchable> ().information;
				touchedCat = recipient.GetComponent<Touchable>().isTouched;
				inspectedCat = recipient.GetComponent<Touchable>().isInspected;
				talkedCat = recipient.GetComponent<Touchable>().isTalked;
			}

			//Ghost cat
			if (recipient.name == "GhostCat") {
				gui.SendMessage ("changeText", "Congratulations, you clicked the cat. Now some actions have appeared next to the cat, you can try to click these actions and see what happens.");
			}else if(recipient.tag == "Inspect" && recipient.transform.parent.name == "GhostCat" && !inspectedCat){
				gui.SendMessage ("changeText", "Well done, you clicked the Inspect action, inspecting usually reveals information about the touched object, this cat has following information: " + info);
				recipient.transform.parent.SendMessage("setInspected", true);
				inspectedCat=true;
			}else if(recipient.tag == "Talk" && recipient.transform.parent.name == "GhostCat" && !talkedCat){
				gui.SendMessage("changeText", "You talked to the cat... The cat does not seem to react.");
				recipient.transform.parent.SendMessage("setTalked", true);	
				talkedCat = true;
			}else if(recipient.tag == "Touch" && recipient.transform.parent.name == "GhostCat" && !touchedCat){
				gui.SendMessage("changeText", "You touched the cat, the cat seems to be friendly.");
				recipient.transform.parent.SendMessage("setTouched", true);
				touchedCat = true;
			}else if(touchedCat &&  inspectedCat && talkedCat){
			//	StartCoroutine(WaitForAction(10));
				gui.SendMessage("changeText", "Congratulations, you have learned the basic actions in this game! You are ready to move to the next place. Click on the arrow to move.");
				if(!tutorialClear){
					AddExperience(30);
					tutorialClear = true;
				}
			}

		} else {
			Debug.LogError("No GUILoader element in the scene!");
		}
	}

	public void AddExperience(int exp){
		GameControl.control.experience += exp;

	}

	//did not work... tried to create a timer event
//	public IEnumerator  WaitForAction(int seconds){
//		yield return new WaitForSeconds (seconds);
//		yield break;
//	}
}
