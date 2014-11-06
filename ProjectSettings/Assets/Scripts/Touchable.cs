using UnityEngine;
using System.Collections;

[System.Serializable]
public class Action{
	public GameObject actionObject;
	public string actionFlag;
	public string clickText;
}

public class Touchable : MonoBehaviour {

	// Text that is displayed when this object is clicked
	public string clickText;

	// Store information about objects in here.
	public string information;

	// Currently its easier to set the starting text in objects like this, but this should be done better.
	public string startText;
    
	public bool isTouched = false;
	public bool isInspected = false;
	public bool isTalked = false;

	public Action[] actions;
	//public GameObject[] actions;

	// Colors defined in editor
	public Color defaultColor;
	public Color selectedColor;
	private Material mat;
	public bool isInstantiated;

	
	void Start(){
		GuiLoader.loader.changeText (startText);
		GuiLoader.loader.mapCleared = false;
	}

	void Update(){

		//TODO: This has to be made dynamic, so that we can define what actions complete the map, currently all actions have to be done
		if(isTouched && isInspected && isTalked){
			GuiLoader.loader.mapCleared = true;

		}
	}

	void OnTouchDown(){
	}

	// This is the main thing where stuff happens
	void OnTouchUp(){
		float add = 1.0f;
		//Instantiate all listed actions 1.5f up and 1 + 1.5f between each other
		if (!isInstantiated && actions.Length > 0) {
			foreach (Action action in actions) {
				GameObject actionInstance = Instantiate (action.actionObject, new Vector2 (transform.position.x + add, transform.position.y + 1.5f), Quaternion.identity) as GameObject;
				actionInstance.transform.parent = gameObject.transform;
				actionInstance.GetComponent<ActionButton>().actionFlag = action.actionFlag;
				actionInstance.GetComponent<ActionButton>().clickString = action.clickText;
				add += 1.5f;
			}

			// Disable collider for touchable object after it has been clicked to avoid confusion
			gameObject.collider.enabled = false;

			// Make sure that the actions do not get instantiated again
			isInstantiated = true;

			// Check that IA audiomanager exists and play sound when clicking
			if(InteractiveAudioManager.audioManager){
				InteractiveAudioManager.audioManager.PlaySound("blop");
			}

			// Check that guiloader exists and clickText exists, and if it does, change the text.
			if(GuiLoader.loader && clickText != "" && clickText != null){
				GuiLoader.loader.changeText(clickText);
			}else if(clickText == "" || clickText == null){
				Debug.LogWarning("No click text specified for TouchableElement" + gameObject.name);
			}else{
				Debug.LogError("GuiLoader does not exist");
			}

		} else {
			Debug.LogError("GameObject" + gameObject.name + " has no actions specified!");
		}
	}

	void OnTouchStay(){
	}

	void OnTouchExit(){
	}

	void notInstantiated(){
		gameObject.collider.enabled = true;
		isInstantiated = false;
	}

	// Setter methods for completing different actions in case we need these.

	public void setInspected(bool val){
		isInspected = val;
	}

	public void setTouched(bool val){
		isTouched = val;
	}

	public void setTalked(bool val){
		isTalked = val;
	}

}
