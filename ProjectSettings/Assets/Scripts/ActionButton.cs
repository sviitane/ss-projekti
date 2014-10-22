using UnityEngine;
using System.Collections;

public class ActionButton : MonoBehaviour {

	void Start(){
		Hide ();
	}

	void OnTouchUp(){
		Debug.Log ("Touched");
		Hide ();
	}

	public void Show(){
		renderer.enabled = true;
		collider.enabled = true;
	}

	public void Hide(){
		renderer.enabled = false;
		collider.enabled = false;
	}
}
