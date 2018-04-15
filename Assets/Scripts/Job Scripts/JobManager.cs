using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JobManager : MonoBehaviour {

	public static JobManager instance;
	public static JobObject currentJobObject;
	public JobSpawner jobSpawner;
	public GameObject jobCanvas;
	public GameObject jobTextObject;
	public GameObject jobNameObject;
	public GameObject jobSpriteObject;
	private Text jobText;
	private Text jobName;
	private Image jobSprite;
	private Job currentJob;

	public List<GameObject> currentJobList = new List<GameObject>();


	void Awake(){
		instance = this;
	}

	void Start(){
		jobText = jobTextObject.GetComponent<Text> ();
		jobName = jobNameObject.GetComponent<Text> ();
		jobSprite = jobSpriteObject.GetComponent<Image> ();
	}

	public void OpenJob(Job newJob, JobObject newJobObject){

		jobCanvas.SetActive (true);

		currentJobObject = newJobObject;
		currentJob = newJob;
		jobName.text = newJob.name;
		jobText.text = newJob.text;
		jobSprite.sprite = newJob.sprite;
	}

	public void CloseJob(){
		jobCanvas.SetActive (false);
	}

	public void DeleteJob(){
		RemoveJob (currentJobObject.gameObject);
		CloseJob();
		currentJobObject.DestroyJob ();
		jobSpawner.DecrementNumberOfJobs ();
	}

	public Job GetCurrentJob(){
		return currentJob;
	}

	public void AddJob(GameObject job){
		currentJobList.Add(job);
	}

	public void RemoveJob(GameObject job){
		currentJobList.Remove (job);
	}

	public void SetAllJobSelectability(bool newValue){
		foreach(GameObject jobObject in currentJobList){
			JobObject thisJobObject = jobObject.GetComponent<JobObject> ();
			thisJobObject.SetSelectability (newValue);
			//Debug.Log ("Set accessible.");
		}
	}
}