using UnityEngine;
using System.Collections;

[System.Serializable]
public class StoryText{
	public string text;
	public bool canChoose;
	public string goodOption;
	public string badOption;
	public string next;
}

public class GuiLoader : MonoBehaviour {

	public bool storyMode;

	// All level story texts
	public StoryText[] levelOneStory;
	public StoryText[] levelTwoStory;
	public StoryText[] levelThreeStory;

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

	private float bigBoxHeight;

	private float currentStorySlide;

	void Start(){
		mapCleared = false;
		mapClearText = "Congratulations, you have completed all actions in" + Application.loadedLevelName + ", click on the arrow to continue";
		nextLevel = Application.loadedLevel + 1;
		currentStorySlide = 0;
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
		bigBoxHeight = Screen.height;

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
			if(Application.loadedLevel.Equals(1) && (levelOneStory.GetLength(0)>0)){
				if(currentStorySlide < levelOneStory.GetLength(0)){
					StoryText t = (StoryText)levelOneStory.GetValue((long)currentStorySlide);
					setupBigBox(t);
				}else{
					Debug.Log("Story for this map is finished");
					text = "";
					storyMode = false;
				}
			}else if(Application.loadedLevel.Equals(2) && (levelTwoStory.GetLength(0)>0)){

			}else if(Application.loadedLevel.Equals(3) && (levelThreeStory.GetLength(0)>0)){

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

	public void setupBigBox(StoryText t){
		text = t.text;
		GUI.skin.font = f;
		GUI.backgroundColor = Color.white;
		GUI.Box (new Rect (0, 0, boxWidth, bigBoxHeight), "Story", customBoxStyle);
		GUI.Label (new Rect (30, 40, boxWidth - 60, bigBoxHeight - 50), text, customLabelStyle);
		if(t.canChoose){
			if(!t.goodOption.Equals(null) && !t.badOption.Equals(null)){
				if(GUI.Button (new Rect (30, bigBoxHeight - 150, boxWidth - 60, bigBoxHeight - 50), t.goodOption, customLabelStyle)){
					Debug.Log("Good option clicked");
					InteractiveAudioManager.audioManager.PlaySound("blop");
					currentStorySlide = currentStorySlide + 1;
				}
				if(GUI.Button (new Rect (30, bigBoxHeight - 100, boxWidth - 60, bigBoxHeight - 50), t.badOption, customLabelStyle)){
					InteractiveAudioManager.audioManager.PlaySound("blop");
					currentStorySlide = currentStorySlide + 1;
				}
			}else{
				Debug.LogError("If options are enabled, you must specify the option texts!");
			}
		}else{
			if(!t.next.Equals(null)){
				if(GUI.Button (new Rect (30, bigBoxHeight - 150, boxWidth - 60, bigBoxHeight - 50), t.next, customLabelStyle)){
					Debug.Log("Next clicked");
					InteractiveAudioManager.audioManager.PlaySound("blop");
					currentStorySlide = currentStorySlide + 1;
				}
			}else{
				Debug.LogError("You must specify a text for continuing");
			}
		}
	}
}
