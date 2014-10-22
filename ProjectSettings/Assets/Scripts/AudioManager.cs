using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public string [] audioNames;
	public AudioClip [] audioClips;
	public bool clipFound;

	private bool isPaused;

	// Use this for initialization
	void Start () {
		if(Application.loadedLevelName == "Menu")
			PlayMusic ("menuMusic");
		else if(Application.loadedLevelName == "Tut_Level1")
			PlayMusic ("Today");
		else if(Application.loadedLevelName == "Tut_Level2")
			PlayMusic ("WayOfThe");
		isPaused = false;
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	public void PlayMusic(string clipName){
		
		for (int i = 0; i < audioNames.Length; i++) {
		
			// Find audio clip by name
			if(clipName == audioNames[i]) {
				gameObject.audio.clip = audioClips[i];
				gameObject.audio.volume = 0.13f;
				gameObject.audio.Play();
				clipFound = true;
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

	public void TogglePause()
	{
		if (!isPaused)
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
