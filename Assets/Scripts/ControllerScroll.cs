using UnityEngine;
using System.Collections;

public class ControllerScroll : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("RightScroll")!=0){
			Vector3 inputDirection = Vector3.zero;
			inputDirection.y = Input.GetAxis("RightScroll");
			transform.position = transform.position + inputDirection;
		}
	}
}
