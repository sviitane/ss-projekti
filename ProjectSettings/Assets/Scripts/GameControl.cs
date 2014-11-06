using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour {

	public static GameControl control;

	public int health;
	public int experience;
	public int karma;
	public int chaos;

	public void Awake () {
	
		if (control != null) {

			DontDestroyOnLoad(gameObject);
			control = this;
		}
		if (control != this) {
				
			Destroy(gameObject);
		}

	}

	public void OnGUI(){
//
//		GUI.Label( Rect (10, 10, 100, 30), "Health: " );
//		GUI.Label( Rect (10, 10, 120, 30), "Exp : " );
	}


	public void Save(){
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Open (Application.persistentDataPath +"/playerInfo.dat", FileMode.Open);

	}

}
