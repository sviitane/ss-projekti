using UnityEngine;
using System.Collections;

public class InteractiveAudioManager : MonoBehaviour {

	public static InteractiveAudioManager audioManager;
	
	public string [] audioNames;
	public AudioClip [] audioClips;
	public bool clipFound;
	
	private bool isPaused;
	private string playingClip;
	
	void Awake(){
		if (audioManager == null) {
			DontDestroyOnLoad (gameObject);
			audioManager = this;
		} else if (audioManager != this) {
			Destroy (gameObject);
		}
	}

	public void PlaySound(string clipName){
		if (!AudioManager.audioManager.isPaused) {
			for (int i = 0; i < audioNames.Length; i++) {
				
				// Find audio clip by name
				if(clipName == audioNames[i]) {
					gameObject.audio.clip = audioClips[i];
					gameObject.audio.volume = 0.5f;
					gameObject.audio.Play();
					clipFound = true;
					playingClip = clipName;
					break;
				}
				else
				{
					clipFound = false;
				}
			}
			
			if (!clipFound)
			{
				Debug.Log ("Audioclip not found");
			}
		}
	}
}
