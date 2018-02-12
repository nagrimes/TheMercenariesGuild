using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobBoard : SelectableMenu{

	public GameObject testJob;
	private JobObjectManager testJobObject;

	void OnTriggerEnter(Collider other){
		SetJobSelectability (true);
	}

	void OnTriggerExit(Collider other){
		SetJobSelectability (false);
	}

	void SetJobSelectability(bool newValue){
		//take the current list of jobs and set their selectability status to enabled.
		testJobObject = testJob.GetComponent<JobObjectManager>();
		testJobObject.SetSelectability (newValue);
	}
}
