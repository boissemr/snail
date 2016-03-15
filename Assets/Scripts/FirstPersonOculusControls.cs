using UnityEngine;
using System.Collections;

public class FirstPersonOculusControls : MonoBehaviour {

	//variables
	public float speed;
	public float strafeSpeed;
	public float backupSpeed;
	public bool canStrafe = true;
	public Camera mainCam;
	public float desiredHeight = 1f;	// meters above the ground to keep controller
	public float dropSpeed = 1f;	// meters above the ground to keep controller
	public float heightThreshold = 0.1f;  // if we're within Xm of the ground, don't adjust
	private Vector3 moveDir = Vector3.zero;
	private Vector3 cameraDir;
	private CharacterController controller; 

	private bool hasFixedCamAngle = false;
	private RaycastHit hit;

	//public Transform startupAimPoint;

	// Use this for initialization
	void Start () {
	
		cameraDir = mainCam.transform.forward;
		controller = GetComponent<CharacterController> ();

		/*
		if (startupAimPoint != null) {
			transform.LookAt( startupAimPoint );
			transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, 0f);
		} // */
	}


	void FixOrientation() {
		//transform.eulerAngles = new Vector3(0, -mainCam.transform.eulerAngles.y, 0);
		//transform.Rotate(0, -mainCam.transform.eulerAngles.y, 0);
		Debug.Log ("Rotating FPC to " + -mainCam.transform.eulerAngles.y);
	}


	// Update is called once per frame
	void Update () {

		// simple gravity
		Vector3 down = transform.TransformDirection (-Vector3.up);
		// Bit shift the index of the layer (8) to get a bit mask
		int  layerMask = 1 << 8;
		// This would cast rays only against colliders in layer 8.
		// But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
		layerMask = ~layerMask;

		if (Physics.Raycast (transform.position, down, out hit, 10f, layerMask)) {
			//Debug.Log( "Ground distance: " + hit.distance.ToString() );
			if (Mathf.Abs(hit.distance - desiredHeight) > heightThreshold){
				if (hit.distance > desiredHeight){
					transform.Translate(0,-dropSpeed*Time.deltaTime,0) ; // move down
				}
				if (hit.distance < desiredHeight){
					transform.Translate(0,(dropSpeed*.5f) *Time.deltaTime,0) ; // move up
				}
			}
		}
	

		//Debug.Log(Input.GetAxis("Vertical"));

		if (!hasFixedCamAngle) {
			//transform.eulerAngles = new Vector3(0, -mainCam.transform.eulerAngles.y, 0);
			Invoke("FixOrientation", 0.35f);
			hasFixedCamAngle = true;
			Debug.Log ("Measuring Cam angle at " + -mainCam.transform.eulerAngles.y);
			transform.Rotate(0, -mainCam.transform.eulerAngles.y, 0);
		}

		// Check for forward / backward movment
		if(Mathf.Abs(Input.GetAxis("Vertical")) >= .2){
			if(Input.GetAxis("Vertical") >0 ){
				// positive axis value indicates forward movement
				cameraDir = mainCam.transform.forward;
				// ...so use base movement speed
				moveDir.x = cameraDir.x * speed;
				moveDir.z = cameraDir.z * speed;
			}
			else {
				// negative axis value indicates backward movement
				cameraDir = -mainCam.transform.forward;
				// ...so use backup Speed
				moveDir.x = cameraDir.x * backupSpeed;
				moveDir.z = cameraDir.z * backupSpeed;
			}

			// do movement
			controller.Move (moveDir * Time.deltaTime);
		}


		// check for strafing movement (if allowed)
		if(canStrafe && Mathf.Abs(Input.GetAxis("Horizontal")) >= .2){
			if(Input.GetAxis("Horizontal") >0 ){
				// positive axis value indicates rightward strafe
				cameraDir = mainCam.transform.right; 
			}
			else {
				// negative axis value indicates leftward strafe
				cameraDir = -mainCam.transform.right; 
			}

			//  implement either direction with same strafe speed
			moveDir.x = cameraDir.x * strafeSpeed;
			moveDir.z = cameraDir.z * strafeSpeed;

			// do movement
			controller.Move (moveDir * Time.deltaTime);
		}

		//change speed
		if(Input.GetKeyUp(KeyCode.Equals)||Input.GetKeyUp(KeyCode.KeypadPlus)){
			speed+= 0.1f;
			strafeSpeed+= 0.05f;
			backupSpeed+= 0.05f;
			Debug.Log("New Speed Setting: " + speed.ToString());
		}
		if(Input.GetKeyUp(KeyCode.KeypadMinus)||Input.GetKeyUp(KeyCode.Minus)){
			speed-= 0.1f;
			strafeSpeed-= 0.05f;
			backupSpeed-= 0.05f;
			if(speed<=.5f){
				speed=.5f;
				strafeSpeed=.25f;
				backupSpeed=.25f;
			}
			Debug.Log("New Speed Setting: " + speed.ToString());
		}
	}
}