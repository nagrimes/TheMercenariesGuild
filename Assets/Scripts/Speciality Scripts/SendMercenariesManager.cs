using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
#pragma warning disable 649

public class SendMercenariesManager : MonoBehaviour {

	private static SendMercenariesManager instance;
	[SerializeField] private RecruitManager recruitManager;
	[SerializeField] private JobManager jobManager;
	[SerializeField] private UpgradeManager upgradeManager;
	[SerializeField] private ActiveJobManager activeJobManager;

	[SerializeField] private GameObject sendMercenariesCanvas;
	[SerializeField] private SendMercenariesConfirmation sendMercsConfirmationMenu;

	[SerializeField] private Text unitOneTextObject ;
	[SerializeField] private Text unitTwoTextObject;
	[SerializeField] private Text unitThreeTextObject;
	[SerializeField] private Text unitFourTextObject;

	[SerializeField] private GameObject unitOneContentObject;
	[SerializeField] private GameObject unitTwoContentObject;
	[SerializeField] private GameObject unitThreeContentObject;
	[SerializeField] private GameObject unitFourContentObject;

	[SerializeField] private Text jobDifficultyValueObject;
	[SerializeField] private Text partyAttackValueObject;
	[SerializeField] private Text partyDefenseValueObject;

	private int partyAttackValue = 0;
	private int partyDefenseValue = 0;

	void Start () {
		instance = this;
	}

	public void OpenSendMercenariesMenu(){
		
		sendMercenariesCanvas.SetActive(true);
		List<Recruit> recruitsList = new List<Recruit>();
		recruitsList = recruitManager.GetRecruits ();
		Job currentJob = jobManager.GetCurrentJob ();
		Debug.Log (recruitsList.ElementAt(0).recruitName);
		UpdatePartySelectables ();
		PrintNamesToUI (recruitsList);
		UpdatePartyValues(recruitsList);
		jobDifficultyValueObject.text = "Difficulty: " + currentJob.displayedDifficulty;
	}

	public void CloseMenu(){
		ResetPartySelectables ();
		ResetPartyValues ();
		sendMercenariesCanvas.SetActive (false);
	}

	public void Accept(){
		sendMercsConfirmationMenu.OpenConfirmationMenu ();
	}


	void UpdatePartySelectables(){
		int capacity = recruitManager.GetRecruits ().Count;
		Debug.Log ("Capacity " + capacity);	
		switch (capacity) {
		case 1:
			unitOneContentObject.SetActive (true);
			break;
		case 2:
			unitOneContentObject.SetActive (true);
			unitTwoContentObject.SetActive (true);
			break;
		case 3:
			unitOneContentObject.SetActive (true);
			unitTwoContentObject.SetActive (true);
			unitThreeContentObject.SetActive (true);
			break;
		case 4:
			unitOneContentObject.SetActive (true);
			unitTwoContentObject.SetActive (true);
			unitThreeContentObject.SetActive (true);
			unitFourContentObject.SetActive (true);
			break;
		default:
			break;
		}
	}

	void ResetPartySelectables(){
		unitOneContentObject.SetActive (false);
		unitTwoContentObject.SetActive (false);
		unitThreeContentObject.SetActive (false);
		unitFourContentObject.SetActive (false);
	}

	void PrintNamesToUI(List<Recruit> recruitsList){
		try{
			unitOneTextObject.text = recruitsList.ElementAt (0).recruitName.ToString ();
			unitTwoTextObject.text = recruitsList.ElementAt (1).recruitName.ToString ();
			unitThreeTextObject.text = recruitsList.ElementAt (2).recruitName.ToString ();
			unitFourTextObject.text = recruitsList.ElementAt (3).recruitName.ToString ();
		}
		catch(System.Exception e){
			Debug.Log (e);
		}
	}

	void UpdatePartyValues(List<Recruit> recruitsList){
		foreach (Recruit r in recruitsList) {
			partyAttackValue += r.attack + ((upgradeManager.GetAttackAndDefenseRank() - 1) * 3);
		}
		foreach (Recruit r in recruitsList) {
			partyDefenseValue += r.defense + ((upgradeManager.GetAttackAndDefenseRank() - 1) * 3);;
		}
		partyAttackValueObject.text = "Attack: " + partyAttackValue;
		partyDefenseValueObject.text = "Defense: " + partyDefenseValue;
	}

	void ResetPartyValues(){
		partyAttackValue = 0;
		partyDefenseValue = 0;
	}

	public void SendPartyValuesToActiveJobManager(){
		activeJobManager.SetPartyPower ();
	}

	public int GetPartyAttackValue(){
		return partyAttackValue;
	}

	public int GetPartyDefenseValue(){
		return partyDefenseValue;
	}
}
