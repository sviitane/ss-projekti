using UnityEngine;
using System.Collections;

public class GuiLoader : MonoBehaviour {

	public bool storyMode;

	// All level story texts
	public string[] levelOneStoryTexts;
	public string[] levelTwoStoryTexts;
	public string[] levelThreeStoryTexts;

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

	private float oldWidth;
	private float oldHeight;
	private float fontSize = 16;
	public float ratio = 5;

	private float boxHeight = 240;
	private float boxWidth = 50;

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

	void Update(){
		if(oldWidth != Screen.width || oldHeight != Screen.height){
			oldWidth = Screen.width;
			oldHeight = Screen.height;
			fontSize = Mathf.Min(Screen.width, Screen.height) / ratio;
		}
	}

	void OnGUI(){
		customLabelStyle.fontSize = (int)fontSize;

		boxWidth = Screen.width;
		boxHeight = Screen.height / 3;

		// Only show textbox if there is some text to show, don't show any other text boxes if map has been cleared
		if(!storyMode){
			if (text != null && text != "") {
				if (!f) {
					Debug.LogError("No Font found, add one in inspector");
					return;
				}
				GUI.skin.font = f;
				GUI.backgroundColor = Color.white;
				GUI.Box (new Rect (0, 0, boxWidth, boxHeight), "Action", customBoxStyle);
				GUI.Label (new Rect (30, 40, boxWidth - 60, boxHeight - 50), text, customLabelStyle);

				// Create a button for clearing the text
	            if(GUI.Button (new Rect (boxWidth - 70, boxHeight - 40, 70, 70), checkAction, customButtonStyle)){
					text = "";
					InteractiveAudioManager.audioManager.PlaySound("blop");
	            };

				if(mapCleared){
					if(GUI.Button (new Rect (boxWidth - 140, boxHeight - 40, 70, 70), continueAction, customButtonStyle)){
						InteractiveAudioManager.audioManager.PlaySound("blop");
						GameControl.control.AddExperience(100);
						Application.LoadLevel(nextLevel);
						//Save game
						GameControl.control.Save(nextLevel);
						mapCleared = false;
						text = "";
	                };
	            }
			}
        }else if(storyMode){
			Debug.Log("Story mode active");
			if(Application.loadedLevel.Equals(1) && (levelOneStoryTexts.GetLength(0)>0)){
				
			}else if(Application.loadedLevel.Equals(2) && (levelTwoStoryTexts.GetLength(0)>0)){

			}else if(Application.loadedLevel.Equals(3) && (levelThreeStoryTexts.GetLength(0)>0)){

			}else{
				Debug.LogWarning("Current level has no story text specified, setting story mode to false");
				storyMode = false;
			}
		}
    }
    
	public void changeText(string newtext){
		Debug.Log ("Text changed");
		this.text = newtext;
	}
}
