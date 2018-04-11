using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour{
	public static UpgradeManager instance;

	public Text attackAndDefenseValue;
	public Text goldValue;
	public Text timeValue;
	public Text attackAndDefenseCost;
	public Text goldCost;
	public Text timeCost;
	public Button attackAndDefenseButton;
	public Button goldButton;
	public Button timeButton;
	public int startingUpgradeGoldCost;
	public int startingUpgradeLevel = 1;

	private int attackAndDefenseNum;
	private int goldNum;
	private int timeNum;

	void Awake(){
		instance = this;
		UpdateCost ("attackAndDefense", 1);
		UpdateCost ("gold", 1);
		UpdateCost ("time", 1);
	}

	//Function List:
	//increment level(whichValue)
	public void IncrementLevel(string whichValue){
		if (whichValue == "attackAndDefense") {
			attackAndDefenseNum = int.Parse (attackAndDefenseValue.text);
			attackAndDefenseNum++;
			attackAndDefenseValue.text = attackAndDefenseNum.ToString();
			UpdateCost (whichValue, attackAndDefenseNum + 1);
		} else if (whichValue == "gold") {
			goldNum = int.Parse (goldValue.text);
			goldNum++;
			goldValue.text = goldNum.ToString();
			UpdateCost (whichValue, goldNum + 1);
		} else if (whichValue == "time") {
			timeNum = int.Parse (timeValue.text);
			timeNum++;
			timeValue.text = timeNum.ToString ();
			UpdateCost (whichValue, timeNum + 1);
		}
	}

	//update cost
	public void UpdateCost(string whichValue, int currentLevel){
		int newCost = startingUpgradeGoldCost * (int)Mathf.Pow (currentLevel, 2);

		if (whichValue == "attackAndDefense")
			attackAndDefenseCost.text = "Cost: " + newCost;
		else if (whichValue == "gold")
			goldCost.text = "Cost: " + newCost;
		else if (whichValue == "time")
			timeCost.text = "Cost: " + newCost;
	}

	//update percentage increase
	//disableButton(levelValue, whichValue)
}
