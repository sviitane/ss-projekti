using UnityEngine;
using System.Collections;

public class GuiLoader : MonoBehaviour {
	public Font f;

	public string text;

	void OnGUI(){
		if (!f) {
			Debug.LogError("No Font found, add one in inspector");
			return;
		}

		GUI.Box (new Rect (120, 20, 340, 120), "Action");
		GUI.Label (new Rect (125, 40, 335, 115), text);


		/*
		GUILayout.BeginArea (new Rect (120, 20, 300, 200));

		GUILayout.BeginHorizontal ();

		GUI.skin.font = f;

		GUILayout.Label (text);

		GUILayout.EndHorizontal ();

		GUILayout.EndArea ();
		*/
	}

	public void changeText(string newtext){
		Debug.Log ("Text changed");
		this.text = newtext;
	}
}
