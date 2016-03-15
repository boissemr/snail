using UnityEngine;
using System.Collections;

public class GrabCrib : MonoBehaviour {

	public GameObject worldCrib;
	public GameObject PlayerCrib;
	public GameObject Prompt;
	public GameObject nextText;
	public GameObject thisObj;
	//public bool inCol;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(){
		if(Input.GetKey(KeyCode.E))
		{
			worldCrib.SetActive(false);
			PlayerCrib.SetActive(true);
			nextText.SetActive(true);
			thisObj.SetActive(false);
		}
	}
}
