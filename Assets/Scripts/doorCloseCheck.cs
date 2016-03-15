using UnityEngine;
using System.Collections;
using System;

public class doorCloseCheck : MonoBehaviour {

	// Variables for state management, etc.
	public bool finalCheck = false;
	public AudioSource reminderAudio;

	private GameObject warningText;
	private GameObject gameManager;

	// Use this for initialization
	void Start () {
		// If this object isn't the final check, then it needs a child named "Warning Text"
		// which will display warning text if the player enters without closing the door
		// behind them.
		if (!finalCheck) {
			warningText = this.transform.FindChild ("Warning Text").gameObject;
			warningText.SetActive (false);
		}

		// gameManager is assigned the Game Object named "Game Manager".
		gameManager = GameObject.Find ("Game Manager");
	
		reminderAudio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){

		// TL;DR - If the player enters and the door is open, a warning is thrown, and if
		// they continue forward, then the report card is updated to reflect this. Once they
		// exit the final check, the whole thing is deactivated.

		if (col.gameObject.tag == "Player" && this.transform.parent.GetComponent<slidingDoorToggle> ().open && !this.transform.parent.gameObject.GetComponent<EventManager> ().completed) {
			if (finalCheck) {
				gameManager.GetComponent<ReportCardManager> ().writeLine ("USER DID NOT CLOSE DOOR TO PREVENT FIRE, EVEN WITH PROMPTING" + Environment.NewLine);
				string megaString = "You did not close the door when leaving the J-Pod.#";
				megaString += Environment.NewLine;
				megaString += "Closing the door is necessary to prevent the spread of fire.#";
				megaString += Environment.NewLine;
				megaString += "You should always close the door behind you during an evacuation.#";
				megaString += Environment.NewLine;
				gameManager.GetComponent<ReportCardManager> ().writeWrongLine(megaString);
				Debug.Log ("WOW RUDE WHAT IS WRONG WITH U");
				this.transform.parent.gameObject.GetComponent<EventManager> ().completed = true;
			} else {
				warningText.SetActive (true);
				Debug.Log ("hey, you should close the door");
				reminderAudio.Play();
			}
		} else if (col.gameObject.tag == "Player" && finalCheck && !this.transform.parent.gameObject.GetComponent<EventManager> ().completed) {
			this.gameObject.SetActive(false);
			if(!this.transform.parent.GetComponent<slidingDoorToggle> ().open ){
				this.transform.parent.gameObject.GetComponent<EventManager> ().completed = true;
				gameManager.GetComponent<ReportCardManager>().MaxScore++;
			}else{
				this.transform.parent.gameObject.GetComponent<EventManager> ().completed = true;
				gameManager.GetComponent<ReportCardManager>().score++;
				gameManager.GetComponent<ReportCardManager>().MaxScore++;
			}

		}

	}

	void OnTriggerExit(Collider col){
		if (col.gameObject.tag == "Player" && !finalCheck) {
			warningText.SetActive(false);
		}
	}
}
