using UnityEngine;
using System.Collections;

public class Toggle_Oculus : MonoBehaviour {

	private GameObject myFPC;
	private GameObject myCam;
	public GameObject[] manualObjects;
	
	// at start, check pitch/roll of neck joint for X seconds
	//   ...if oculus is connected, these values will be non-zero
	public float autoDetectForSec = 1.0f;
	private float timeSoFar = 0.0f;
	private bool autoDetectFinished = false;
	public float nonZeroThreshold = 0.001f;  // how many degrees is non-zero?

	// field of view settings
	public float keyboardFOV = 60f;
	public float oculusFOV = 104.5737f;

	// mouselook sensitivity settings
	public float mouseSensitivity = 6f;
	public float joystickSensitivity = 0.95f;


	// Use this for initialization
	void Start () {
		myFPC = GameObject.Find("First Person Controller/Neck");
		myCam = GameObject.Find("First Person Controller/Neck/Main Camera");
	}


	void GoToKBMouseControl () {
		Debug.Log("------ Switching to Keyboard and Mouse Controls ------");
		// K for Keyboard
		// grab mouselook script from Character controller
		// change control axes to use the mouse x & y
		myFPC.GetComponent<MouseLook>().axes = MouseLook.RotationAxes.MouseXAndY;
		// change sensitivity of X and Y to ~8
		myFPC.GetComponent<MouseLook>().sensitivityX = mouseSensitivity;  	
		myFPC.GetComponent<MouseLook>().sensitivityY = mouseSensitivity; 
		
		// change camera field of view to 60 - 75
		GameObject.Find("Main Camera").GetComponent<Camera>().fieldOfView = keyboardFOV;

		// enable strafing
		myFPC.transform.parent.gameObject.GetComponent<FirstPersonOculusControls>().canStrafe = true;
		
		// find KB helper objects and enable them
		foreach (GameObject i in GameObject.FindGameObjectsWithTag("KeyboardMouse")) {
			i.GetComponent<MeshRenderer>().enabled = true;
			//Debug.Log("Turning on " + i.name.ToString() );
		}
		foreach (GameObject ii in manualObjects) {  // some objects are inactive, and thus won't toggle correctly
			if (ii.tag == "KeyboardMouse"){
				ii.GetComponent<MeshRenderer>().enabled = true;
				//Debug.Log("Turning on " + ii.name.ToString() );
			}
		}
		
		
		// find Oculus helper objects and disable them
		foreach (GameObject j in GameObject.FindGameObjectsWithTag("Oculus")){
			j.GetComponent<MeshRenderer>().enabled = false;
		}
		foreach (GameObject jj in manualObjects) {  // some objects are inactive, and thus won't toggle correctly
			if (jj.tag == "Oculus"){
				jj.GetComponent<MeshRenderer>().enabled = false;
			}
		}
	}

	void GoToOculusMode (){
		Debug.Log("------ Switching to Oculus Controls ------");
		// O for Oculus
		// grab mouselook script from Character controller
		// change axes to 1 (Joystick X)
		myFPC.GetComponent<MouseLook>().axes = MouseLook.RotationAxes.JoystickX;		// <--- this crashes in js.  Do in C#
		// change sensitivity of X and Y to 0.75
		myFPC.GetComponent<MouseLook>().sensitivityX = joystickSensitivity;  	
		myFPC.GetComponent<MouseLook>().sensitivityY = joystickSensitivity;
		
		// change camera field of view to 104.5737
		GameObject.Find("Main Camera").GetComponent<Camera>().fieldOfView = oculusFOV;

		// disable strafing
		//myFPC.transform.parent.gameObject.GetComponent<FirstPersonOculusControls>().canStrafe = false;
		
		// Reset FPC orientation to zero
		myFPC.transform.rotation = Quaternion.identity;
		
		// find Oculus helper objects and enable them
		foreach (GameObject k in GameObject.FindGameObjectsWithTag("Oculus")){
			k.GetComponent<MeshRenderer>().enabled = true;
			//Debug.Log("Turning on " + k.name.ToString() );
		}
		foreach (GameObject kk in manualObjects) {  // some objects are inactive, and thus won't toggle correctly
			if (kk.tag == "Oculus"){
				kk.GetComponent<MeshRenderer>().enabled = true;
				//Debug.Log("Turning on " + kk.name.ToString() );
			}
		}
		
		// find Kb helper objects and disable them
		foreach (GameObject m in GameObject.FindGameObjectsWithTag("KeyboardMouse")){
			m.GetComponent<MeshRenderer>().enabled = false;
		}
		foreach (GameObject mm in manualObjects) {  // some objects are inactive, and thus won't toggle correctly
			if (mm.tag == "KeyboardMouse"){
				mm.GetComponent<MeshRenderer>().enabled = false;
			}
		}

	}

	// Update is called once per frame
	void Update () {
		// PROBLEM - when next level loads, the old helper objects are destroyed and the new ones won't be added here.
		//  further compounding the problem is that they are deactivated and can't be searched.  Oops.
		//  Trying to solve by keeping First Person Controller intact from one level to the next rather than create new.
		if (!autoDetectFinished){
			timeSoFar += Time.deltaTime;
			if (timeSoFar <= autoDetectForSec){
				//  check neck for non-zero pitch or roll
				if (Mathf.Abs(myCam.transform.eulerAngles.x) >= nonZeroThreshold || 
				    Mathf.Abs(myCam.transform.eulerAngles.z) >= nonZeroThreshold){
					//  If we're in here, there seems to be sensor data streaming
					//	since HMD mode is the default, just leave it, and stop autodetecting
					autoDetectFinished = true;
					Debug.Log ("----Oculus Detected; Keeping HMD controls----");
				}
			}
			else {
				// time's up, and no non-zero sensor data was detected
				//  need to stop autodetecting
				autoDetectFinished = true;
				//  ...and switcht to keyboard mode
				Debug.Log ("----No Oculus Detected; Requesting KB Mouse Controls----");
				GoToKBMouseControl();
			}
		}


		if(Input.GetKeyDown (KeyCode.K)){
			GoToKBMouseControl();
		}
		
		if(Input.GetKeyDown (KeyCode.O)){
			GoToOculusMode();

		}
	}
}
