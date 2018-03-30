using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SendMercenariesManager : MonoBehaviour {

	private static SendMercenariesManager instance;
	[SerializeField] private RecruitManager RecruitManager = null;
	[SerializeField] private JobManager JobManager = null;

	[SerializeField] private GameObject sendMercenariesCanvas = null;
	[SerializeField] private SendMercenariesConfirmation sendMercsConfirmationMenu = null;

	[SerializeField] private Text unitOneTextObject = null;
	[SerializeField] private Text unitTwoTextObject = null;
	[SerializeField] private Text unitThreeTextObject = null;
	[SerializeField] private Text unitFourTextObject = null;
	[SerializeField] private Text jobAttackValueObject = null;
	[SerializeField] private Text jobDefenseValueObject = null;
	[SerializeField] private Text partyAttackValueObject = null;
	[SerializeField] private Text partyDefenseValueObject = null;


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
