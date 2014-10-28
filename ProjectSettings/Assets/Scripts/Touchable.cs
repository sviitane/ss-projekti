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



	
		if (!isInstantiated)
		    {

		foreach (GameObject action in actions) {
						
			Instantiate (action, new Vector2 (transform.position.x + 3f, transform.position.y), Quaternion.identity);
						
			}
			isInstantiated = true;
		}
	}

	void OnTouchStay(){
	}

	void OnTouchExit(){
	}

	void notInstantiated(){
		isInstantiated = false;
	}

}
