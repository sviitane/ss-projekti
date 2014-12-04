using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;
using System;

public class TextHandler : MonoBehaviour {

	public static TextHandler textHandler;

	public string lines;

	public GUIStyle customBoxStyle;
	public GUIStyle customLabelStyle;
	public GUIStyle customButtonStyle;
	public Vector2 scrollPosition = Vector2.zero;

	void Awake(){
		if (textHandler == null) {
			DontDestroyOnLoad (gameObject);
			textHandler = this;
		} else if (textHandler != this) {
			Destroy (gameObject);
		}
	}
	

	public void LoadText(string fileName)
	{
		try
		{
			StreamReader theReader = new StreamReader(fileName, Encoding.Default);

			lines = theReader.ReadToEnd();

			theReader.Close();
		}
		catch (Exception e)
		{
			Debug.Log ("Trouble loading text" );
		}

	}


//	void OnGUI()
//	{
//
//
////		GUI.BeginGroup(Rect(0,395,250,305));  //note the 250 width and 305 height compared to the scrollview size
////		scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(240), GUILayout.Height(275));
////		GUILayout.Label(lines);
////		GUILayout.EndScrollView();
////		GUI.EndGroup();
//
////		scrollPosition = GUI.BeginScrollView(new Rect(50, 50, 100, 100), scrollPosition, new Rect(0, 0, 220, 200));
////		GUILayout.Label(text);
////		GUI.Button(new Rect(0, 0, 100, 20), "Top-left");
////		GUI.Button(new Rect(120, 0, 100, 20), "Top-right");
////		GUI.Button(new Rect(0, 180, 100, 20), "Bottom-left");
////		GUI.Button(new Rect(120, 180, 100, 20), "Bottom-right");
//		//GUI.EndScrollView();
//	}


}
