using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#pragma warning disable 649

public class RecruitBook : MonoBehaviour {

	[SerializeField] private RecruitBookManager recruitBookManager;

	void OnMouseDown(){
		recruitBookManager.OpenRecruitBookMenu ();
	}
}
