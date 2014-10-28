using UnityEngine;
using System.Collections;

public class Touchable : MonoBehaviour {

	public GameObject[] actions;

	// Colors defined in editor
	public Color defaultColor;
	public Color selectedColor;
	private Material mat;
	private bool isInstantiated;

	
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

}
