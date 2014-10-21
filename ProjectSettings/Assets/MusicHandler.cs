using UnityEngine;
using System.Collections;

public class MusicHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		if (Application.loadedLevelName.Equals("Tut_Level1")) {
			
			SendMessage ("PlayMusic", "Today");
		}
	}
		
	// Update is called once per frame
	void Update () {
	

	//	if (Input.GetKeyDown (KeyCode.Q)) {
	//			
	//		SendMessage("PlayMusic","Today");
	//
	//	}

	}

	void OnLevelWasLoaded(int level) {
		//level == 2 is same as tut_level2
		if (level == 2)
			SendMessage ("PlayMusic", "WayOfThe");
		
	}

}
