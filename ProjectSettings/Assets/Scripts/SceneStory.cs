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
	
	// boolean for determine if a story slide should end the scene, or make the map "complete"
	public bool isEndOfScene;

	// boolean for pausing the story
	public bool pauseStory;

	// to be done, faces for different texts
	public Texture2D goodFace;
	public Texture2D badFace;

	// if we want to change the game state
	public bool changeState;

	// end of tutorial
	public bool isEndOfTutorial;
}

public class SceneStory : MonoBehaviour {

	// static reference to this object
	public static SceneStory story;

	// flow for the story in this scene
	public StoryText[] sceneStoryFlow;

	public int sceneState;

	void Start(){
		GuiLoader.loader.story = this;
		sceneState = 0;
	}

	public void AddToState(int val){
		sceneState = sceneState + 1;
	}

	public int GetSceneState(){
		return this.sceneState;
	}
}
