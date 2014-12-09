using UnityEngine;
using System.Collections;

public class TextChanger : MonoBehaviour {

	// This class can be used to make a starting text appear etc.

	public string startText;

	void Start () {
		GuiLoader.loader.changeText (startText);
		GuiLoader.loader.mapCleared = false;
		GuiLoader.loader.storyMode = true;
	}
}
