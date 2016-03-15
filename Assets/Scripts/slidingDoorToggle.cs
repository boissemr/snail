using UnityEngine;
using System.Collections;

public class slidingDoorToggle : MonoBehaviour { //Togglable sliding door using "E", works with one door

	public GameObject Door1; //door to be moved
	public GameObject text; //"Press "E" to use"
	private bool move=false; //change state
	public bool open=false; //open or closed

	public GameObject targetLoc; //where the door opens to
	public GameObject closedTarget; //where the door closes to
	private Transform openPos;
	private Transform closedPos;
	private float tolerance = 0.1f;
	private float smooth=2.0f;

	// Use this for initialization
	void Start () {
		text.SetActive(false);
		openPos=targetLoc.transform;
		closedPos=closedTarget.transform; 
		this.gameObject.GetComponent<EventManager> ().setupDone = true;
	}
	void Update(){
		if(move){

			// Requires an AudioSource component to be attached to the gameObject this comopnent belongs to.
			// If the audio source isn't already playing, then the audiosource plays the clip assigned to it.
			if(!this.gameObject.GetComponent<AudioSource>().isPlaying){
				this.gameObject.GetComponent<AudioSource>().Play ();
			}
			if(open){ //closing the door
				Door1.transform.position=Vector3.Lerp(Door1.transform.position,closedPos.position,smooth*Time.deltaTime);
				//print("door is closing");
				//print (Vector3.Distance(closedPos.position,Door1.transform.position));
				if( Vector3.Distance(closedPos.position,Door1.transform.position) <= tolerance ){
					//print ("door is closed");
					move=false;
					open=false;
				}
			}
			else{ //opening the door

				Door1.transform.position=Vector3.Lerp(Door1.transform.position,openPos.position,smooth*Time.deltaTime);  
				//print ("door is opening");
				if(Vector3.Distance(Door1.transform.position,openPos.position) <= tolerance){
					//print("door is open");
					move=false;
					open=true;
				}
			}
		}


	}

	void OnTriggerEnter(Collider other){
		//print ("enter sliding door col");
		if(other.CompareTag("Player"))
		{
			text.SetActive(true);
		}
		if(other.CompareTag("NPC")){
			move=true;
		}
	}
	void OnTriggerExit(Collider other){
		//print ("Exited sliding door col");
		if(other.CompareTag("Player"))
		{
			text.SetActive(false);
		}
		if(other.CompareTag("NPC")){
			print ("NPC in sliding door col");
			move=true;
		}
	}
	void OnTriggerStay(Collider other){
		if(Input.GetButtonUp("Fire1") || Input.GetButton("Fire1")){
			move=true;

			//print ("interacted with door");
		}
	}
}
