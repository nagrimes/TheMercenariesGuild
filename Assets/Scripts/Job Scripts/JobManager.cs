using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JobManager : MonoBehaviour {

	public static JobManager instance;
	public GameObject jobCanvas;
	public GameObject jobTextObject;
	public GameObject jobNameObject;
	public GameObject jobSpriteObject;
	public Text jobText;
	public Text jobName;
	public Image jobSprite;
	private Job currentJob;
	public static JobObjectManager currentJobObject;
	public GameObject sendMercenariesCanvas;

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

		jobText.text = newJob.text;
		jobSprite.sprite = newJob.sprite;
	}

	public void CloseJob(){
		jobCanvas.SetActive (false);
	}

	public void ActivateJob(){
		//Open the sendMercenaries menu
		sendMercenariesCanvas.SetActive(true);

	}

	public void DeleteJob(){
		CloseJob();
		currentJobObject.DestroyJob ();
	}
}