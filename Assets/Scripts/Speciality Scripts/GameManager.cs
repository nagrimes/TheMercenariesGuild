using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	[SerializeField] private Text currencyText = null;
	private int gold;

	void Awake(){
		instance = this;
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
