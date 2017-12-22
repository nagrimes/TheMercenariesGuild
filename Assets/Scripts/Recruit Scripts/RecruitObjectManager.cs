using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecruitObjectManager : MonoBehaviour {

	public Recruit currentRecruit;
	static RecruitObjectManager currentRecruitObject;

	void OnMouseDown(){
		currentRecruitObject = this;
		RecruitManager.instance.OpenRecruitMenu (currentRecruit, currentRecruitObject);
	}

	public void DestroyRecruit(){
		Destroy (gameObject);
	}
}
