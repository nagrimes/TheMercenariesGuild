using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecruitObjectManager : MonoBehaviour {

	public Recruit currentRecruit;
	static RecruitObjectManager currentRecruitObject;

	void OnMouseDown(){
		currentRecruitObject = this;
		RecruitManager.instance.OpenRecruitMenuWithText (currentRecruit, currentRecruitObject);
	}

	public void DestroyRecruit(){
		Destroy (gameObject);
	}

	public void LoadRecruit(Recruit recruit){
		currentRecruit = recruit;
	}
}
