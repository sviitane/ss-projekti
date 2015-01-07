using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GuiLoader : MonoBehaviour {

	// so we can reset the text position
	public RectTransform scrollViewText;

	// bool to determine how to interact with the game
	public bool storyMode;

	public RectTransform panel;
	public Text panelText;
	public Button goodOption;
	public Button badOption;
	public Button nextButton;
	public Button checkAction;
	public Button continueAction;

	// custom styles for stuff
	public GUIStyle customBoxStyle;
	public GUIStyle customLabelStyle;
	public GUIStyle customButtonStyle;
	public GUIStyle storyButtonStyle;
	public GUIStyle bottomGuiStyle;

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

	// index of next level
	private int nextLevel;

	// index of current slide of story to be shown
	private float currentStorySlide;

	// bool for displaying different texts in story
	public bool displayOtherText;

	public SceneStory story;
	private StoryText t;

	void Start(){
		mapCleared = false;
		mapClearText = "Congratulations, you have completed all actions in" + Application.loadedLevelName + ", click on the arrow to continue";
		nextLevel = Application.loadedLevel + 1;
		currentStorySlide = 0;
		displayOtherText = false;
		reloadListeners ();
		text = "";
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
		if(!storyMode){
			checkAction.gameObject.SetActive(true);
			continueAction.gameObject.SetActive(false);
			nextButton.gameObject.SetActive(false);
			if (text != null && text != "") {
				panel.gameObject.SetActive(true);
				panelText.text = text;

				if(mapCleared){
					continueAction.gameObject.SetActive(true);
	            }

			}else{
				// Hide stuff
				panel.gameObject.SetActive(false);
			}
        }else if(storyMode){
			checkAction.gameObject.SetActive(false);
			continueAction.gameObject.SetActive(false);
			Debug.Log("Story mode active");
			if(story.sceneStoryFlow.GetLength(0)>0){
				if(currentStorySlide < story.sceneStoryFlow.GetLength(0)){
					t = (StoryText)story.sceneStoryFlow.GetValue((long)currentStorySlide);
					setupBigBox();
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

	public void setupBigBox(){

		// check if we want to display the other text (when negative option is chosen) and display the text
		if(displayOtherText && t.otherText != null){
			changeText(t.otherText);
		}else if(t.otherText == null){
			Debug.LogError("No negative text specified, specify one in the inspector!");
			changeText(t.text);
		}else{
			changeText(t.text);
		}

		panel.gameObject.SetActive(true);
		panelText.text = text;

		if(t.isEndOfScene){
			Debug.Log ("Story slide was end of scene");
			GuiLoader.loader.mapCleared = true;
		}

		// if canChoose is enabled, we chec if options have been specified.
		if(t.canChoose){

			if(t.goodOption != null && t.badOption != null){

				goodOption.gameObject.SetActive(true);
				badOption.gameObject.SetActive(true);
				nextButton.gameObject.SetActive(false);

			}else{
				Debug.LogError("If options are enabled, you must specify the option texts!");
			}

		}else{
			goodOption.gameObject.SetActive(false);
			badOption.gameObject.SetActive(false);
			nextButton.gameObject.SetActive(true);

			string nexttext = "Next";

			if(t.next != null){
				nexttext = t.next;
			}else{
				Debug.LogError("No next text specified, using default value");
			}
		}
	}

	public void nextListener(){
		Debug.Log("Next clicked");
		InteractiveAudioManager.audioManager.PlaySound("blop");
		currentStorySlide = currentStorySlide + 1;

		// if we want to pause the story and continue later in the same scene
		if (t.pauseStory) {
			storyMode = false;
			changeText("");
		}

		if (t.changeState) {
			Debug.Log("Story slide has state change set, adding to state");
			GameObject.Find("SceneStory").SendMessage("AddToState", 1);
		}
	}

	public void checkListener(){
		text = "";
		InteractiveAudioManager.audioManager.PlaySound("blop");
	}

	public void continueListener(){
		InteractiveAudioManager.audioManager.PlaySound("blop");
		GameControl.control.AddExperience(100);
		Application.LoadLevel(Application.loadedLevel + 1);
		//Save game
		GameControl.control.Save(Application.loadedLevel + 1);
		mapCleared = false;
		text = "";
		storyMode = false;
		currentStorySlide = 0;
	}

	public void goodListener(){
		Debug.Log("Good option clicked");
		InteractiveAudioManager.audioManager.PlaySound("blop");
		currentStorySlide = currentStorySlide + 1;
		displayOtherText = false;
		if(t.goodOptionKarmaChange != 0){
			Debug.Log("Good choice has karma change value specified, changing karma");
			GameControl.control.AddOrReduceKarma((int)t.goodOptionKarmaChange);
		}
		
		if(t.goodOptionChaosChange != 0){
			Debug.Log("Good choice has chaos change value specified, changing karma");
			GameControl.control.AddOrReduceChaos((int)t.goodOptionChaosChange);
		}

		if (t.changeState) {
			Debug.Log("Story slide has state change set, adding to state");
			GameObject.Find("SceneStory").SendMessage("AddToState", 1);
		}
	}

	public void badListener(){
		InteractiveAudioManager.audioManager.PlaySound("blop");
		currentStorySlide = currentStorySlide + 1;
		displayOtherText = true;
		if(t.badOptionKarmaChange != 0){
			Debug.Log("Good choice has karma change value specified, changing karma");
			GameControl.control.AddOrReduceKarma((int)t.badOptionKarmaChange);
		}
		
		if(t.badOptionChaosChange != 0){
			Debug.Log("Good choice has chaos change value specified, changing karma");
			GameControl.control.AddOrReduceChaos((int)t.badOptionChaosChange);
		}

		if (t.changeState) {
			Debug.Log("Story slide has state change set, adding to state");
			GameObject.Find("SceneStory").SendMessage("AddToState", 1);
		}
	}

	public void reloadListeners(){
		goodOption.onClick.AddListener (()=> {goodListener();});
		badOption.onClick.AddListener (()=> {badListener();});
		checkAction.onClick.AddListener (()=> {checkListener();});
		continueAction.onClick.AddListener (()=> {continueListener();});
		nextButton.onClick.AddListener (()=> {nextListener();});
	}
}
