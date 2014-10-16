using UnityEngine;
using System.Collections;

public class Touchable : MonoBehaviour {

	public Color defaultColor;
	public Color selectedColor;
	private Material mat;
	
	void Start(){
		mat = renderer.material;
		mat.color = defaultColor;
	}
	
	void OnTouchDown(){
		mat.color = selectedColor;
		Debug.Log ("User touched " + this.name);
		Debug.Log ("Make something happen");
	}
	void OnTouchUp(){
		mat.color = defaultColor;
	}
	void OnTouchStay(){
		mat.color = selectedColor;
	}
	void OnTouchExit(){
		mat.color = defaultColor;
	}
}
