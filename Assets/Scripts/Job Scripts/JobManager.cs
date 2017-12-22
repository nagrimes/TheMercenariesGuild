using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JobManager : MonoBehaviour {

	public static JobManager instance;
	public GameObject jobCanvas;
	private Job currentJob;
	public static JobObjectManager currentJobObject;

	void Awake(){
		instance = this;
	}

	public void OpenJob(Job job, JobObjectManager jobObject){

		currentJob = job;
		currentJobObject = jobObject;
		jobCanvas.SetActive (true);

		Transform textChild = jobCanvas.transform.Find ("Job Text");
		Text t = textChild.GetComponent<Text> ();
		t.text = currentJob.text;

		Transform imageChild = jobCanvas.transform.Find ("Job Image");
		Image i = imageChild.GetComponent<Image> ();
		i.sprite = job.sprite;
		//sets job GUI active

	}

	public void CloseJob(){
		//simply closes the job UI.
		jobCanvas.SetActive (false);
	}

	public void ActivateJob(){
		//bring up sendMercs menu.
		CloseJob();
	}

	public void DeleteJob(){
		//call Destroy on the job gameObject.
		CloseJob();
		currentJobObject.DestroyJob ();
	}
}