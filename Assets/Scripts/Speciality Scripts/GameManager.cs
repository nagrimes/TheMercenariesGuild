using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#pragma warning disable 649

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	[SerializeField] private Text currencyText;
	[SerializeField] private int startingGold = 6000;
	[SerializeField] private RecruitManager recruitManager;
	private int playerGold;

	void Awake(){
		instance = this;
		playerGold = startingGold;
	}

	void Update(){
		currencyText.text = playerGold.ToString ();
	}

	public void IncreaseGold(int amount){
		playerGold += amount;
	}

	public void DecreaseGold(int amount){
		playerGold -= amount;
	}

	public bool CheckDoesPlayerHaveEnoughGold(int amountRequested){
		if (playerGold < amountRequested)
			PrintNotEnoughGold ();
		return (playerGold >= amountRequested);
	}

	void PrintNotEnoughGold(){
		Debug.Log ("Insufficient gold.");
	}

	public int GetTotalRecruits(){
		return recruitManager.GetRecruits ().Count;
	}
}
