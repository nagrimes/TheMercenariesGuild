using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
#pragma warning disable 649

public class RecruitBookManager : MonoBehaviour {

	private static RecruitBookManager instance;

	[SerializeField] private Text unitOneNameTextObject;
	[SerializeField] private Text unitTwoNameTextObject;
	[SerializeField] private Text unitThreeNameTextObject;
	[SerializeField] private Text unitFourNameTextObject;

	[SerializeField] private Text unitOneAttackTextObject;
	[SerializeField] private Text unitTwoAttackTextObject;
	[SerializeField] private Text unitThreeAttackTextObject;
	[SerializeField] private Text unitFourttackTextObject;

	[SerializeField] private Text unitOneDefenseTextObject ;
	[SerializeField] private Text unitTwoDefenseTextObject;
	[SerializeField] private Text unitThreeDefenseTextObject;
	[SerializeField] private Text unitFourDefenseTextObject;

	[SerializeField] private Text unitOneHPTextObject ;
	[SerializeField] private Text unitTwoHPTextObject;
	[SerializeField] private Text unitThreeHPTextObject;
	[SerializeField] private Text unitFourHPTextObject;

	[SerializeField] private GameObject unitOneContentObject;
	[SerializeField] private GameObject unitTwoContentObject;
	[SerializeField] private GameObject unitThreeContentObject;
	[SerializeField] private GameObject unitFourContentObject;

	[SerializeField] private RecruitManager recruitManager;
	[SerializeField] private GameObject recruitBookCanvas;

	void Start(){
		instance = this;
	}

	public void OpenRecruitBookMenu(){

		recruitBookCanvas.SetActive(true);
		List<Recruit> recruitsList = new List<Recruit>();
		recruitsList = recruitManager.GetRecruits ();
		UpdatePartySelectables ();
		PrintNamesToUI (recruitsList);
		PrintAttackToUI (recruitsList);
		PrintDefenseToUI (recruitsList);
		PrintHPToUI (recruitsList);
	}

	public void CloseMenu(){
		ResetPartySelectables ();
		recruitBookCanvas.SetActive (false);
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
			unitOneNameTextObject.text = recruitsList.ElementAt (0).recruitName.ToString ();
			unitTwoNameTextObject.text = recruitsList.ElementAt (1).recruitName.ToString ();
			unitThreeNameTextObject.text = recruitsList.ElementAt (2).recruitName.ToString ();
			unitFourNameTextObject.text = recruitsList.ElementAt (3).recruitName.ToString ();
		}
		catch(System.Exception e){
			Debug.Log (e);
		}
	}
	void PrintAttackToUI(List<Recruit> recruitsList){
		try{
			unitOneAttackTextObject.text = "Attack: " + recruitsList.ElementAt (0).attack.ToString ();
			unitTwoAttackTextObject.text = "Attack: " + recruitsList.ElementAt (1).attack.ToString ();
			unitThreeAttackTextObject.text = "Attack: " + recruitsList.ElementAt (2).attack.ToString ();
			unitFourttackTextObject.text = "Attack: " + recruitsList.ElementAt (3).attack.ToString ();
		}
		catch(System.Exception e){
			Debug.Log (e);
		}
	}
	void PrintDefenseToUI(List<Recruit> recruitsList){
		try{
			unitOneDefenseTextObject.text = "Defense:  " + recruitsList.ElementAt (0).defense.ToString ();
			unitTwoDefenseTextObject.text = "Defense:  " + recruitsList.ElementAt (1).defense.ToString ();
			unitThreeDefenseTextObject.text = "Defense:  " + recruitsList.ElementAt (2).defense.ToString ();
			unitFourDefenseTextObject.text = "Defense:  " + recruitsList.ElementAt (3).defense.ToString ();
		}
		catch(System.Exception e){
			Debug.Log (e);
		}
	}
	void PrintHPToUI(List<Recruit> recruitsList){
		try{
			unitOneHPTextObject.text = "HP: " + recruitsList.ElementAt (0).health.ToString ();
			unitTwoHPTextObject.text = "HP: " + recruitsList.ElementAt (1).health.ToString ();
			unitThreeHPTextObject.text = "HP: " + recruitsList.ElementAt (2).health.ToString ();
			unitFourHPTextObject.text = "HP: " + recruitsList.ElementAt (3).health.ToString ();
		}
		catch(System.Exception e){
			Debug.Log (e);
		}
	}
}
