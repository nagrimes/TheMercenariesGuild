using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#pragma warning disable 649

public class RecruitManager : MonoBehaviour {
	public static RecruitManager instance;
	public GameObject recruitMenu;
	[SerializeField] private RecruitDoorManager currentRecruitObject;
	[SerializeField] private GameManager gameManager;

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

	[SerializeField] private Recruit startingRecruitProvidedAtStartOfGame;
	[SerializeField] private AllRecruits allRecruits;
	public List<Recruit> recruits = new List<Recruit> ();

	void Awake(){
		instance = this;
		AddRecruit (startingRecruitProvidedAtStartOfGame);
	}

	void Start(){
		recruitName = recruitNameObject.GetComponent<Text> ();
		recruitImage = recruitImageObject.GetComponent<Image> ();
		recruitHealth = healthValueObject.GetComponent<Text> ();
		recruitAttack = attackValueObject.GetComponent<Text> ();
		recruitDefense = defenseValueObject.GetComponent<Text> ();
		recruitCost = costValueObject.GetComponent<Text> ();
	}

	public void OpenRecruitMenuWithText(Recruit recruit, RecruitDoorManager recruitObject){
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
		if(gameManager.CheckDoesPlayerHaveEnoughGold(currentRecruit.cost)){
			recruits.Add (currentRecruit);
			gameManager.DecreaseGold (currentRecruit.cost);
			currentRecruitObject.UnloadRecruit ();
			CloseRecruitMenu ();
		}
	}

	//Only for use by the default recruit loader at the beginning of the game.
	void AddRecruit(Recruit recruit){
		recruits.Add (recruit);
		//Debug.Log ("Default recruit loaded.");
	}

	public void DeleteRecruit(){
		//removes the recruit object from the menu.
		currentRecruitObject.UnloadRecruit ();
		CloseRecruitMenu();
	}

	public List<Recruit> GetRecruits(){
		return recruits;
	}

	public Recruit[] GetAllRecruits(){
		return allRecruits.recruits;
	}
}