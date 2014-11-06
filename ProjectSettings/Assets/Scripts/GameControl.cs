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
	
		if (control == null) {

			DontDestroyOnLoad(gameObject);
			control = this;

			Debug.Log ("DO NOT DESTROY");
		}
		if (control != this) {
			Destroy(gameObject);
			Debug.Log ("SHIT");
		}
	}


	void Start () {
				if (Application.loadedLevelName == "Menu")
						Load ();
		}

	public void OnGUI(){

		GUI.Label(new Rect (10, 10, 100, 30), "Health: " + health);
		GUI.Label(new Rect (120, 10, 120, 30), "Exp : " + experience);
		GUI.Label(new Rect (230, 10, 100, 30), "Karma: " + karma);
		GUI.Label(new Rect (340, 10, 120, 30), "Chaos : " + chaos);
	
	
	}
	
	public void Save(){
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath +"/playerInfo.dat");

		PlayerData data = new PlayerData();
		data.health = health;
		data.experience = experience;
		data.chaos = chaos;
		data.karma = karma;

		bf.Serialize (file, data);

		file.Close();

		Debug.Log ("Save Made, Path is : " + Application.persistentDataPath + "/playerInfo.dat");
	}

	public void Load(){

		if (File.Exists(Application.persistentDataPath + "/playerInfo.dat")) {
						BinaryFormatter bf = new BinaryFormatter ();
						var appPath = Application.persistentDataPath + "/playerInfo.dat";
						FileStream file = File.Open(appPath, FileMode.Open);

						PlayerData data = (PlayerData)bf.Deserialize (file);
						health = data.health;	
						experience = data.experience;
						chaos = data.chaos;
						karma= data.karma;
			
			Debug.Log("Loaded game, Path is : " + appPath +"/playerInfo.dat" );

		} else {
			health = 100;	
			experience = 0;
			chaos = 0;
			karma= 0;

			Debug.Log("No saved data" );
		}
	}
	
	[Serializable]
	class PlayerData {
		
		public int health;
		public int experience;
		public int karma;
		public int chaos;

	}
}
