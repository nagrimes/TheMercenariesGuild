using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#pragma warning disable 649

public class SendMercenariesConfirmation : MonoBehaviour {
	[SerializeField] private GameObject confirmationCanvas;
	[SerializeField] private SendMercenariesManager sendMercenariesManager;
	[SerializeField] private JobManager jobManager;
	[SerializeField] private ActiveJobManager activeJobManager;

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
