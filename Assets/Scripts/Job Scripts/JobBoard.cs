using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#pragma warning disable 649

public class JobBoard : SelectableMenu{

	[SerializeField] private JobManager jobManager;
	[SerializeField] private bool isJobSelectable = false;

	void OnTriggerEnter(Collider other){
		isJobSelectable = true;
		SetJobSelectability (isJobSelectable);
	}

	void OnTriggerExit(Collider other){
		isJobSelectable = false;
		SetJobSelectability (isJobSelectable);
	}

	void SetJobSelectability(bool newValue){
		//take the current list of jobs and set their selectability status to enabled.
		jobManager.SetAllJobSelectability(newValue);
	}

	public bool GetSelectability(){
		return isJobSelectable;
	}
}
