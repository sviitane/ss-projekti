using UnityEngine;
using System.Collections;

public class GuiLoader : MonoBehaviour {

	public Texture2D checkAction;

	public GUIStyle customBoxStyle;
	public GUIStyle customLabelStyle;
	public GUIStyle customButtonStyle;

	public static GuiLoader loader;

	public Font f;
	public string text;

	private bool checkButtonVisible = false;

	void Awake(){
		if (loader == null) {
			DontDestroyOnLoad (gameObject);
			loader = this;
		} else if (loader != this) {
			Destroy (gameObject);
		}
	}

	void OnGUI(){

		// Only show textbox if there is some text to show
		if (text != null && text != "") {
			if (!f) {
				Debug.LogError("No Font found, add one in inspector");
				return;
			}
			GUI.skin.font = f;
			GUI.backgroundColor = Color.white;
			GUI.Box (new Rect (120, 20, Screen.width - 240, 240), "Action", customBoxStyle);
			GUI.Label (new Rect (150, 60, Screen.width - 300, 200), text, customLabelStyle);

			// Create a button for clearing the text
			if(GUI.Button (new Rect (Screen.width - 250, 230, 70, 70), checkAction, customButtonStyle)){
				text = "";
				InteractiveAudioManager.audioManager.PlaySound("blop");
			};
		}
	}

	public void changeText(string newtext){
		Debug.Log ("Text changed");
		this.text = newtext;
	}

	public void changeTextWithParam(string newtext, string param){
		Debug.Log ("Text changed with parameters");
		this.text = newtext + param;
    }
}
