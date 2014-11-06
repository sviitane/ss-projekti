using UnityEngine;
using System.Collections;

public class GuiLoader : MonoBehaviour {

	public static GuiLoader loader;

	public Font f;
	public string text;

	void Awake(){
		if (loader == null) {
			DontDestroyOnLoad (gameObject);
			loader = this;
		} else if (loader != this) {
			Destroy (gameObject);
		}
	}

	void OnGUI(){
		if (!f) {
			Debug.LogError("No Font found, add one in inspector");
			return;
		}
		GUI.skin.font = f;
		GUI.Box (new Rect (120, 20, Screen.width - 240, 100), "Action");
		GUI.Label (new Rect (125, 40, Screen.width - 250, 115), text);


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
