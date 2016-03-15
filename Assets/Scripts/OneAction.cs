using UnityEngine;
using System.Collections;

public class OneAction : MonoBehaviour {

	public GameObject thisObject;
	public GameObject nextObject;
	public GameObject text;
	public GameObject pickedUp;
	public bool triggered;

	// Use this for initialization
	void Start () {
		triggered=false;
	}
	
	// Update is called once per frame
	void Update () {
		if(triggered==true)
		{
			pickedUp.SetActive(false);
			nextObject.SetActive(true);
			thisObject.SetActive(false);
		}
	}

	void OnTriggerStay(){
		text.SetActive(true);
		if(Input.GetKey(KeyCode.E))
		{
			triggered=true;
		}
	}
	void OnTriggerExit(){
		text.SetActive(false);
	}
}
