using UnityEngine;
using System.Collections;

public class DoubleDoorTime : MonoBehaviour {

	public GameObject door1;
	public GameObject door2;
	
	public float door1Angle; //angle rotated to
	public float door2Angle;
	private float openedFloat1;
	private float closedFloat1;
	private float openedFloat2;
	private float closedFloat2;
	public bool unusable; //is this door usable?
	private bool inTrigger; //player is in the trigger cube
	private bool door1IsOpen=false;
	private bool door2IsOpen=false;
	private int frameCounter=0;
	private int frameCounter2=0;

	private int numInCol; //number of objects in the collider

	//public GameObject blockingCol;
	
	// Use this for initialization
	void Start () {

		inTrigger=false;
		closedFloat1=door1.transform.rotation.y;
		openedFloat1=closedFloat1+door1Angle;
		//print(closedFloat1+" / "+openedFloat1);
		closedFloat2=door2.transform.rotation.y;
		openedFloat2=closedFloat2+door2Angle;
		//print (closedFloat2+" / "+openedFloat2);
		/*
		if(unusable && blockingCol != null){
			blockingCol.SetActive(true);
		}
		else{
			blockingCol.SetActive(false);
		} // */

		numInCol = 0;
	}
	
	// Update is called once per frame
	void Update () {

	}
	void FixedUpdate(){
		if(!unusable){
			if(door1Angle>0){//door1 opens in a positive direction
				if(inTrigger){
					//open door1
					if(frameCounter<(int)(door1Angle)){
						door1.transform.Rotate(0,3,0);
						frameCounter+=3;
						door1IsOpen=true;
					}
				}
				else if(door1IsOpen){
					//close door1
					if(frameCounter>0){
						door1.transform.Rotate(0,-3,0);
						frameCounter-=3;
					}
					else{
						door1IsOpen=false;
					}
				}
			}
			if(door2Angle>0){//door2 opens in a positive direction
				if(inTrigger){
					//open door2
					if(frameCounter2<(int)(door2Angle)){
						door2.transform.Rotate(0,3,0);
						frameCounter2+=3;
						door2IsOpen=true;
					}
				}
				else if(door2IsOpen){
					//close door2
					if(frameCounter>0){
						door2.transform.Rotate(0,-3,0);
						frameCounter2-=3;
					}
					else{
						door2IsOpen=false;
					}
				}
			}
			if(door1Angle<0){//door1 opens in a negative direction
				if(inTrigger){
					//open door1
					if(frameCounter<-(int)(door1Angle)){
						door1.transform.Rotate(0,-3,0);
						frameCounter+=3;
						door1IsOpen=true;
					}
				}
				else if(door1IsOpen){
					//close door1
					if(frameCounter>0){
						door1.transform.Rotate(0,3,0);
						frameCounter-=3;
					}
					else{
						door1IsOpen=false;
					}
				}
			}
			if(door2Angle<0){//door2 opens in a negative direction
				if(inTrigger){
					//open door2
					if(frameCounter2<-(int)(door2Angle)){
						door2.transform.Rotate(0,-3,0);
						frameCounter2+=3;
						door2IsOpen=true;
					}
				}
				else if(door2IsOpen){
					//close door2
					if(frameCounter>0){
						door2.transform.Rotate(0,3,0);
						frameCounter2-=3;
					}
					else{
						door2IsOpen=false;
					}
				}
			}
		}

	}

	//trigger handling
	void OnTriggerEnter(Collider other){
		if(other.tag == "Player" || other.tag == "NPC"){
			numInCol++;
			inTrigger=true;
			//Debug.Log (gameObject.name + " was activated by " + other.name);
		}
	}

	//void OnTriggerStay(Collider other){

	//}

	void OnTriggerExit(Collider other){
		if(other.tag == "Player" || other.tag == "NPC"){
			numInCol--;
			if(numInCol == 0){
				inTrigger=false;
			}
		}
	}
}
