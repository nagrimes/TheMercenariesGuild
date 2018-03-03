using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecruitManager : MonoBehaviour {
	public static RecruitManager instance;
	public GameObject recruitMenu;
	[SerializeField] private GameObject recruitNameObject = null;
	[SerializeField] private GameObject recruitImageObject = null;
	[SerializeField] private GameObject healthValueObject = null;
	[SerializeField] private GameObject attackValueObject = null;
	[SerializeField] private GameObject defenseValueObject = null;
	[SerializeField] private GameObject costValueObject = null;
	private Text recruitName;
	private Image recruitImage;
	private Text recruitHealth;
	private Text recruitAttack;
	private Text recruitDefense;
	private Text recruitCost;
	private Recruit currentRecruit;
	public static RecruitObjectManager currentRecruitObject;

	private List<Recruit> recruits = new List<Recruit> ();

	void Awake(){
		instance = this;
	}

	void Start(){
		recruitName = recruitNameObject.GetComponent<Text> ();
		recruitImage = recruitImageObject.GetComponent<Image> ();
		recruitHealth = healthValueObject.GetComponent<Text> ();
		recruitAttack = attackValueObject.GetComponent<Text> ();
		recruitDefense = defenseValueObject.GetComponent<Text> ();
		recruitCost = costValueObject.GetComponent<Text> ();
	}

	public void OpenRecruitMenuWithText(Recruit recruit, RecruitObjectManager recruitObject){
		recruitMenu.SetActive (true);
		currentRecruit = recruit;
		PopulateMenu (recruit);
	}

	void PopulateMenu (Recruit recruit){
		recruitName.text = recruit.recruitName;
		recruitImage.sprite = recruit.sprite;
		recruitHealth.text = "Health: " + recruit.health.ToString ();
		recruitAttack.text = "Attack: " + recruit.attack.ToString ();
		recruitDefense.text = "Defense: " + recruit.defense.ToString ();
		recruitCost.text = "Cost: " + recruit.cost.ToString ();
	}

	public void CloseRecruitMenu(){
		//closes the recruitment menu.
		recruitMenu.SetActive(false);
	}

	public void AddRecruit(){
		recruits.Add (currentRecruit);
		CloseRecruitMenu ();
	}

	public void DeleteRecruit(){
		//removes the recruit object from the menu.
		CloseRecruitMenu();

	}

	public List<Recruit> GetRecruits(){
		return recruits;
	}
}