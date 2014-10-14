using UnityEngine;
using System.Collections;

public class ExitButton : MonoBehaviour {

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
	void OnTouchUp(){
		mat.color = defaultColor;
		Application.Quit();
	}
	void OnTouchStay(){
		mat.color = selectedColor;
	}
	void OnTouchExit(){
		mat.color = defaultColor;
	}
}
