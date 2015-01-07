using UnityEngine;
using System.Collections;

[System.Serializable]
public class PositionRotation{
	// what state is required to have this set up
	public int requiredState;
	
	public Vector3 position;
	public Quaternion rotation;
}

public class StatePositionChanger : MonoBehaviour {
	public SceneStory theStory;

	// if this object needs to be manipulated 
	public bool isStateDependant;

	public PositionRotation[] positions;

	public void ChangeState(int state){
		foreach (PositionRotation n in positions) {
			if(n.requiredState == state){
				this.transform.position = n.position;
				this.transform.rotation = n.rotation;
			}
		}
	}
}
