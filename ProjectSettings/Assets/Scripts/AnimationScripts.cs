using UnityEngine;
using System.Collections;

public class AnimationScripts : MonoBehaviour {


	public float timer;
	public bool isTiming = false;


	void Start()
	{
		beginTimer ();
	}

//	6 o clock in the morning and I just want a damn timed event to work


	void beginTimer()
	{
		timer = 0;
		isTiming = true;
	}
	void Update(){
		if(isTiming)
		{
			timer += Time.deltaTime;
		}
		if (timer > 6.5)
		{
			EndTimer();
				Application.LoadLevel ("Tut_Level1");
		}
	}
	void EndTimer(){
		isTiming = false;
	}

}

