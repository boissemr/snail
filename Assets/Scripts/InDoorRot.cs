using UnityEngine;
using System.Collections;

public class InDoorRot : MonoBehaviour {

	public GameObject door1;
	public GameObject door2;
	
	//public float startTime;
	//public float journeyTime=0.25f;
	
	public float smooth=2.0f; // sets door roatating speed
	public float openAngle=95.0f; //angle rotated to when opened out
	public float inAngle=-95.0f; //angle rotated to when opened in

	public float openedFloat1;
	public float closedFloat1;
	public float rot1;

	public bool use; //runs in update
	public bool inTrigger; //player is in the trigger cube

	// door positions
	public Vector3 closedRot1;
	public Vector3 openedRot1;
	public Vector3 closedRot2;
	public Vector3 openedRot2;



	// Use this for initialization
	void Start () {
		//startTime=Time.time;
		
		use=false;
		inTrigger=false;

		closedRot1=door1.transform.eulerAngles;
		openedRot1=new Vector3(closedRot1.x, closedRot1.y+inAngle, closedRot1.z);

		closedFloat1=door1.transform.rotation.y;
		openedFloat1=closedFloat1-openAngle;

		//print (openedRot1);
		closedRot2=door2.transform.eulerAngles;
		openedRot2=new Vector3(closedRot2.x, closedRot2.y+openAngle, closedRot2.z);
		//print (openedRot2);
	}
	
	// Update is called once per frame
	void Update () {
		if(use){
			if(inTrigger){
				//open doors
				//door1.transform.eulerAngles=Vector3.Slerp(door1.transform.eulerAngles,openedRot1,Time.deltaTime*smooth);
				//door1.transform.rotation.y = Slerp(door1.transform.eulerAngles,openedRot1,Time.deltaTime*smooth);
				//door1.transform.Rotate(0,Mathf.Lerp(door1.transform.rotation.y, openedFloat1, Time.time),0);
				rot1+=Time.deltaTime;
				rot1=Mathf.Lerp(closedFloat1,openedFloat1,rot1);

				door2.transform.eulerAngles=Vector3.Slerp(door2.transform.eulerAngles,openedRot2,Time.deltaTime*smooth);
			}
			else{
				//print ("door update close was triggered");
				//close doors
				door1.transform.eulerAngles=Vector3.Slerp(door1.transform.eulerAngles,closedRot1,Time.deltaTime*smooth);
				door2.transform.eulerAngles=Vector3.Slerp(door2.transform.eulerAngles,closedRot2,Time.deltaTime*smooth);
			}
			if(door1.transform.rotation.y==(360-openAngle)){
				use=false;
			}
		}
	}
	
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
