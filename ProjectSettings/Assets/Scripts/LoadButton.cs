using UnityEngine;
using System.Collections;

public class LoadButton : MonoBehaviour {

	public Color defaultColor;
	public Color selectedColor;
	private Material mat;
	
	void Start(){
		gameObject.GetComponent<MeshRenderer> ().sortingLayerName = "Foreground";
		gameObject.GetComponent<MeshRenderer> ().sortingOrder = 1;

		if (GameControl.control.fileExists ()) {
			transform.renderer.enabled = true;
			transform.collider.enabled = true;
			mat = renderer.material;
			mat.color = defaultColor;
		}else{
			transform.renderer.enabled = false;
			transform.collider.enabled = false;
		}
	}
	
	void OnTouchDown(){
		mat.color = selectedColor;
		Debug.Log ("User clicked " + this.name);
	}
	void OnTouchUp(){
		mat.color = defaultColor;
		Debug.Log ("Changing map");
		InteractiveAudioManager.audioManager.PlaySound ("blop");

		// Load saved data
		GameControl.control.Load ();
	}
	void OnTouchStay(){
		mat.color = selectedColor;
	}
	void OnTouchExit(){
		mat.color = defaultColor;
	}
}
