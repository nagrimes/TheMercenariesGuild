using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#pragma warning disable 649

public class RecruitDoorManager : MonoBehaviour {

	[SerializeField] private Recruit currentRecruit;
	[SerializeField] private float timeUntilNewRecruit;
	[SerializeField] private RecruitManager recruitManager;
	static RecruitDoorManager recruitDoorObject;

	void Start(){
		StartCoroutine (BeginRecruitLoadCycle ());
	}

	void OnMouseDown(){
		Debug.Log ("Clicked");
		if (currentRecruit != null) {
			recruitDoorObject = this;
			RecruitManager.instance.OpenRecruitMenuWithText (currentRecruit, recruitDoorObject);
		}
	}

	void LoadRecruit(Recruit recruit){
		currentRecruit = recruit;
	}

	public void UnloadRecruit(){
		currentRecruit = null;
	}

	IEnumerator BeginRecruitLoadCycle(){
		float i = 0;
		float rate = 100 / 60	;
		while (i < timeUntilNewRecruit) {
			i += Time.deltaTime * rate;
			yield return 0;
		}
		//Load a new random recruit into the ROM
		//Debug.Log("Load recruit");
		Recruit[] recruits = recruitManager.GetAllRecruits();
		int r = Random.Range (0, Mathf.Clamp(recruits.Length, 0, 10));
		LoadRecruit (recruits [r]);
	}
}