using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TouchInput : MonoBehaviour {

	//TODO: Add this to a persistent object that goes through all scenes without being destroyed.
	public bool isTutorial = true;

	public LayerMask touchInputMask;
	// In this list, we put the touches that are currently happening
	private List<GameObject> touchList = new List<GameObject>();

	// We save old touches in this list, because there are situations where touch should be exited
	// but you cant just check if touch has ended. (You press a button, but slide your finger off the button,
	// then the button is no longer pressed but you are still touching the screen)
	private GameObject[] touchesOld;

	private RaycastHit hit;

	// Update is called once per frame
	void Update () {

#if UNITY_EDITOR
		// Only run this code if the screen has been touched
		if(Input.GetMouseButton(0) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0)){
			// Save all touches in the old list
			touchesOld = new GameObject[touchList.Count];
			touchList.CopyTo(touchesOld);
			touchList.Clear();
			Ray ray = camera.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray, out hit, touchInputMask)){
				GameObject recipient = hit.transform.gameObject;
				Debug.Log("Click recipient: " + recipient.name);
				// Add the touch to our touchList
				touchList.Add (recipient);
				
				if(Input.GetMouseButtonDown(0)){
					recipient.SendMessage("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
				}
				
				if(Input.GetMouseButtonUp(0)){
					recipient.SendMessage("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver);
				}
				
				if(Input.GetMouseButton(0)){
					recipient.SendMessage("OnTouchStay", hit.point, SendMessageOptions.DontRequireReceiver);
				}
			}
			/*
			foreach(GameObject g in touchesOld){
				if(!touchList.Contains(g)){
					g.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
				}
			}
			*/
		}
#endif

		// Only run this code if the screen has been touched
		if(Input.touchCount > 0){

			// Save all touches in the old list
			touchesOld = new GameObject[touchList.Count];
			touchList.CopyTo(touchesOld);
			touchList.Clear();

			foreach (Touch touch in Input.touches) {
				Ray ray = camera.ScreenPointToRay(touch.position);
				if(Physics.Raycast(ray, out hit, touchInputMask)){
					GameObject recipient = hit.transform.gameObject;
					// Add the touch to our touchList
					touchList.Add (recipient);

					if(touch.phase == TouchPhase.Began){
						recipient.SendMessage("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
					}

					if(touch.phase == TouchPhase.Ended){
						recipient.SendMessage("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver);
					}

					if(touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved){
						recipient.SendMessage("OnTouchStay", hit.point, SendMessageOptions.DontRequireReceiver);
					}

					if(touch.phase == TouchPhase.Canceled){
						recipient.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
					}

				}
			}

			foreach(GameObject g in touchesOld){
				if(!touchList.Contains(g)){
					g.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
				}
			}
		}
	}
}
