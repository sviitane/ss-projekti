using UnityEngine;
using System.Collections;

public class Touchable : MonoBehaviour {

	// Colors defined in editor
	public Color defaultColor;
	public Color selectedColor;
	private Material mat;
	
	void Start(){
		mat = renderer.material;
		mat.color = defaultColor;
	}

	void OnTouchDown(){
		mat.color = selectedColor;
	}

	// This is the main thing where stuff happens
	void OnTouchUp(){
		mat.color = defaultColor;
		Debug.Log ("User touched " + this.name);
		Debug.Log ("Make something happen");
	}
	void OnTouchStay(){
		mat.color = selectedColor;
	}
	void OnTouchExit(){
		mat.color = defaultColor;
	}
}
