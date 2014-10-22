using UnityEngine;
using System.Collections;

public class MuteButton : MonoBehaviour {

	public Sprite unMuted;
	public Sprite muted;

	public GameObject soundPlayer;
	private bool isPaused;

	void Start()
	{
		gameObject.GetComponent<SpriteRenderer> ().sprite = unMuted;
		isPaused = false;
	}

	void OnTouchUp(){
		Debug.Log ("User toggled mute");

		if (!isPaused) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = muted;
			isPaused = true;
		} else {
			gameObject.GetComponent<SpriteRenderer> ().sprite = unMuted;
			isPaused = false;
		}

		GameObject.Find ("SceneAudioManager").SendMessage ("TogglePause");
	}
	
	//	public void MuteAudio(){
	//
	//		gameObject.audio.mute = true;
	//
	//
	//
	////		if (gameObject.audio.mute)
	////			gameObject.audio.mute = false;
	////		//gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load("Media-Controls-Volume-Up-icon", typeof(Sprite)) as Sprite;
	////		
	////		else {
	////			gameObject.audio.mute= true;
	////			//	gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load("Media-Controls-Mute-icon", typeof(Sprite)) as Sprite;
	////			
	////		}
	//
	//	}
}
