using UnityEngine;
using System.Collections;

public class ScrollableView : MonoBehaviour {


	Vector2 scrollPosition;
	Touch touch;
	// The string to display inside the scrollview. 2 buttons below add & clear this string.
	string longString = "This is a long-ish string";

	void OnGUI () { 

		TextHandler.textHandler.LoadText ("MyTest1.txt");

		scrollPosition = GUI.BeginScrollView(new Rect(90,20,130,150),scrollPosition, new Rect(90,20,130,560),GUIStyle.none,GUIStyle.none);

		GUI.Box (new Rect(90, 20, 500, 200), TextHandler.textHandler.lines);

		GUI.EndScrollView ();
	}
	
	void Update()
	{
		if(Input.touchCount > 0)
		{
			touch = Input.touches[0];
			if (touch.phase == TouchPhase.Moved)
			{
				scrollPosition.y += touch.deltaPosition.y;
			}
		}
	}
}
