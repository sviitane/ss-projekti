using UnityEngine;
using System.Collections;

public class GuiLoader : MonoBehaviour {
	public GameObject text;

	void start(){
		text.renderer.enabled = false;
		text.collider.enabled = false;
	}

	// Sets the text to be shown
	public void setText(string incomingText){
		text.GetComponent<TextMesh>().text = incomingText;
	}

	public void showText(){
		text.renderer.enabled = true;
		text.collider.enabled = true;
	}
}
