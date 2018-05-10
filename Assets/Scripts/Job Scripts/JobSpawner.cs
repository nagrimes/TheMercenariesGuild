using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#pragma warning disable 649

public class JobSpawner : MonoBehaviour {

	[SerializeField] private UpgradeManager upgradeManager;
	[SerializeField] private GameObject jobPrefab;
	[SerializeField] private GameObject loadedJob;
	[SerializeField] private AllJobs allJobs;
	[SerializeField] private JobBoard jobBoard;
	[SerializeField] private JobManager jobManager;
	[SerializeField] private GameManager gameManager;
	private static float boardZLocation = -4.89f;
	[SerializeField] private Vector3 boardOrigin = new Vector3(-3.48f, 1.88f, boardZLocation);
	[SerializeField] private Vector3[] quadrantMin;
	[SerializeField] private Vector3[] quadrantMax;
	int numberOfJobs;
	int playersAttackAndDefenseLevel;

	void Awake(){
		StartCoroutine (InitiateJobSpawnCycle());
	}

	IEnumerator InitiateJobSpawnCycle(){

		while (true) {
			/*
			 * max number of 2 jobs at a time
			 * system generates a job at a certain position and rotation, loading in a random job from a given
			 * set depending on the player's current attack and defense level. Then waits a certain amount of time
			 * before attempting again.
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
		loadedJob = Instantiate (jobPrefab, boardOrigin, Quaternion.Euler (90f, 0f, 0f));
		SetJobObjectToQuadrant ();
		jobManager.AddJobToList (loadedJob);
		if (jobBoard.GetSelectability() == true)
			jobManager.SetAllJobSelectability (true);
		numberOfJobs++;
		int playerRank = gameManager.GetTotalRecruits ();
		ChooseRandomJobFromSet (playerRank);
	}

	//TODO: Redo this based on number of recruits player has.
	void ChooseRandomJobFromSet(int playerRank){
		Debug.Log ("Choosing from job section.");
		switch (playerRank) {
		case 1:
			LoadJob (Random.Range (0, 4));
			break;
		case 2:
			LoadJob (Random.Range (2, 6));
			break;
		case 3:
			LoadJob (Random.Range (4, 8));
			break;
		case 4:
			LoadJob (Random.Range (6, 10));
			break;
		}
	}

	//Confusion, what is this for again?
	void LoadJob(int choice){
		Debug.Log ("Loading job.");
		JobObject loadedObjectScript = loadedJob.GetComponent<JobObject> ();
		loadedObjectScript.currentJob = allJobs.jobs [choice];
		loadedObjectScript.jobBoard = jobBoard;
	}
		
	void SetJobObjectToQuadrant(){
		//If there is already a job on the board, then make sure that this new job isn't in the same quadrant.
		if (jobManager.GetJobObjectList ().Count > 0) {
			GameObject jobObject = jobManager.GetJobObjectList () [0];
			JobObject jobScript = jobObject.GetComponent<JobObject>();
			int avoidQuadrant = jobScript.boardQuadrant;
			int randomQuadrant = GetRandomQuadrant (avoidQuadrant);
			SetQuadrantPosition (randomQuadrant);
		} else {
			int randomQuadrant = GetRandomQuadrant ();
			SetQuadrantPosition (randomQuadrant);
		}
	}

	void SetQuadrantPosition(int randomQuadrant){
		float randomXInQuadrant = Random.Range (quadrantMin [randomQuadrant].x, quadrantMax [randomQuadrant].x);
		float randomYInQuadrant = Random.Range (quadrantMin [randomQuadrant].y, quadrantMax [randomQuadrant].y);
		Vector3 newPosition = new Vector3 (randomXInQuadrant, randomYInQuadrant, boardZLocation);
		loadedJob.gameObject.transform.position = newPosition;
		loadedJob.GetComponent<JobObject> ().boardQuadrant = randomQuadrant;
	}

	int GetRandomQuadrant(){
		return Random.Range (0, 4); // returns random int range 0-3 all inclusive.
	}
	int GetRandomQuadrant(int avoidQuadrant){
		int result;
		do{
			result = Random.Range (0, 4); // returns random int range 0-3 all inclusive.
		}while(result == avoidQuadrant);
		return result;
	}
}