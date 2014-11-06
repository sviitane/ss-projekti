using UnityEngine;
using System.Collections;

public class ActionButton : MonoBehaviour {

	void Start(){
	}

	void OnTouchDown(){
		transform.localScale = new Vector3 (transform.localScale.x + 0.02f, transform.localScale.y + 0.02f, transform.localScale.z);
	}

	void OnTouchExit(){
		transform.localScale = new Vector3 (transform.localScale.x - 0.02f, transform.localScale.y - 0.02f, transform.localScale.z);
	}

	void OnTouchUp(){
		Transform[] listOfActions = gameObject.transform.parent.GetComponentsInChildren<Transform>();
		gameObject.transform.parent.SendMessage ("notInstantiated");
		if (listOfActions.Length > 1) {
			foreach (Transform t in listOfActions) {
				if (!t.Equals (gameObject.transform.parent.transform)) {
					Debug.Log ("Destroying " + t.gameObject.name);
					Destroy (t.gameObject);
				}
			}
		} else {
			Debug.LogError("No actions as child element!");
		}
		transform.localScale = new Vector3 (transform.localScale.x - 0.02f, transform.localScale.y - 0.02f, transform.localScale.z);
		InteractiveAudioManager.audioManager.PlaySound ("blop");
	}
}
