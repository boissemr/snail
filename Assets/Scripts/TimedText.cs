using UnityEngine;
using System.Collections;

public class TimedText : MonoBehaviour {

	public AudioClip thisClip;

	private GameObject player;
	private AudioSource playerSource;

	private float startTime;
	private float waitTime = 2.0f;
	public float delay = 15.0f;
	public float extraDelay = 1.25f;

	public GameObject[] thingsToShow;   // array of helper objects to display (e.g., text / trail on the floor)
	private bool helpersShown = false;
	public bool leaveHelpersAfter = false;  // should helper objects persist after task is done (e.g. a trail on the floor)?


	void Start(){
		player = GameObject.Find ("First Person Controller");
		playerSource = player.GetComponent<AudioSource> ();
		startTime = Time.time;
	}

	void Update(){
		// turn on helper objects when this is relevant... turn off later
		if (this.gameObject.GetComponent<EventManager>().current && !helpersShown) {
			// If there are helper objects that need to be displayed, do it when this event is activated
			if (thingsToShow.Length > 0) { 
				Debug.Log(gameObject.name.ToString() +  " - Turning on helper objects");
				foreach (GameObject item in thingsToShow) {
					item.SetActive(true);
				}
			}
			helpersShown = true;
		}

		// take care of timing and move on when done
		if (Time.time - startTime >= waitTime) {
			if (Input.GetButtonDown ("Fire1")) {
				playerSource.Stop();
				this.gameObject.GetComponent<EventManager> ().completed = true;
				this.gameObject.SetActive (false);

				// also need to deactivate helper objects if any
				if (leaveHelpersAfter==false && thingsToShow.Length > 0) {   // bug in the leaveHelpers logic???
					Debug.Log(gameObject.name.ToString() +  " - Turning off helper objects");
					foreach (GameObject item in thingsToShow) {
						item.SetActive(false);
					}
					helpersShown = false;
				}

			}
		}


	}

	public IEnumerator delayText(){
		player = GameObject.Find ("First Person Controller");
		playerSource = player.GetComponent<AudioSource> ();
		if (thisClip != null) {
			playerSource.clip = thisClip;
			playerSource.Play ();
			yield return new WaitForSeconds (playerSource.clip.length + extraDelay);
		} else {
			yield return new WaitForSeconds (delay);
		}
		//Debug.Log ("I waited!");
		this.gameObject.GetComponent<EventManager> ().completed = true;
		this.gameObject.SetActive(false);
	}


	/* would the code to deactivate the current object go here? (in this script) 
	 * I figured it would because then we could just have it able to run for multiple 
	 * types of obejcts instead of having to write everything in every other script.
	 * Also if we do deactivate the object that has this script, would it go before or after the yield return? 
	 * I was thinking before but I wasn't sure if that would just shut it off entirely before it did the delay.
	 * But on the other hand it can't come after the yield return because the methods breaks out when it calls the return
	 * 
	 * this.gameObject.SetActive(false);
	 * 
	 * I made a duplicate of one of the question canvases and attahced this script to it. I seem to get an error that comes from the 
	 * hash table having a duplicate key. I might have just missd something with the way we are handling the hash table and maybe it could be a problem with a 
	 * having duplicate questions. I will check with marcus monday. It's probably something small that needs fixing. 
	 */



}
