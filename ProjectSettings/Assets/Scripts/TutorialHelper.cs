using UnityEngine;
using System.Collections;

public class TutorialHelper : MonoBehaviour {
	public GameObject arrow;
	void Start () {
		GameObject g = Instantiate (arrow, new Vector2 (this.transform.position.x, this.transform.position.y), Quaternion.identity) as GameObject;
		g.transform.parent = this.transform;
	}
}
