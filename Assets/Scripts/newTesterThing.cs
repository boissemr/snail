using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class newTesterThing : MonoBehaviour {

	// Use this for initialization
	void Start () {
	//	this.GetComponent<Text> ().text = "Start";
	}

	void Awake(){
		this.gameObject.SendMessage("OnLevelWasLoaded",Application.loadedLevel);
	//	this.GetComponent<Text> ().text = "Awake";
	}

	void OnLevelWasLoaded (){
		
		this.GetComponent<Text> ().text = "OnLevelWasLoaded";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
