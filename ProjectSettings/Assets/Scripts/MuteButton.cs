using UnityEngine;
using System.Collections;

public class MuteButton : MonoBehaviour {

	bool isMuted = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}

	public void MuteAudio(string tagname){

			if (!isMuted){
			isMuted= true;
			}
			else {
			isMuted = false;
			}
			
		var music = GameObject.FindGameObjectWithTag(tagname);

		music.audio.mute= isMuted;

	}


	
	void OnTouchDown(){

		Debug.Log ("User touched " + this.name);
		Debug.Log ("Make something happen");
	}
	
	void OnTouchUp(){
	
		Debug.Log ("Mutebutton on state: " + isMuted);

		MuteAudio("menuMusic");

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
