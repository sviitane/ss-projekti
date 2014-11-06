using UnityEngine;
using System.Collections;

//A Helper class to display tutorial elements, so that they dont mess up the actual gameplay objects.

public class TutorialHelper : MonoBehaviour {
	public GameObject arrow;
	void Start () {
		GameObject g = Instantiate (arrow, new Vector2 (this.transform.position.x, this.transform.position.y - 10), Quaternion.identity) as GameObject;
		g.transform.parent = this.transform;
	}
}
