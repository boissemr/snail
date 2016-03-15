using UnityEngine;
using System.Collections;

public class destination : MonoBehaviour {

	// Public string which is the name of the location.
	public string locationName = "HERE";
	public GameObject[] thingsToShow;   // array of helper objects to display (e.g., text / trail on the floor)
	private bool helpersShown = false;

	// provide audio feedback when the player reaches the destination
	public AudioClip feedbackAudio;
	private GameObject player;
	private AudioSource playerSource;

	// Used to store the Game Manager.
	private GameObject gameManager;
	private ReportCardManager reportCard;

	// Use this for initialization
	void Start () {
		// Assigns gameManager to a gameobject named "Game Manager".
		gameManager = GameObject.Find ("Game Manager");

		reportCard = gameManager.GetComponent<ReportCardManager> ();

		// get player's audio source component
		player = GameObject.Find ("First Person Controller");
		playerSource = player.GetComponent<AudioSource> ();

		// Sends a finished setup notification to this component's gameobject's event manager component.
		this.gameObject.GetComponent<EventManager> ().setupDone = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.gameObject.GetComponent<EventManager>().current && !helpersShown) {
			// If there are helper objects that need to be displayed, do it when this event is activated
			if (thingsToShow.Length > 0) { 
				Debug.Log(gameObject.name.ToString() +  " - Turning on helper objects");
				foreach (GameObject item in thingsToShow) {
					item.SetActive(true);
					Debug.Log(gameObject.name.ToString() +  " - Showing " + item.name.ToString() );
				}
			}
			helpersShown = true;
		}


		
	}

	void Awake () {

	}

	void MarkAsCompleted(){
		// mark as done.  this can be invoked after a delay for audio
		this.gameObject.GetComponent<EventManager> ().completed = true;
	}


	// If the player enters this, the event manager attached to this collider is completed.
	void OnTriggerEnter(Collider other){
		if(other.tag=="Player"){
			reportCard.writeLine("Player arrived at " + locationName + " at " + Time.timeSinceLevelLoad);

			Debug.Log("You made it to the destination!");
			// play audio feedback
			if (feedbackAudio != null){
				//Debug.Log ("Playing feedback audio for destination");
				playerSource.clip =  feedbackAudio;
				playerSource.Play();
			}

			// also need to deactivate helper objects if any
			if (thingsToShow.Length > 0) { 
				Debug.Log(gameObject.name.ToString() +  " - Turning off helper objects");
				foreach (GameObject item in thingsToShow) {
					item.SetActive(false);
					Debug.Log(gameObject.name.ToString() +  " - Hiding " + item.name.ToString() );
				}
				//helpersShown = false;  // NOTE:  If this line runs, the update function immediately re-enables objects
			}

			// mark as done
			//this.gameObject.GetComponent<EventManager> ().completed = true;
			Invoke ("MarkAsCompleted", 0.5f);
		}
	}
}
