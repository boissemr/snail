//Door Rotation Script
//Brian Neibecker
//Michael Sosan

using UnityEngine;
using System.Collections;

public class DoorRot : MonoBehaviour {
	public GameObject door1;
	public GameObject door2;

	//public float startTime;
	//public float journeyTime=0.25f;

	public float smooth=2.0f; // used to dalay 
	public float openAngle=95.0f; //angle rotated to
	public bool use; //runs in update, checks to see if player is 
	public bool inTrigger; //player is in the trigger cube
	public Vector3 closedRot1;
	public Vector3 openedRot1;
	public Vector3 closedRot2;
	public Vector3 openedRot2;


	void Start () {
		//startTime=Time.time;

		use=false;
		inTrigger=false;

		//initialize closed and opened door values for door 1 and 2
		closedRot1=door1.transform.eulerAngles;
		openedRot1=new Vector3(closedRot1.x, closedRot1.y+openAngle, closedRot1.z); 
		closedRot2=door2.transform.eulerAngles;
		openedRot2=new Vector3(closedRot2.x, closedRot2.y+openAngle, closedRot2.z); 
	}

	void Update () {

		if(use){
			if(inTrigger){
				//open doors
				door1.transform.eulerAngles=Vector3.Slerp(door1.transform.eulerAngles,openedRot1,Time.deltaTime*smooth);
				door2.transform.eulerAngles=Vector3.Slerp(door2.transform.eulerAngles,openedRot2,Time.deltaTime*smooth);
			}
			else{
				//print ("door update close was triggered");
				//close doors
				door1.transform.eulerAngles=Vector3.Slerp(door1.transform.eulerAngles,closedRot1,Time.deltaTime*smooth);
				door2.transform.eulerAngles=Vector3.Slerp(door2.transform.eulerAngles,closedRot2,Time.deltaTime*smooth);
			}
		}
	}

	//checks to see if the playeer is entering or exiting the door. Sets 'intrigger' to the appropriate boolean depending on this.
	void OnTriggerEnter(Collider other){
		use=true;
		inTrigger=true;
		//print ("player entered the collider");
	}
	void OnTriggerExit(Collider other){
		inTrigger=false;
		//print ("player exited the collider");
	}
}
