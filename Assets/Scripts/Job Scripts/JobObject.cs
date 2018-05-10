using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobObject : MonoBehaviour {

	//OnMouseOver, highlight with a glow element.
	//OnMouseDown, bring up job in UI form.

	private bool isSelectable = false;
	public Job currentJob;
	static JobObject currentJobObject;
	public JobBoard jobBoard;
	public int boardQuadrant{ get; set; }

	void OnMouseDown(){
		if (!isSelectable) {
			jobBoard.SetPerspective ();

		}
		if (isSelectable) {
			currentJobObject = this;
			JobManager.instance.OpenJob (currentJob, currentJobObject);
		}
	}

	public void DestroyJob(){
		Destroy (gameObject);
	}

	public void SetSelectability(bool newValue){
		isSelectable = newValue;
	}
}
