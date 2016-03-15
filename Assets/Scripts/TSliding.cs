using UnityEngine;
using System.Collections;

public class TSliding : MonoBehaviour { //Togglable sliding door using "E", works with one door

	public GameObject Door1; //door to be moved
	public GameObject text; //"Press "E" to use"
	private bool move=false; //change state
	private bool open=false; //open or closed
	//public bool openNeg; //door slides in the negative direction
	private bool inCol=false; //is the player in the collider

	public GameObject targetLoc; //where the door opens to
	public GameObject closedTarget; //where the door closes to
	private Transform openPos;
	private Transform closedPos;
	public float tolerance = 0.1f;
	public float smooth=2.0f;

	// Use this for initialization
	void Start () {
		text.SetActive(false);
		openPos=targetLoc.transform;
		closedPos=closedTarget.transform; 
	}
	void Update(){
		if(move){
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
				//print ("door is openning");
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
			inCol=true;
		}
		if(other.CompareTag("NPC")){
			print ("NPC exiting sliding door col");
			move=true;
		}
	}
	void OnTriggerExit(Collider other){
		//print ("Exited sliding door col");
		if(other.CompareTag("Player"))
		{
			text.SetActive(false);
			inCol=false;
		}
		if(other.CompareTag("NPC")){
			print ("NPC in sliding door col");
			move=true;
		}
	}
	void OnTriggerStay(Collider other){
		if(Input.GetKeyUp(KeyCode.E)){
			move=true;
			//print ("interacted with door");
		}
	}
}
