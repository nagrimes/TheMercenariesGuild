using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
#pragma warning disable 649

public class SendMercenariesManager : MonoBehaviour {

	private static SendMercenariesManager instance;
	[SerializeField] private RecruitManager RecruitManager = null;
	[SerializeField] private JobManager JobManager = null;

	[SerializeField] private GameObject sendMercenariesCanvas = null;
	[SerializeField] private SendMercenariesConfirmation sendMercsConfirmationMenu = null;

	[SerializeField] private Text unitOneTextObject ;
	[SerializeField] private Text unitTwoTextObject;
	[SerializeField] private Text unitThreeTextObject;
	[SerializeField] private Text unitFourTextObject;
	[SerializeField] private Text jobDifficultyValueObject;
	[SerializeField] private Text partyAttackValueObject;
	[SerializeField] private Text partyDefenseValueObject;


	void Start () {
		instance = this;
	}

	public void OpenSendMercenariesMenu(){
		
		sendMercenariesCanvas.SetActive(true);
		List<Recruit> recruitsList = new List<Recruit>();
		recruitsList = RecruitManager.GetRecruits ();
		Job currentJob = JobManager.GetCurrentJob ();
		Debug.Log (recruitsList.ElementAt(0).recruitName);

		unitOneTextObject.text = recruitsList.ElementAt (0).recruitName.ToString ();
	}

	public void CloseMenu(){
		sendMercenariesCanvas.SetActive (false);
	}

	public void Accept(){
		sendMercsConfirmationMenu.OpenConfirmationMenu ();
	}
}
