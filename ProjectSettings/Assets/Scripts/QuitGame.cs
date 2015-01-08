using UnityEngine;
using System.Collections;

public class QuitGame : MonoBehaviour {
	public void QuitTheGame(){
		Debug.Log ("Game has been quit");
		Application.Quit ();
	}
}
