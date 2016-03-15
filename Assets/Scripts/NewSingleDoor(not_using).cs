//Michael Sosan

using UnityEngine;
using System.Collections;

public class NewSingleDoor : MonoBehaviour { //door that is openned with "E", closes automatically
	
	public GameObject GUIText;
	public GameObject door;
	public int openAngle; // angle the door opens to 
	public bool OpeningDoor; //Whteher or not door is open. Open if true, closed if false
	public int frameCounter;
	
	// Use this for initialization
	void Start () {
		GUIText.SetActive(false);
		OpeningDoor = false;
		frameCounter = 0;
		openAngle = 90;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Debug.Log("FrameCounter: " + frameCounter);
		//checks to see whether or not the door has been opened or not. If it is being opened, make sure it's frameCounter is greater than the openAngle.
		if(OpeningDoor)//if door is closed and is about to be opened
		{
			//checks if the frameCounter is less than the set openAngle.If it is, that means the door is still in the process of opening and 
			//the door is still rotating. Once the frameCounter is greater than the open angle that means it has opened completely and isDoorOpen should now be set to true
			Debug.Log("Door is about to open");
			if(frameCounter < openAngle)
			{
				door.transform.Rotate(0,3,0);
				frameCounter += 3;
				Debug.Log("Door is opening");
			}
			else{
				Debug.Log("Door is now open");
			}
		}


		else //The door is currently opened and is about to be closed.
		{
			//while the frameCounter is greater than 0, change its transform by 3 until it is 0 i.e it is closed. Decreases framecounter by 3 for each iteration
			Debug.Log("Door is about to close");
			if(frameCounter > 0)
			{
				door.transform.Rotate(0,-3,0);
				frameCounter -= 3;
				Debug.Log("Door is closing");
			}

			Debug.Log("Door is now closed");
			//OpeningDoor = false;
		}
	}

	//Checks if player is near door. If they are, activate the GUIText and tells them how to open it
	//Also opens the door for NPC that are near the door so they can get through 
	void OnTriggerEnter(Collider other){
		if(other.CompareTag("Player"))
		{
			GUIText.SetActive(true);
		}
		if(other.CompareTag("NPC"))
		{
			OpeningDoor = true;
		}
	}

	//If the player presses E, then deactivate the GUIText and open the door
	void OnTriggerStay(){
		if(Input.GetKeyUp(KeyCode.E))
		{
			GUIText.SetActive(false);
			OpeningDoor = !OpeningDoor;
		}
	}

	//
	void OnTriggerExit(Collider other){
		OpeningDoor = false;
		GUIText.SetActive(false);
	}
}


