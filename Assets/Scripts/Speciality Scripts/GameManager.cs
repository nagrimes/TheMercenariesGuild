using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#pragma warning disable 649

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	[SerializeField] private Text currencyText;
	private int gold;

	void Awake(){
		instance = this;
		gold = 6000;
	}

	void Update(){
		currencyText.text = gold.ToString ();
	}

	public void IncreaseGold(int amount){
		gold += amount;
	}

	public void DecreaseGold(int amount){
		gold -= amount;
	}
}
