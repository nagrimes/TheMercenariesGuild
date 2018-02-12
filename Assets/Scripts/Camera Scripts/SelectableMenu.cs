using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableMenu : MonoBehaviour {

	public CameraManager mainCamera;
	public Vector3 cameraOffset = new Vector3 (0f, 0f, 0f);

	void OnMouseDown(){
		//Calls Camera's new perspective function, sending transform.position as a parameter.
		SetPerspective();
	}

	public void SetPerspective(){
		mainCamera.SetNewPerspective(transform.position, cameraOffset);
	}
}