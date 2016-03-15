using UnityEngine;
using System.Collections;

public class pickupScript : MonoBehaviour {

	public GameObject reticle;

	public bool pickUp;
	public bool crib = false;
	public GameObject[] thingsToShow;   // array of helper objects to display (e.g., text / trail on the floor)
	private bool helpersShown = false;

	// provide audio feedback when the player reaches the destination
	public AudioClip feedbackAudio;
	private GameObject player;
	private AudioSource playerSource;
	 
	private new AudioSource audio; 
	private Color originalColor;

	// Declaration of variables used for raycasting out of the camera.
	private Camera mCamera; // mCamera is the Main Camera, thus the M.
	private Ray cameRay;
	private RaycastHit hit;

	// Use this for initialization
	void Start () {

		audio = GetComponent<AudioSource>();
		reticle = GameObject.Find ("ReticlePlane");

		originalColor = this.gameObject.GetComponent<Renderer> ().material.color;

		try {
			mCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		} catch {
			Debug.Log ("Main camera not found.");
		}
		
		// Creates a ray shooting straight out of the center of the viewpoint of the camera.
		cameRay = mCamera.ViewportPointToRay(new Vector3(0.5f,0.5f,0));

		// get player's audio source component
		player = GameObject.Find ("First Person Controller");
		playerSource = player.GetComponent<AudioSource> ();
	}


	void MarkAsCompleted(){
		// mark as done.  Can be invoked after a slight delay for audio
		this.gameObject.GetComponent<EventManager>().completed = true;
	}



	// Update is called once per frame
	void Update () {
		if (this.gameObject.GetComponent<EventManager>().current  && !helpersShown) {
			// If there are helper objects that need to be displayed, do it when this event is activated
			if (thingsToShow.Length > 0) { 
				Debug.Log( gameObject.name.ToString() +  "Turning on helper objects");
				foreach (GameObject item in thingsToShow) {
					item.SetActive(true);
				}
			}
			helpersShown = true;
		}


		//sets the distance of the ray drawn. Affects actual coliding distance from the camera.
		Debug.DrawRay (mCamera.transform.position, mCamera.transform.forward * 4, Color.blue);
		// This variable is used to track whether or not the raycast from the camera hit
		// anything. This information is used for 'hovering' purposes.
		bool noHit = true;
		if (crib && this.gameObject.GetComponent<EventManager> ().current) {
			this.gameObject.GetComponent<BoxCollider> ().enabled = true;
		} else if(crib) {
			this.gameObject.GetComponent<BoxCollider> ().enabled = false;
		}
		// This draws a new raycast every frame.
		cameRay = mCamera.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0));
		// Checks if the raycast hit an answer, and only runs if the question has not
		// been completed.
		if (Physics.Raycast (cameRay, out hit) && this.gameObject.GetComponent<EventManager>().current) {
			// If the raycast hits a possible answer, the answer is "hovered" and noHit
			// is set to false. If the Fire1 (LMB at time of writing) is pressed, the
			// answer is selected.
			if (hit.collider.gameObject == this.gameObject && !this.gameObject.GetComponent<EventManager>().completed) {
				//Debug.Log ("I SEE YOU LIL GUY");
				this.gameObject.GetComponent<Renderer> ().material.color = Color.blue;
				noHit = false;

				if(Input.GetButtonDown("Fire1")){
					//this.gameObject.GetComponent<EventManager>().completed = true;
					Invoke ("MarkAsCompleted", 0.5f);

					// play audio feedback
					if (feedbackAudio != null){
						Debug.Log ("Playing feedback audio for pickup");
						playerSource.clip =  feedbackAudio;
						playerSource.Play();
					}

					// also need to deactivate helper objects if any
					// If there are helper objects that need to be displayed, do it when this object is activated
					if (thingsToShow.Length > 0) { 
						Debug.Log(gameObject.name.ToString() +  " - Turning off helper objects");
						foreach (GameObject item in thingsToShow) {
							item.SetActive(false);
						}
					}

					//Debug.Log ("I completed this");
					//audio.Play(); //<-- redundant
					if(crib){
						this.gameObject.GetComponent<cribScript>().crib.gameObject.SetActive(true);
						this.gameObject.SetActive(false);

					}
					if(pickUp){
						this.gameObject.SetActive(false);


					}




				}
			}
			// Checks if the raycast hits the gameObject attached to this code.
	
		}
		// If the raycast didn't hit anything, then all answers are "unhovered".
		if (noHit) {
			this.gameObject.GetComponent<Renderer> ().material.color = originalColor;
		}
	}
	
}
