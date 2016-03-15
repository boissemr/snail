using UnityEngine;
using System.Collections;

public class TeleportController : MonoBehaviour {

	public GameObject character; //Character to be moved
	public Camera playerCam;  //Camera we raycast from
	public GameObject castOBJ; //GameObject spawned on collision with raycast, shows where the user will move to 
	public GameObject fadeSphere; //faded in and out to block players view during movement 

	public bool inTP; //is the player aiming
	public bool validLocation; //is this a valid location to TP to, get from castOBJ

	private Vector3 tempPos; //used to store the value of the raycast hit

	// Use this for initialization
	void Start () {
		inTP = false;

		//DO NOT INCLUDE IN FINAL DRIVE VALIDLOCATION FROM CASTOBJ
		validLocation = true; 
		//DO NOT INCLUDE IN FINAL DRIVE VALIDLOCATION FROM CASTOBJ

		castOBJ.SetActive(false);

		fadeSphere.GetComponent<FadeObjectInOut>().FadeOut(); //fade sphere out on start

		tempPos= new Vector3(0,0,0);
	}
	
	// Update is called once per frame
	void Update () {
		//Check if player is aiming
		//Debug.Log("Waiting for trigger");
		if(Input.GetAxis("LeftTrigger")!=0||Input.GetKey(KeyCode.Q)){
			//Debug.Log("Left trigger on");
			inTP=true;
		} else{
			inTP=false;
		}
		//End check if player is aiming

		//Teleport Handling
		if(inTP){
			//Show castOBJ
			if(!castOBJ.activeInHierarchy){
				castOBJ.SetActive(true);
			}
			//End Show castOBJ

			//RayCast
			RaycastHit hit;
			Ray ray = new Ray(playerCam.transform.position, playerCam.transform.forward);
			if(Physics.Raycast(ray, out hit, Mathf.Infinity)) {
				Debug.DrawRay(playerCam.transform.position, playerCam.transform.forward, Color.green);
				//Debug.Log ("Looking at: "+hit.transform.name);
				//move castOBJ to hit location
				if(hit.transform.tag=="Floor"){ //check if they are looking at the floor
					castOBJ.transform.position =new Vector3(hit.point.x,hit.point.y,hit.point.z); //move cast preview to hit point
					tempPos =new Vector3(hit.point.x,hit.point.y,hit.point.z); //store the hit position
				}
				//End move castOBJ
			}
			//End RayCast

			//Move controller
			if(Input.GetKeyUp(KeyCode.E)){
				Debug.Log ("Player tried to move");
				if(validLocation){
					Debug.Log("Location is valid... moving...");
					StartCoroutine("MoveCharacter",tempPos); 
				}
			}
			//End Move Controller

		}
		//End Teleport Handling
		else{
			if(castOBJ.activeInHierarchy){
				castOBJ.SetActive(false);
			}
		}
	}


	//used to move character and block vision, requires a Vector3 location to move to
	public IEnumerator MoveCharacter(Vector3 tempPos){
		fadeSphere.GetComponent<FadeObjectInOut>().FadeIn(); //start fade
		yield return new WaitForSeconds(0.55f); //wait for fade
		character.transform.position = tempPos; //move
		fadeSphere.GetComponent<FadeObjectInOut>().FadeOut(); //clear vision
	}
}
