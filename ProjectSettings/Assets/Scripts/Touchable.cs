using UnityEngine;
using System.Collections;

public class Touchable : MonoBehaviour {

	// Store information about objects in here.
	public string information;

	public bool isTouched = false;
	public bool isInspected = false;
	public bool isTalked = false;

	public GameObject[] actions;

	// Colors defined in editor
	public Color defaultColor;
	public Color selectedColor;
	private Material mat;
	public bool isInstantiated;

	
	void Start(){
	}

	void OnTouchDown(){
	}

	// This is the main thing where stuff happens
	void OnTouchUp(){
		float add = 2.0f;
		if (!isInstantiated && actions.Length > 0) {
			foreach (GameObject action in actions) {
				GameObject actionInstance = Instantiate (action, new Vector2 (transform.position.x + add, transform.position.y + 1.5f), Quaternion.identity) as GameObject;
				actionInstance.transform.parent = gameObject.transform;
				add += 1.8f;
			}

			gameObject.collider.enabled = false;

			isInstantiated = true;

			InteractiveAudioManager.audioManager.PlaySound("blop");

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

	void setInspected(bool val){
		isInspected = val;
	}

	void setTouched(bool val){
		isTouched = val;
	}

	void setTalked(bool val){
		isTalked = val;
	}

}
