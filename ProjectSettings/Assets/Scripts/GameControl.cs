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
	public bool newGame;

	public void Awake () {
	
		if (control == null) {

			DontDestroyOnLoad(gameObject);
			control = this;
		}
		if (control != this) {
			Destroy(gameObject);
		}
	}


	void Start () {
		newGame = false;
	}

	public void OnGUI(){

		// Only display stats in game mode, not in menu
		if (Application.loadedLevel != 0) {
			var style = new GUIStyle();
			style.fontSize = 17;
			style.normal.textColor = Color.white;
			GUI.Label (new Rect (10, Screen.height - 30, 80, 20), "Health : " + health, style);
			GUI.Label (new Rect (120, Screen.height - 30, 100, 20), "Exp : " + experience, style);
//			GUI.Label (new Rect (230, Screen.height - 45, 100, 40), "Karma: " + karma);
//			GUI.Label (new Rect (340, Screen.height - 45, 120, 40), "Chaos : " + chaos);
		}
	
	
	}
	
	public void Save(int level){
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath +"/playerInfo.dat");

		// Save data into PlayerData object
		PlayerData data = new PlayerData();
		data.health = health;
		data.experience = experience;
		data.chaos = chaos;
		data.karma = karma;
		// Save loaded level if its greater than already saved loaded level or a new game is started
		data.loadedLevel = level;

		Debug.Log("Game saved to level " + data.loadedLevel);

		bf.Serialize (file, data);

		file.Close();

		Debug.Log ("Save Made, Path is : " + Application.persistentDataPath + "/playerInfo.dat");
	}

	public void Load(){

		if (fileExists()) {
			BinaryFormatter bf = new BinaryFormatter ();
			var appPath = Application.persistentDataPath + "/playerInfo.dat";
			FileStream file = File.Open(appPath, FileMode.Open);

			PlayerData data = (PlayerData)bf.Deserialize (file);

			file.Close();

			health = data.health;	
			experience = data.experience;
			chaos = data.chaos;
			karma = data.karma;

			Debug.Log("Loading saved level " + data.loadedLevel);
			Application.LoadLevel(data.loadedLevel);
			
			Debug.Log("Loaded game, Path is : " + appPath +"/playerInfo.dat" );

		} else {
			health = 100;	
			experience = 0;
			chaos = 0;
			karma= 0;

			Debug.Log("No saved data" );
		}
	}

	public Boolean fileExists(){
		if (File.Exists (Application.persistentDataPath + "/playerInfo.dat")) {
			return true;
		} else {
			return false;
		}
	}

	public void startNewGame(){
		newGame = true;
		health = 100;	
		experience = 0;
		chaos = 0;
		karma= 0;
		
		Debug.Log("Started new game");
	}

	
	public void AddExperience(int exp){
		experience = experience + exp;
	}

	public void AddOrReduceKarma(int amount){
		karma = karma + amount ;
	}

	public void AddOrReduceChaos(int amount){
		chaos = chaos + amount ;
	}

	public void AddOrReduceHelath(int hp){
		health = health + hp;
	}

	[Serializable]
	class PlayerData {
		public int loadedLevel;
		public int health;
		public int experience;
		public int karma;
		public int chaos;

	}
}
