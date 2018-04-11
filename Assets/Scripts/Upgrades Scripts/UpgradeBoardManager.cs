using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeBoardManager : MonoBehaviour {

	[SerializeField] private GameObject upgradeMenu;
	static UpgradeBoardManager upgradeBoardObject;

	void OnMouseDown(){
		upgradeBoardObject = this;
		upgradeMenu.SetActive (true);
	}

	public void CloseMenu(){
		upgradeMenu.SetActive (false);
	}
}
