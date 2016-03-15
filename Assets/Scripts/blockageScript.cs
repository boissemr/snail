using UnityEngine;
using System.Collections;

public class blockageScript : MonoBehaviour {

	private bool finished, blockageDoneMoving, movingBlockage = false;

	public GameObject blockage, destination, textHelper;

	public float speed = 1.0f;
	public float rotateSpeed = 10.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (movingBlockage && transform.position != destination.transform.position) {
			blockage.transform.position = Vector3.MoveTowards(blockage.transform.position, destination.transform.position, speed * Time.deltaTime);
			blockage.transform.rotation = Quaternion.Euler (Vector3.MoveTowards (blockage.transform.rotation.eulerAngles, destination.transform.rotation.eulerAngles, rotateSpeed * Time.deltaTime));
		}
	}

	void OnTriggerStay (Collider col){
		if (col.gameObject.tag == "Player" && !finished) {
			// check for input and move blockage
			if(Input.GetButtonDown ("Fire1") || Input.GetButton ("Fire1")){
				moveBlockage();
				blockageDoneMoving = true;
			}
		}
	}


	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player" && !blockageDoneMoving) {
			// make text visible
			textHelper.SetActive (true);
		}
	}

	void OnTriggerExit(Collider col){
		if (col.gameObject.tag == "Player") {
			// make text visible
			textHelper.SetActive (false);
		}
	}

	void moveBlockage(){
		movingBlockage = true;
	}
}
