using UnityEngine;
using System.Collections;

public class Touchable : MonoBehaviour {

	public GameObject[] actions;

	// Colors defined in editor
	public Color defaultColor;
	public Color selectedColor;
	private Material mat;
	
	void Start(){
	}

	void OnTouchDown(){
	}

	// This is the main thing where stuff happens
	void OnTouchUp(){
		foreach (GameObject action in actions){
			action.transform.position = new Vector2(transform.position.x + 3f, transform.position.y);
			action.SendMessage("Show");
		}
	}

	void OnTouchStay(){
	}

	void OnTouchExit(){
	}

}
