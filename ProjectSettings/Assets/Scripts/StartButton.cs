using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {

	public Color defaultColor;
	public Color selectedColor;
	private Material mat;
	
	void Start(){
		mat = renderer.material;
		mat.color = defaultColor;
	}
	
	void OnTouchDown(){
		mat.color = selectedColor;
		Debug.Log ("User clicked " + this.name);
	}
	void OnTouchUp(){
		mat.color = defaultColor;
		Debug.Log ("Changing map");
		InteractiveAudioManager.audioManager.PlaySound ("blop");
		Application.LoadLevel ("Tut_Level1");
	}
	void OnTouchStay(){
		mat.color = selectedColor;
	}
	void OnTouchExit(){
		mat.color = defaultColor;
	}
}
