using UnityEngine;
using System.Collections;

[System.Serializable]
public class StoryText{
	// text that appears in the current "slide" of the story
	public string text;
	// text that appears if in previous slide player has clicked the bad option
	public string otherText;
	// boolean if this slide has a choice
	public bool canChoose;
	// if slide has choice this is the good option text
	public string goodOption;
	// amount of karma to change if good option is pressed (default 0)
	public float goodOptionKarmaChange;
	// amount of chaos to change if good option is pressed (default 0)
	public float goodOptionChaosChange;
	// if slide has choice this is the bad option text
	public string badOption;
	public float badOptionKarmaChange;
	public float badOptionChaosChange;
	// if slide has no choice this is the next text, default is "Next"
	public string next;

	// to be done, faces for different texts
	public Texture2D goodFace;
	public Texture2D badFace;
}

public class GuiLoader : MonoBehaviour {

	public bool storyMode;

	// All level story texts
	public StoryText[] levelOneStory;
	public StoryText[] levelTwoStory;
	public StoryText[] levelThreeStory;

	// checked and continue images
	public Texture2D checkAction;
	public Texture2D continueAction;

	// custom styles for stuff
	public GUIStyle customBoxStyle;
	public GUIStyle customLabelStyle;
	public GUIStyle customButtonStyle;
	public GUIStyle storyButtonStyle;

	// make this singleton
	public static GuiLoader loader;

	// font style
	public Font f;

	// text to be changed
	public string text;

	// if map is cleared
	public bool mapCleared;

	// text to be shown when map is cleared
	private string mapClearText;

	//
	private bool checkButtonVisible = false;

	// index of next level
	private int nextLevel;

	// variables for calculating font size
	private float oldWidth;
	private float oldHeight;
	private float fontSize = 16;
	public float ratio = 5;

	private float boxHeight = 240;
	private float boxWidth = 50;

	private float bigBoxHeight;

	// index of current slide of story to be shown
	private float currentStorySlide;

	// bool for displaying different texts in story
	public bool displayOtherText;

	void Start(){
		mapCleared = false;
		mapClearText = "Congratulations, you have completed all actions in" + Application.loadedLevelName + ", click on the arrow to continue";
		nextLevel = Application.loadedLevel + 1;
		currentStorySlide = 0;
		displayOtherText = false;
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
						storyMode = false;
						currentStorySlide = 0;
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
				if(currentStorySlide < levelTwoStory.GetLength(0)){
					StoryText t = (StoryText)levelTwoStory.GetValue((long)currentStorySlide);
					setupBigBox(t);
				}else{
					Debug.Log("Story for this map is finished");
					text = "";
					storyMode = false;
				}
			}else if(Application.loadedLevel.Equals(3) && (levelThreeStory.GetLength(0)>0)){
				if(currentStorySlide < levelThreeStory.GetLength(0)){
					StoryText t = (StoryText)levelThreeStory.GetValue((long)currentStorySlide);
					setupBigBox(t);
				}else{
					Debug.Log("Story for this map is finished");
					text = "";
					storyMode = false;
				}
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

		// check if we want to display the other text (when negative option is chosen) and display the text
		if(displayOtherText && !t.otherText.Equals(null)){
			text = t.otherText;
		}else if(t.otherText.Equals(null)){
			Debug.LogError("No negative text specified, specify one in the inspector!");
			text = t.text;
		}else{
			text = t.text;
		}

		GUI.skin.font = f;
		GUI.backgroundColor = Color.white;
		GUI.Box (new Rect (0, 0, boxWidth, bigBoxHeight), "Story");
		GUI.Label (new Rect (30, 40, boxWidth - 60, bigBoxHeight - 50), text, customLabelStyle);

		// if canChoose is enabled, we chec if options have been specified.
		if(t.canChoose){

			if(!t.goodOption.Equals(null) && !t.badOption.Equals(null)){
				// When good option is clicked, the default next text is always displayed.
				if(GUI.Button (new Rect (boxWidth - boxWidth / 3, bigBoxHeight - 170, 150, 50), t.goodOption, storyButtonStyle)){
					Debug.Log("Good option clicked");
					InteractiveAudioManager.audioManager.PlaySound("blop");
					currentStorySlide = currentStorySlide + 1;
					displayOtherText = false;
					if(!t.goodOptionKarmaChange.Equals(null) && !t.goodOptionKarmaChange.Equals(0)){
						Debug.Log("Good choice has karma change value specified, changing karma");
						GameControl.control.AddOrReduceKarma((int)t.goodOptionKarmaChange);
					}

					if(!t.goodOptionChaosChange.Equals(null) && !t.goodOptionChaosChange.Equals(0)){
						Debug.Log("Good choice has chaos change value specified, changing karma");
						GameControl.control.AddOrReduceChaos((int)t.goodOptionChaosChange);
					}
				}
				// When bad option is clicked, we check if displayOtherText is true, then we display the other text.
				if(GUI.Button (new Rect (boxWidth - boxWidth / 3, bigBoxHeight - 100, 150, 50), t.badOption, storyButtonStyle)){
					InteractiveAudioManager.audioManager.PlaySound("blop");
					currentStorySlide = currentStorySlide + 1;
					displayOtherText = true;
					if(!t.badOptionKarmaChange.Equals(null) && !t.badOptionKarmaChange.Equals(0)){
						Debug.Log("Good choice has karma change value specified, changing karma");
						GameControl.control.AddOrReduceKarma((int)t.badOptionKarmaChange);
					}
					
					if(!t.badOptionChaosChange.Equals(null) && !t.badOptionChaosChange.Equals(0)){
						Debug.Log("Good choice has chaos change value specified, changing karma");
						GameControl.control.AddOrReduceChaos((int)t.badOptionChaosChange);
					}
				}
			}else{
				Debug.LogError("If options are enabled, you must specify the option texts!");
			}
		}else{

			string nexttext = "Next";
			// 
			if(!t.next.Equals(null)){
				nexttext = t.next;
			}else{
				Debug.LogError("No next text specified, using default value");
			}

			if(GUI.Button (new Rect (boxWidth - boxWidth / 3, bigBoxHeight - 150, 150, 50), nexttext, storyButtonStyle)){
				Debug.Log("Next clicked");
				InteractiveAudioManager.audioManager.PlaySound("blop");
				currentStorySlide = currentStorySlide + 1;
			}

			if(!t.goodFace.Equals(null) && !displayOtherText){
				GUI.Button (new Rect (boxWidth - 150, boxHeight / 2, 400, 200), t.goodFace, customButtonStyle);
			}else if(!t.badFace.Equals(null) && displayOtherText){
				GUI.Button (new Rect (boxWidth - 150, boxHeight / 2, 400, 200), t.badFace, customButtonStyle);
			}else{
				Debug.Log("No faces specified");
			}
		}
	}
}
