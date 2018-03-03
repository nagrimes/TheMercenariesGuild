using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SendMercenariesManager : MonoBehaviour {

	private static SendMercenariesManager instance;
	[SerializeField] private RecruitManager RecruitManager;
	[SerializeField] private JobManager JobManager;

	[SerializeField] private GameObject sendMercenariesCanvas;

	[SerializeField] private Text unitOneTextObject;
	[SerializeField] private Text unitTwoTextObject;
	[SerializeField] private Text unitThreeTextObject;
	[SerializeField] private Text unitFourTextObject;
	[SerializeField] private Text jobAttackValueObject;
	[SerializeField] private Text jobDefenseValueObject;
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

	public void SendMercenaries(){
		
		//open prompt to ask player if they want to send this party
		//if prompt returns true, close menu and start quest
		//if prompt returns false, keep menu open


	}
}
