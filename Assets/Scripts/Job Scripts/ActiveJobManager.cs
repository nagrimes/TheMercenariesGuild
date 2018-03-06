using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveJobManager : MonoBehaviour {
	[SerializeField] private GameObject jobCompletionBarGameObject;
	[SerializeField] private Slider jobCompletionBar;
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
		float rate = 100 / currentJob.time;
		Debug.Log (rate);
		while (i < 100) {
			jobCompletionBar.value = i;
			Debug.Log (Time.deltaTime * rate);
			i += Time.deltaTime * rate;
			yield return 0;
		}
		jobCompletionBarGameObject.SetActive (false);

	}

}
