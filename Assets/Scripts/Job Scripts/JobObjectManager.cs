﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobObjectManager : MonoBehaviour {

	//OnMouseOver, highlight with a glow element.
	//OnMouseDown, bring up job in UI form.

	private bool isSelectable = false;
	public Job currentJob;
	static JobObjectManager currentJobObject;
	public JobBoard jobBoard;

	void OnMouseDown(){
		if (!isSelectable) {
			jobBoard.SetPerspective ();

		}
		if (isSelectable) {
		Debug.Log("Clicked!");
			currentJobObject = this;
			//enable job menu on camera 1 canvas, change text, change image.
			JobManager.instance.OpenJob (currentJob, currentJobObject);
		}
	}

	public void DestroyJob(){
		Destroy (gameObject);
	}

	public void SetSelectability(bool newValue){
		isSelectable = newValue;
		Debug.Log ("My selectability is " + newValue);
	}
}
