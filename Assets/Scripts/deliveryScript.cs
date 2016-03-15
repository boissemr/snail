using UnityEngine;
using System.Collections;

public class deliveryScript : MonoBehaviour {

	private Color originalColor;
	
	// Declaration of variables used for raycasting out of the camera.
	private Camera mCamera; // mCamera is the Main Camera, thus the M.
	private Ray cameRay;
	private RaycastHit hit;

	public GameObject[] thingsToShow;   // array of helper objects to display (e.g., text / trail on the floor)
	private bool helpersShown = false;

	// provide audio feedback when the player reaches the destination
	public AudioClip feedbackAudio;
	private GameObject player;
	private AudioSource playerSource;


	// Use this for initialization
	void Start () {
		if (this.gameObject.GetComponent<Renderer> () != null) {
			this.gameObject.GetComponent<Renderer> ().enabled = false;
			originalColor = this.gameObject.GetComponent<Renderer> ().material.color;
		}
		if (this.gameObject.GetComponentsInChildren<Renderer> () != null) {
			foreach (Renderer ren in this.gameObject.GetComponentsInChildren<Renderer>()) {
				ren.enabled = false;
			}
		}

		// get player's audio source component
		player = GameObject.Find ("First Person Controller");
		playerSource = player.GetComponent<AudioSource> ();

		// Finds the main camera, which is an object tagged as "MainCamera". There should only
		// be ONE, BRIAN.
		mCamera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera>();
		
		// Creates a ray shooting straight out of the center of the viewpoint of the camera.
		cameRay = mCamera.ViewportPointToRay(new Vector3(0.5f,0.5f,0));

	}
	
	// Update is called once per frame
	void Update () {
		if (this.gameObject.GetComponent<EventManager>().current) {
			// If there are helper objects that need to be displayed, do it when this event is activated
			if (thingsToShow.Length > 0 && !helpersShown) { 
				Debug.Log( "Turning on helper objects");
				foreach (GameObject item in thingsToShow) {
					item.SetActive(true);
				}
				helpersShown = true;
			}
		}


		// This variable is used to track whether or not the raycast from the camera hit
		// anything. This information is used for 'hovering' purposes.
		bool noHit = true;
		// This draws a new raycast every frame.
		cameRay = mCamera.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0));
		// Checks if the raycast hit an answer, and only runs if the question has not
		// been completed.
		if (Physics.Raycast (cameRay, out hit) && this.gameObject.GetComponent<EventManager> ().current) {
				// If the raycast hits a possible answer, the answer is "hovered" and noHit
				// is set to false. If the Fire1 (LMB at time of writing) is pressed, the
				// answer is selected.
				if (hit.collider.gameObject == this.gameObject) {
						noHit = false;
						if (Input.GetButtonDown ("Fire1")) {
								
								Debug.Log ("I completed this");
								if (this.gameObject.GetComponent<Renderer> () != null) {
										this.gameObject.GetComponent<Renderer> ().enabled = true;
								}
								if (this.gameObject.GetComponentsInChildren<Renderer> () != null) {
										foreach (Renderer ren in this.gameObject.GetComponentsInChildren<Renderer>()) {
												ren.enabled = true;
										}
								}
								// also need to deactivate helper objects if any
								// If there are helper objects that need to be displayed, do it when this object is activated
								if (thingsToShow.Length > 0) { 
									Debug.Log("Turning off helper objects");
									foreach (GameObject item in thingsToShow) {
										item.SetActive(false);
									}
								}
								// play audio feedback
								if (feedbackAudio != null){
									//Debug.Log ("Playing feedback audio for destination");
									playerSource.clip =  feedbackAudio;
									playerSource.Play();
								}
								this.gameObject.GetComponent<EventManager> ().completed = true;
						}
				}
				// Checks if the raycast hits the gameObject attached to this code.
	
		}
		// If the raycast didn't hit anything, then all answers are "unhovered".
		if (noHit && this.gameObject.GetComponent<Renderer> () != null) {
				this.gameObject.GetComponent<Renderer> ().material.color = originalColor;
		}
	}
}