using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JobManager : MonoBehaviour {

	public static JobManager instance;
	public static JobObjectManager currentJobObject;
	public GameObject jobCanvas;
	public GameObject jobTextObject;
	public GameObject jobNameObject;
	public GameObject jobSpriteObject;
	public Text jobText;
	public Text jobName;
	public Image jobSprite;
	private Job currentJob;


	void Awake(){
		instance = this;
	}

	void Start(){
		jobText = jobTextObject.GetComponent<Text> ();
		jobName = jobNameObject.GetComponent<Text> ();
		jobSprite = jobSpriteObject.GetComponent<Image> ();
	}

	public void OpenJob(Job newJob, JobObjectManager newJobObject){

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
		CloseJob();
		currentJobObject.DestroyJob ();
	}

	public Job GetCurrentJob(){
		return currentJob;
	}
}