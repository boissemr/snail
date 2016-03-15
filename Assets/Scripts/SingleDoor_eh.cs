using UnityEngine;
using System.Collections;

public class SingleDoor_eh : MonoBehaviour {

	public Vector3 closeAngle = new Vector3(0f, 0f, 0f);
	public Vector3 openAngle = new Vector3(0f, 90f, 0f);
	private bool isClosed = true;
	private Vector3 targetDir;
	public float speed = 1.0f;
	public float finishThreshold = 0.1f;
	public bool isOpening = false;
	public bool isClosing = false;
	public bool requireClick = false;
	public Transform rotationObj;

	// Use this for initialization
	void Start () {
		if (rotationObj == null){
			rotationObj = transform.GetChild(0);  //  Doorframe should have a single child, DoorPivot_x xx
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (isOpening) {   // if we're opening, set that as rotation target
			isClosed = false;
			targetDir = openAngle;
			//Vector3 targetDir = target.position - rotationObj.position;
			float step = speed * Time.deltaTime;
			Vector3 newDir = Vector3.RotateTowards(rotationObj.forward, targetDir, step, 0.0F);
			Debug.DrawRay(rotationObj.position, newDir, Color.red);
			rotationObj.rotation = Quaternion.LookRotation(newDir);
			
			// need to check and see if the rotation is finished
			
			if (Mathf.Abs(rotationObj.eulerAngles.y - openAngle.y) < finishThreshold){
				// open finished
				isOpening = false;
			}
		}
		else if (isClosing) {  // if we're closing, set that as target
			targetDir = closeAngle;
			//Vector3 targetDir = target.position - rotationObj.position;
			float step = speed * Time.deltaTime;
			Vector3 newDir = Vector3.RotateTowards(rotationObj.forward, targetDir, step, 0.0F);
			Debug.DrawRay(rotationObj.position, newDir, Color.red);
			rotationObj.rotation = Quaternion.LookRotation(newDir);
			
			// need to check and see if the rotation is finished
			
			if (Mathf.Abs(rotationObj.eulerAngles.y - closeAngle.y) < finishThreshold){
				// open finished
				isClosing = false;
				isClosed = true;
			}
		}


	}

	void OnTriggerStay () {
		// need to act differently if click is required
		//   - clicks can manually trigger open / close states
		//   - no-click required should open on trigger entry, close on trigger exit (not in this function)
		//
		// check for click if required
		if (requireClick && Input.GetButton("Fire1") ){
			// okay to trigger motion now, but are we opening or closing?
			if (isClosed || isClosing){
				// was closed, so open now
				isOpening = true;
				isClosing = false;
			}
			else if (isOpening){
				// was open or opening, so close it now
				isClosing = true;
				isOpening = false;
			}
		}



	}

	void OnTriggerEnter () {
		// only react to trigger entry/exit if no click is required
		if (!requireClick){
			// open on entry
			isOpening = true;
			isClosing = false;
		}
	}


	void OnTriggerExit () {
		// only react to trigger entry/exit if no click is required
		if (!requireClick){
			// close on exit
			isClosing = true;
			isOpening = false;
		}
	}



}
