using UnityEngine;
using System.Collections;

public class AlterGameControls : MonoBehaviour {

	public void ChageExperience(int exp){

		GameControl.control.experience = GameControl.control.experience + exp;

		Debug.Log ("ChageExperience Success");
	}

	public void ChageHealth(int health){
		
		GameControl.control.health = GameControl.control.health + health;
		Debug.Log ("ChageHealth Success");
	}

	public void ChageKarma(int karma){
		
		GameControl.control.karma = GameControl.control.karma + karma;
		Debug.Log ("ChageKarma Success");
	}

	public void ChageChaos(int chaos){
		
		GameControl.control.chaos = GameControl.control.chaos + chaos;
		Debug.Log("ChageChaos Success");
			
	}

	void onGUI(){

//		GUI.Button (new Rect (10, 50, 120, 30), "heLA UP");
//		
//		GUI.Button (new Rect (10, 100, 120, 30), "heLA DOWN");
//		
//		GUI.Button (new Rect (10, 150, 120, 30), "Exp UP");
//		
//		GUI.Button (new Rect (10, 200, 120, 30), "Save");
//		
//		GUI.Button (new Rect (10, 250, 120, 30), "Load");
//
//		if (GUI.Button (new Rect (10, 10, 120, 30), "heLA UP")) {
//			GameControl.control.health += 10;
//
//		}
//
//		if (GUI.Button (new Rect (10, 10, 120, 30), "heLA DOWN")) {
//			GameControl.control.health -= 10;
//		}
//		if (GUI.Button (new Rect (10, 10, 120, 30), "Karma UP")) {
//			GameControl.control.karma += 10;
//		
//		}
//		if (GUI.Button (new Rect (10, 10, 120, 30), "Exp UP")) {
//			GameControl.control.experience +=100;
//		}

//		if (GUI.Button (new Rect (10, 10, 120, 30), "Save")) {
//			SendMessage("Save");
//		}
//		
//		
//		if (GUI.Button (new Rect (10, 10, 120, 30), "Load")) {
//			SendMessage("Load");
//		}
	}
	
}
