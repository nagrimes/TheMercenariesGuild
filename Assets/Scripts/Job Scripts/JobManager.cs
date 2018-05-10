using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#pragma warning disable 649

public class JobManager : MonoBehaviour {

	public static JobManager instance;
	public static JobObject currentJobObject;
	[SerializeField] private JobSpawner jobSpawner;
	[SerializeField] private GameObject jobCanvas;
	[SerializeField] private GameObject jobSpriteObject;
	[SerializeField] private GameObject jobTextObject;
	[SerializeField] private GameObject jobNameObject;
	[SerializeField] private GameObject jobDifficultyObject;
	[SerializeField] private GameObject jobRewardObject;

	private Image jobSprite;
	private Text jobText;
	private Text jobName;
	private Text jobDifficulty;
	private Text jobReward;

	private Job currentJob;


	[SerializeField] private int smallerFontSize = 30;
	[SerializeField] private int originalFontSize = 34;

	public List<GameObject> jobObjectList = new List<GameObject>();


	void Awake(){
		instance = this;
	}

	void Start(){
		jobText = jobTextObject.GetComponent<Text> ();
		jobName = jobNameObject.GetComponent<Text> ();
		jobSprite = jobSpriteObject.GetComponent<Image> ();
		jobDifficulty = jobDifficultyObject.GetComponent<Text> ();
		jobReward = jobRewardObject.GetComponent<Text> ();
	}

	public void OpenJob(Job newJob, JobObject newJobObject){
		jobCanvas.SetActive (true);

		currentJobObject = newJobObject;
		currentJob = newJob;
		jobName.text = newJob.jobName;
		if (newJob.text.Length > 110)
			SetFontSize (smallerFontSize);
		jobText.text = newJob.text;
		jobSprite.sprite = newJob.sprite;
		jobDifficulty.text = "Difficulty: " + newJob.displayedDifficulty.ToString();
		jobReward.text = "Reward: " + newJob.goldReward.ToString();
	}

	public void CloseJob(){
		jobCanvas.SetActive (false);
		SetFontSize (originalFontSize);
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

	public void AddJobToList(GameObject job){
		jobObjectList.Add(job);
	}

	public void RemoveJob(GameObject job){
		jobObjectList.Remove (job);
	}

	public List<GameObject> GetJobObjectList(){
		return jobObjectList;
	}

	public void SetAllJobSelectability(bool newValue){
		foreach(GameObject jobObject in jobObjectList){
			JobObject thisJobObject = jobObject.GetComponent<JobObject> ();
			thisJobObject.SetSelectability (newValue);
			//Debug.Log ("Set accessible.");
		}
	}

	public void SetFontSize(int size){
		jobText.fontSize = size;
	}
}