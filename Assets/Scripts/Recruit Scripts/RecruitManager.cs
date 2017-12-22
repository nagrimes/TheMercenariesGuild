using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecruitManager : MonoBehaviour {
	public static RecruitManager instance;
	public GameObject baseRecruitCanvas;
	public GameObject recruitCanvas;
	private Recruit currentRecruit;
	public static RecruitObjectManager currentRecruitObject;

	void Awake(){
		instance = this;
	}

	public void OpenRecruitMenu(Recruit recruit, RecruitObjectManager recruitObject){
		//opens recruit canvas (menu) object.
		//displays current recruit objects on the recruit menu.

		currentRecruit = recruit;
		currentRecruitObject = recruitObject;
		baseRecruitCanvas.SetActive (true);

		Transform textChild = recruitCanvas.transform.Find ("Recruit Name");
		Text n = textChild.GetComponent<Text> ();
		n.text = currentRecruit.recruitName;

		Transform imageChild = recruitCanvas.transform.Find ("Recruit Image");
		Image i = imageChild.GetComponent<Image> ();
		i.sprite = recruit.sprite;

		textChild = recruitCanvas.transform.Find ("Health Value");
		Text h = textChild.GetComponent<Text> ();
		h.text = "Health: " + currentRecruit.health.ToString ();

		textChild = recruitCanvas.transform.Find ("Attack Value");
		Text a = textChild.GetComponent<Text> ();
		a.text = "Attack: " + currentRecruit.attack.ToString ();

		textChild = recruitCanvas.transform.Find ("Defense Value");
		Text d = textChild.GetComponent<Text> ();
		d.text = "Defense: " + currentRecruit.defense.ToString();

		textChild = recruitCanvas.transform.Find ("Cost Value");
		Text c = textChild.GetComponent<Text> ();
		c.text = "Cost: " + currentRecruit.cost.ToString() + "G";
	}

	public void CloseRecruitMenu(){
		//closes the recruitment menu.
		baseRecruitCanvas.SetActive(false);
	}

	public void AddRecruit(){
		//adds the recruit to the user's recruited list.
		CloseRecruitMenu();
	}

	public void DeleteRecruit(){
		//removes the recruit object from the menu.
		CloseRecruitMenu();

	}
}
