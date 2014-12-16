using UnityEngine;
using System.Collections;
public class ActionButton : MonoBehaviour {

	// A string specified in editor that is sent to the guiloader when this element is clicked
	public string clickString;

	// ActionFlag is a specifig flag to determine which action we are using. We might need to know this for some actions
	public string actionFlag;

	// If we want to remove this action from the parents action list after it's been clicked
	public bool removeActionAfterUse;

	// If we want this action to trigger part of the story
	public bool isStoryTrigger { get; set; }

	void Start(){
	}

	void OnTouchDown(){
		transform.localScale = new Vector3 (transform.localScale.x + 0.02f, transform.localScale.y + 0.02f, transform.localScale.z);
	}

	void OnTouchExit(){
		transform.localScale = new Vector3 (transform.localScale.x - 0.02f, transform.localScale.y - 0.02f, transform.localScale.z);
	}

	void OnTouchUp(){
		if (gameObject.transform.parent) {
			Transform[] listOfActions = gameObject.transform.parent.GetComponentsInChildren<Transform> ();

			// When we click the action, we send notInstantiated message to the parent to allow the actions to be instantiated again.
			gameObject.transform.parent.SendMessage ("notInstantiated");
			if (listOfActions.Length > 1) {
				foreach (Transform t in listOfActions) {
					if (!t.Equals (gameObject.transform.parent.transform)) {
							Debug.Log ("Destroying " + t.gameObject.name);
							Destroy (t.gameObject);
					}
				}
			} else {
				Debug.LogError ("No actions as child element!");
			}

			if(GuiLoader.loader && !isStoryTrigger){
				if(actionFlag == "Inspect"){
					// See if parent is touchable
					if(gameObject.transform.parent.GetComponent<Touchable>()){
						string info = gameObject.transform.parent.GetComponent<Touchable>().information;
						GuiLoader.loader.changeText(clickString + info);
					}else{
						// This should never happen
						Debug.Log("Parent is not touchable");
					}
					gameObject.transform.parent.SendMessage("setInspected", true);
				}else if(actionFlag == "Talk"){
					GuiLoader.loader.changeText(clickString);
					gameObject.transform.parent.SendMessage("setTalked", true);
				}else if(actionFlag == "Touch"){
					GuiLoader.loader.changeText(clickString);
					gameObject.transform.parent.SendMessage("setTouched", true);
                }
			}else if(isStoryTrigger){
				GuiLoader.loader.storyMode = true;
				if(actionFlag == "Inspect"){
					gameObject.transform.parent.SendMessage("setInspected", true);
				}else if(actionFlag == "Talk"){
					gameObject.transform.parent.SendMessage("setTalked", true);
				}else if(actionFlag == "Touch"){
					gameObject.transform.parent.SendMessage("setTouched", true);
				}
			}
            
		} else {
			Debug.LogWarning("Action is not connected to a parent");
		}
		transform.localScale = new Vector3 (transform.localScale.x - 0.02f, transform.localScale.y - 0.02f, transform.localScale.z);
		InteractiveAudioManager.audioManager.PlaySound ("blop");
	}
}
