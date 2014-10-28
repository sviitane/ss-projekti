using UnityEngine;
using System.Collections;

public class ActionButton : MonoBehaviour {

	void Start(){
	}

	void OnTouchUp(){
		Debug.Log ("Touched");
		//gameObject.GetComponentInParent().SendMessage ("notInstantiated");

		Destroy (gameObject);
		
	}
}
