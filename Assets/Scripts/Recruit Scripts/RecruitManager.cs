using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecruitManager : MonoBehaviour {
	public static RecruitManager instance;
	public GameObject recruitMenu;
	[SerializeField] private GameObject recruitNameObject;
	[SerializeField] private GameObject recruitImageObject;
	[SerializeField] private GameObject healthValueObject;
	[SerializeField] private GameObject attackValueObject;
	[SerializeField] private GameObject defenseValueObject;
	[SerializeField] private GameObject costValueObject;
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

	public void OpenRecruitMenu(Recruit recruit, RecruitObjectManager recruitObject){
		//opens recruit canvas (menu) object.
		//displays current recruit objects on the recruit menu.

		recruitMenu.SetActive (true);
		
		recruitName.text = recruit.recruitName;
		recruitImage.sprite = recruit.sprite;
		recruitHealth.text = "Health: " + recruit.health.ToString();
		recruitAttack.text = "Attack: " + recruit.attack.ToString ();
		recruitDefense.text = "Defense: " + recruit.defense.ToString ();
		recruitCost.text = "Cost: " + recruit.cost.ToString ();
	}

	public void CloseRecruitMenu(){
		//closes the recruitment menu.
		recruitMenu.SetActive(false);
	}

	public void AddRecruit(){
		//adds the recruit to the user's recruited list.
		CloseRecruitMenu();
	}

	public void DeleteRecruit(){
		//removes the recruit object from the menu.
		CloseRecruitMenu();

	}

	public List<Recruit> GetRecruits(){
		return recruits;
	}

	public void AddRecruit(Recruit recruit){
		recruits.Add (recruit);
	}
}
