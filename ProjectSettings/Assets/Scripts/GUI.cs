using UnityEngine;
using System.Collections;

public class GUI : MonoBehaviour {
	public string text;

	void OnGUI(){
		GUILayout.BeginArea (new Rect (120, 20, 300, 200));

		GUILayout.BeginHorizontal ();

		GUILayout.Label (text);

		GUILayout.EndHorizontal ();

		GUILayout.EndArea ();
	}

	public void changeText(string newtext){
		Debug.Log ("Text changed");
		this.text = newtext;
	}
}
