using UnityEngine;
using System.Collections;

public class Initializer : MonoBehaviour {

	// This class is designed to act as a non singleton game control, clearing
	// necessary values and other stuff that need to be cleared after each map.

	// The text that appears in the beginning if story mode does not start immediately
	public string startText;

	// Sets story mode to true in the start of the scene
	public bool setStoryModeInStart;

	void Start () {
		GuiLoader.loader.changeText (startText);
		GuiLoader.loader.mapCleared = false;
		GuiLoader.loader.storyMode = setStoryModeInStart;
		GuiLoader.loader.displayOtherText = false;
	}
}
