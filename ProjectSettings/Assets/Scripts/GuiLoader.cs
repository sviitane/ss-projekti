using UnityEngine;
using System.Collections;

public class GuiLoader : MonoBehaviour {

	public Texture2D checkAction;
	public Texture2D continueAction;

	public GUIStyle customBoxStyle;
	public GUIStyle customLabelStyle;
	public GUIStyle customButtonStyle;

	public static GuiLoader loader;

	public Font f;
	public string text;

	public bool mapCleared;

	private string mapClearText;
	private bool checkButtonVisible = false;

	private int nextLevel;

	void Start(){
		mapCleared = false;
		mapClearText = "Congratulations, you have completed all actions in" + Application.loadedLevelName + ", click on the arrow to continue";
		nextLevel = Application.loadedLevel + 1;
	}

	void Awake(){
		if (loader == null) {
			DontDestroyOnLoad (gameObject);
			loader = this;
		} else if (loader != this) {
			Destroy (gameObject);
		}
	}

	void OnGUI(){
		// Only show textbox if there is some text to show, don't show any other text boxes if map has been cleared
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

			if(mapCleared){
				if(GUI.Button (new Rect (Screen.width - 180, 230, 70, 70), continueAction, customButtonStyle)){
					InteractiveAudioManager.audioManager.PlaySound("blop");
					Application.LoadLevel(nextLevel);
					mapCleared = false;
					text = "";
                };
            }
        }
    }
    
	public void changeText(string newtext){
		Debug.Log ("Text changed");
		this.text = newtext;
	}
}
