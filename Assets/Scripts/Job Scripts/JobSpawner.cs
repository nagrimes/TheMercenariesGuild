using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#pragma warning disable 649

public class JobSpawner : MonoBehaviour {

	[SerializeField] private UpgradeManager upgradeManager;
	[SerializeField] private GameObject jobObject;
	[SerializeField] private GameObject loadedJob;
	[SerializeField] private AllJobs allJobs;
	[SerializeField] private JobBoard jobBoard;
	[SerializeField] private JobManager jobManager;
	int numberOfJobs;
	int playersAttackAndDefenseLevel;

	void Awake(){
		StartCoroutine (InitiateJobSpawnCycle());
	}

	IEnumerator InitiateJobSpawnCycle(){

		while (true) {
			/*
			max number of 2 jobs at a time
			system generates a job at a certain position and rotation, loading in a random job from a given
			set depending on the player's current attack and defense level. Then waits a certain amount of time
			before attempting again.
			*/

			if (numberOfJobs < 2) {
				//generate job
				//TODO: Add sound effect.
				SpawnJob ();
			}
			yield return new WaitForSeconds (7);
			//Debug.Log ("7 seconds passed.");
		}
	}

	public void DecrementNumberOfJobs(){
		numberOfJobs--;
	}

	void SpawnJob(){
		float randomX = Random.Range (-4.59f, -2.622f);
		float randomY = Random.Range (1.1f, 2.4f);
		loadedJob = Instantiate (jobObject, new Vector3 (randomX, randomY, -4.89f), Quaternion.Euler (90f, 0f, 0f));
		jobManager.AddJob (loadedJob);
		if (jobBoard.GetSelectability() == true)
			jobManager.SetAllJobSelectability (true);
		numberOfJobs++;
		int playerRank = upgradeManager.GetAttackAndDefenseRank();
		ChooseRandomJobFromSet (playerRank);
	}

	void ChooseRandomJobFromSet(int playerRank){
		Debug.Log ("Choosing from job section.");
		switch (playerRank) {
		case 1:
			LoadJob (Random.Range (0, 3));
			break;
		case 2:
			LoadJob (Random.Range (3, 6));
			break;
		case 3:
			LoadJob (Random.Range (6, 9));
			break;
		}
	}

	void LoadJob(int choice){
		Debug.Log ("Loading job.");
		JobObject loadedObjectScript = loadedJob.GetComponent<JobObject> ();
		loadedObjectScript.currentJob = allJobs.jobs [choice];
		loadedObjectScript.jobBoard = jobBoard;
	}
}