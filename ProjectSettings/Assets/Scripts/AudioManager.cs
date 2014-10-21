using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public string [] audioNames;
	public AudioClip [] audioClips;
	public bool clipFound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	
			if (Input.GetKeyDown(KeyCode.Space))
				if (audio.mute)
					audio.mute = false;
			else
				audio.mute = true;
			

		
	}
	
	public void PlayMusic(string clipName){
		
		for (int i = 0; i < audioNames.Length; i++) {
		
				if(clipName == audioNames[i]) {
					
					gameObject.audio.clip = audioClips[i];
					gameObject.audio.Play();
					clipFound = true;
					DontDestroyOnLoad(this.gameObject);
				break;
				}
					else {
						clipFound = false;
					}
			}

	if (!clipFound) 
		Debug.Log ("Audioclip not found");


	}


}
