using UnityEngine;
using System.Collections;

public class RandomSpawner : MonoBehaviour {

	public GameObject capsule;

	void Start () {
		int capsuleQuantity = Random.Range (2, 8);
		for (int i = 0; i < capsuleQuantity; i++) {
			Vector3 position = new Vector3(Random.Range(-4.0f,4.0f), Random.Range(-4.0f,4.0f), 0);
			Instantiate(capsule, position, Quaternion.identity);
		}
	}
}
