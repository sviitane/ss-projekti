using UnityEngine;
using System.Collections;

public class Transitioner : MonoBehaviour {

	// this class is used to start story mode in intro after the animation

	public string introText;

	public AudioClip boom;
	
	public void PlayBoom(){
		gameObject.audio.clip = boom;
		gameObject.audio.Play ();
	}

	public void Transition(){
		GuiLoader.loader.mapCleared = true;
		GuiLoader.loader.text = introText;
	}

}
