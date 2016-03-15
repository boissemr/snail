using UnityEngine;
using System.Collections;

public class NewNewSingleDoor : MonoBehaviour {

	public GameObject GUIText; //The test that displays "Press E"
	public GameObject door; // The door object
	public int openAngle; // angle the door opens to 
	public bool openingDoor; //Whteher or not door is open. Open if true, closed if false
	public int currentAngle; // Current angle where the door is. Completly open = 90, closed = 0
	public float doorSpeed; //How fast the door opens and closes in the invoke methods


	/*
	 * CurrentAngle is currently set to zero but we might want to 
	 * change that to door.transform.rotate so we can keep track of 
	 * the door's actual rotaton position
	*/
	void Start () {
		openingDoor = false;
		currentAngle = 0; 
		//Debug.Log ("Door current angle: " + (this.transform.rotation));
		//currentAngle = this.transform.rotation;
	}

	/*
	 * method for opening door. Negativly changes its rotate value until currentangle is 90.
	 * Would have to make it negative open angle
	 * if we wanted to use door.transform.rotation insteaad of currentAngle.
	 * Cancels invoke if the current angle is bigger or equal to the openAngle
	*/
	void OpenDoor(){
		if (currentAngle < openAngle) {
			//Debug.Log ("opening");
			door.transform.Rotate (0, -2, 0);
			currentAngle += 2;
		} 
		else
			CancelInvoke ();
	}

	/*
	 *Methd for closing door. changes currentAngle back to zero. 
	 * Cancles invoke once it has reached zero.
	 */
	void CloseDoor(){
		if (currentAngle > 0) {
			//Debug.Log ("closing");
			door.transform.Rotate(0,2,0);
			currentAngle -= 2;

		}
		else
			CancelInvoke ();
	}

	/*
	 * Calls an invoke repeating method depending on whther the
	 * door is closing or not. If openingDoor is true, than its 
	 * opening the door. If false then its closing it.
	 */
	void repeat(){
		//Debug.Log ("repeat");
		if (openingDoor) {
			Debug.Log ("4");
			InvokeRepeating ("OpenDoor", 0, doorSpeed);
		} 
		else {
			Debug.Log ("5");
			InvokeRepeating ("CloseDoor", 0, doorSpeed);
		}
	}

	/*
	 * Checks if player is near door. If they are, activate the GUIText and tells them how to open it
	 * Also opens the door for NPC that are near the door so they can get through.
	 */
	void OnTriggerEnter(Collider other){
		if(other.CompareTag("Player"))
		{
			GUIText.SetActive(true);
		}
		if(other.CompareTag("NPC"))
		{
			openingDoor = true;
		}
	}
	
	/*
	 * If the player presses E, then deactivate the GUIText and open the door
	 * Also allows player to close the door depending on whether or not openingDoor
	 * is true or not. Sets openingDoor to the opposite of whta it currently is
	 * so that you can't double open/clos it.
	 */
	void OnTriggerStay(){
		if(Input.GetButtonUp("Fire1"))
		{
			//Debug.Log ("pressed E");
			GUIText.SetActive(false);
			repeat ();
			openingDoor = !openingDoor;
		}
	}
	
	//
	//void OnTriggerExit(Collider other){
	//	openingDoor = false;
	//	GUIText.SetActive(false);
	//}
}
