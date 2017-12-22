using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableObjectManager : MonoBehaviour {

	public CameraManager other;
	public Vector3 cameraOffset = new Vector3 (0f, 0f, 0f);

	void OnMouseDown(){
		//Calls Camera's new perspective function, sending transform.position as a parameter.
		other.SetNewPerspective(transform.position, cameraOffset);
	}
}