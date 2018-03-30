using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveJobManager : MonoBehaviour {
	[SerializeField] private GameObject jobCompletionBarGameObject = null;
	[SerializeField] private GameObject jobCompletionMenu = null;
	[SerializeField] private Text jobCompletionResultText = null;
	[SerializeField] private Text jobCompletionPayoutText = null;
	[SerializeField] private Slider jobCompletionBar = null;
	[SerializeField] private GameManager gameManager = null;
	[SerializeField] private float completionRateMultiplier = 1f;
	public bool winLose = true; //Temporary variable
	private bool jobInProgress = false;

	public void StartJob(Job currentJob){
		Debug.Log ("ActiveJobManager: Received request to start job");
		if (!jobInProgress) {
			Debug.Log ("AJM: Job in progress");
			jobCompletionBarGameObject.SetActive (true);
			jobCompletionBar.value = 0;
			StartCoroutine (ProgressJob (currentJob));
		}
	}

	private IEnumerator ProgressJob(Job currentJob){
		float i = 0;
		Debug.Log (currentJob.time);
		float rate = (100 / currentJob.time);
		Debug.Log (rate);
		while (i < 100) {
			jobCompletionBar.value = i;
			Debug.Log (Time.deltaTime * rate);
			i += (Time.deltaTime * rate) * completionRateMultiplier;
			yield return 0;
		}
		jobCompletionBarGameObject.SetActive (false);
		if (winLose) { //TODO Replace with win condition
			JobVictory (currentJob);
		} else {
			JobDefeat ();
		}
		jobCompletionMenu.SetActive (true);
	}

	void JobVictory(Job currentJob){
		jobCompletionResultText.text = "SUCCESS";
		jobCompletionPayoutText.text = "You've been awarded " + currentJob.goldReward + " gold!";
		gameManager.IncreaseGold (currentJob.goldReward);
	}

	void JobDefeat(){
		jobCompletionResultText.text = "FAILURE";
		jobCompletionPayoutText.text = "You've failed the job!";
	}

	public void CloseJobCompletionMenu(){
		jobCompletionMenu.SetActive (false);
	}
}
