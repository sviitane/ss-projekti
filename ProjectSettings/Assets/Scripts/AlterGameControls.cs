using UnityEngine;
using System.Collections;

public class AlterGameControls : MonoBehaviour {

	public void ChageExperience(int exp){

		GameControl.control.experience = GameControl.control.experience + exp;
	}

	public void ChageHealth(int helath){
		
		GameControl.control.health = GameControl.control.health + helath;
	}

	public void ChageKarma(int karma){
		
		GameControl.control.karma = GameControl.control.karma + karma;
	}

	public void ChageChaos(int chaos){
		
		GameControl.control.chaos = GameControl.control.chaos + chaos;
			
	}
}
