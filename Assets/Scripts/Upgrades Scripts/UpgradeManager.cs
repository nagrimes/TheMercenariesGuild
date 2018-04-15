using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour{
	public static UpgradeManager instance;
	public GameManager gameManager;

	public Text attackAndDefenseValueText;
	public Text goldValueText;
	public Text timeValueText;
	public Text attackAndDefenseCostText;
	public Text goldCostText;
	public Text timeCostText;
	public Button attackAndDefenseButton;
	public Button goldButton;
	public Button timeButton;
	public int startingUpgradeGoldCost;
	public int startingUpgradeLevel = 1;

	private int attackAndDefenseNum = 1;
	private int goldNum = 1;
	private int timeNum = 1;

	[SerializeField] private int attackAndDefenseCost;
	[SerializeField] private int goldCost;
	[SerializeField] private int timeCost;

	void Awake(){
		instance = this;
		UpdateCost ("attackAndDefense", attackAndDefenseNum);
		UpdateCost ("gold", goldNum);
		UpdateCost ("time", timeNum);
	}

	//Function List:
	public void IncrementLevelAndGoldByChoice(string whichValue){
		if (whichValue == "attackAndDefense" && gameManager.CheckDoesPlayerHaveEnoughGold(attackAndDefenseCost)) {
			IncrementLevelAndGold (ref attackAndDefenseNum, attackAndDefenseValueText, ref attackAndDefenseCost, whichValue);
		} else if (whichValue == "gold" && gameManager.CheckDoesPlayerHaveEnoughGold(goldCost)) {
			IncrementLevelAndGold (ref goldNum, goldValueText, ref goldCost, whichValue);
		} else if (whichValue == "time" && gameManager.CheckDoesPlayerHaveEnoughGold(timeCost)) {
			IncrementLevelAndGold (ref timeNum, timeValueText, ref timeCost, whichValue);
		}
	}

	public void UpdateCost(string whichValue, int currentLevel){
		int newCost = startingUpgradeGoldCost * (int)Mathf.Pow (currentLevel, 2);

		if (whichValue == "attackAndDefense") {
			attackAndDefenseCost = newCost;
			attackAndDefenseCostText.text = "Cost: " + attackAndDefenseCost.ToString();
		} else if (whichValue == "gold") {
			goldCost = newCost;
			goldCostText.text = "Cost: " + goldCost.ToString();
		} else if (whichValue == "time") {
			timeCost = newCost;
			timeCostText.text = "Cost: " + timeCost.ToString();
		}
	}

	void IncrementValue(ref int whichNum){
		whichNum++;
	}

	void UpdateText(int whichNum, Text whichValueText){
		whichValueText.text = whichNum.ToString ();
	}

	void IncrementLevelAndGold(ref int whichNum, Text whichValueText, ref int whichCost, string whichValue){
		IncrementValue (ref whichNum);
		Debug.Log (whichNum);
		UpdateText (whichNum, whichValueText);
		gameManager.DecreaseGold (whichCost);
		UpdateCost (whichValue, whichNum + 1);
	}

	public int GetAttackAndDefenseRank(){
		return attackAndDefenseNum;
	}
}
