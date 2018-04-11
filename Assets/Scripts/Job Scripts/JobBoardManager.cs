using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobBoardManager : MonoBehaviour {

	//OnMouseOver, highlight with a glow element.
	//OnMouseDown, bring up job in UI form.

	private bool isSelectable = false;
	public Job currentJob;
	static JobBoardManager currentJobObject;
	public JobBoard jobBoard;

	void OnMouseDown(){
		if (!isSelectable) {
			jobBoard.SetPerspective ();

		}
		if (isSelectable) {
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
	}
}
