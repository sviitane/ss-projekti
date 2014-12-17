using UnityEngine;
using System.Collections;

public class AnimationScripts : MonoBehaviour {


	public float timer;
	public bool isTiming = false;


	void Start()
	{
		beginTimer ();
	}

//	// 6 o clock in the morning and I just want a damn timed event to work
//	void Update()
//	{
//		timeLeft -= Time.deltaTime;
//		if(timeLeft < 0)
//		{
//			Application.LoadLevel ("Tut_Level1");
//		}
//
//	}

	void beginTimer()
	{
		timer = 0;
		isTiming = true;
	}
	void Update(){
		if(isTiming)
		{
			//+= is the same thing as adding to the current variable
			//timer = timer + time.delatime is the same thing as time +=... its just faster to use +=
			timer += Time.deltaTime;
		}
		if (timer > 7)
		{
			EndTimer();
				Application.LoadLevel ("Tut_Level1");
		}
	}
	void EndTimer(){
		isTiming = false;
	}

	
}

