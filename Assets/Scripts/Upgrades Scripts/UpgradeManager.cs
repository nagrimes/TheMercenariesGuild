using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour{
	public static UpgradeManager instance;

	public Text attackValue;
	public Text defenseValue;
	public Text goldValue;
	public Text attackGoldCost;
	public Text defenseGoldCost;
	public Text goldGoldCost;
	public Button attackButton;
	public Button defenseButton;
	public Button goldButton;
	public int startingUpgradeGoldCost;

	private int attackNum;
	private int defenseNum;
	private int goldNum;

	void Awake(){
		instance = this;
		UpdateCost ("attack", 1);
		UpdateCost ("defense", 1);
		UpdateCost ("gold", 1);
	}

	//Function List:
	//increment level(whichValue)
	public void IncrementLevel(string whichValue){
		if (whichValue == "attack") {
			attackNum = int.Parse (attackValue.text);
			attackNum++;
			attackValue.text = attackNum.ToString();
			UpdateCost (whichValue, attackNum + 1);
		} else if (whichValue == "defense") {
			defenseNum = int.Parse (defenseValue.text);
			defenseNum++;
			defenseValue.text = defenseNum.ToString();
			UpdateCost (whichValue, defenseNum + 1);
		} else if (whichValue == "gold") {
			goldNum = int.Parse (goldValue.text);
			goldNum++;
			goldValue.text = goldNum.ToString ();
			UpdateCost (whichValue, goldNum + 1);
		}
	}

	//update cost
	public void UpdateCost(string whichValue, int currentLevel){
		int newCost = startingUpgradeGoldCost * (int)Mathf.Pow (currentLevel, 2);

		if (whichValue == "attack")
			attackGoldCost.text = "Cost: " + newCost;
		else if (whichValue == "defense")
			defenseGoldCost.text = "Cost: " + newCost;
		else if (whichValue == "gold")
			goldGoldCost.text = "Cost: " + newCost;
	}

	//update percentage increase
	//disableButton(levelValue, whichValue)
}
