using UnityEngine;
using System.Collections;

//this is used to activate an object and deactivate another when the A button is pressed on a controller

public class PressAActivateOBJ : MonoBehaviour {

	public GameObject deactivate;
	public GameObject activate;

	// Use this for initialization
	void Start () {
		Debug.Log(gameObject.name + " was activated and is waiting for the A button");
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(gameObject.name + " is still waiting");
		if(Input.GetButtonDown("A_Button")){
			Debug.Log("A button pressed");
			activate.SetActive(true);
			deactivate.SetActive(false);
		}
	}
}
