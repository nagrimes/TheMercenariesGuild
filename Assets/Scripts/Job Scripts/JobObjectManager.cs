using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobObjectManager : MonoBehaviour {

	//OnMouseOver, highlight with a glow element.
	//OnMouseDown, bring up job in UI form.

	public Job currentJob;
	static JobObjectManager currentJobObject;

	void OnMouseDown(){
		currentJobObject = this;
		//enable job menu on camera 1 canvas, change text, change image.
		JobManager.instance.OpenJob(currentJob, currentJobObject);
	}

	public void DestroyJob(){
		Destroy (gameObject);
	}
}
