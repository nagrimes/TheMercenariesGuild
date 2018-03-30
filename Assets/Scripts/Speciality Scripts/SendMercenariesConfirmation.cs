using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendMercenariesConfirmation : MonoBehaviour {
	[SerializeField] private GameObject confirmationCanvas = null;
	[SerializeField] private SendMercenariesManager sendMercenariesManager = null;
	[SerializeField] private JobManager jobManager = null;
	[SerializeField] private ActiveJobManager activeJobManager = null;

	public void AcceptConfirmation(){
		Debug.Log ("Confirmation: Request start job");
		CloseConfirmationMenu ();
		sendMercenariesManager.CloseMenu ();
		jobManager.DeleteJob ();
		activeJobManager.StartJob (jobManager.GetCurrentJob ());
	}

	public void DeclineConfirmation(){
		CloseConfirmationMenu ();
	}

	public void OpenConfirmationMenu(){
		confirmationCanvas.SetActive (true);
	}

	public void CloseConfirmationMenu(){
		confirmationCanvas.SetActive (false);
	}
}
