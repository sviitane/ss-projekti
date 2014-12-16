using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public static AudioManager audioManager;

	public string [] audioNames;
	public AudioClip [] audioClips;
	public bool clipFound;

	public bool isPaused;
	private string playingClip;

	void Awake(){
		if (audioManager == null) {
			DontDestroyOnLoad (gameObject);
			audioManager = this;
		} else if (audioManager != this) {
			Destroy (gameObject);
		}
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(Application.loadedLevelName == "Menu")
			PlayMusic ("menuMusic");
		else if(Application.loadedLevelName == "Tut_Level1")
			PlayMusic ("stars");
		else if(Application.loadedLevelName == "Tut_Level2")
			PlayMusic ("thunder");
		else if(Application.loadedLevelName == "Level1")
			PlayMusic ("ode");
	}
	
	public void PlayMusic(string clipName){
		//Only play music if it is not already playing
		if (playingClip != clipName && !isPaused) {
			for (int i = 0; i < audioNames.Length; i++) {
			
				// Find audio clip by name
				if(clipName == audioNames[i]) {
					gameObject.audio.clip = audioClips[i];
					gameObject.audio.volume = 0.05f;
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

	public void TogglePause()
	{
		if (!isPaused && gameObject.audio.isPlaying)
		{
			gameObject.audio.Pause ();
			isPaused = true;
		}
		else
		{
			gameObject.audio.Play ();
			isPaused = false;
		}
	}
}
