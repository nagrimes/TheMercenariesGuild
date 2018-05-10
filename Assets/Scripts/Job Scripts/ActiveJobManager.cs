using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#pragma warning disable 649

public class ActiveJobManager : MonoBehaviour {
	[SerializeField] private GameObject jobCompletionBarGameObject;
	[SerializeField] private GameObject jobCompletionMenu;
	[SerializeField] private SendMercenariesManager sendMercenariesManager;
	[SerializeField] private Text jobCompletionResultText;
	[SerializeField] private Text jobCompletionPayoutText;
	[SerializeField] private Text jobCompletionAftermathText;
	[SerializeField] private Slider jobCompletionBar;
	[SerializeField] private GameManager gameManager;
	[SerializeField] private UpgradeManager upgradeManager;
	[SerializeField] private float completionRateMultiplier = 1f;
	public bool winLose = true; //Temporary variable
	private bool jobInProgress = false;
	private int totalPartyPower;

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
		float rate = (100 / (currentJob.time - (currentJob.time * (.1f * (upgradeManager.GetTimeRank() - 1)))));
		Debug.Log (rate);
		while (i < 100) {
			jobCompletionBar.value = i;
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
		jobCompletionPayoutText.text = "You've been awarded " + (currentJob.goldReward + (currentJob.goldReward * (.1f * (upgradeManager.GetGoldRank() - 1)))) + " gold!";
		jobCompletionAftermathText.text = "Each party member lost " + CalculateHPAftermath (currentJob) + " HP!";
		gameManager.IncreaseGold ((int)(currentJob.goldReward + (currentJob.goldReward * (.1f * (upgradeManager.GetGoldRank() - 1)))));
	}

	void JobDefeat(){
		jobCompletionResultText.text = "FAILURE";
		jobCompletionPayoutText.text = "You've failed the job!";
	}

	public void CloseJobCompletionMenu(){
		jobCompletionMenu.SetActive (false);
	}

	int CalculateHPAftermath(Job currentJob){
		int damage = (int)Mathf.Clamp(Mathf.Round((currentJob.hiddenDifficultyValue - totalPartyPower) / gameManager.GetTotalRecruits()), 0, Mathf.Infinity);
		return damage;
	}

	public void SetPartyPower(){
		totalPartyPower = sendMercenariesManager.GetPartyAttackValue () + sendMercenariesManager.GetPartyDefenseValue ();
	}
}
