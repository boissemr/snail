using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FindCompletionCode : MonoBehaviour {
	public string outText = "Your completion code:";

	// Use this for initialization
	void Start () {
		outText = outText +" "+ GameObject.Find("Utility_Helper").GetComponent<DataStorage>().completionCode;
		gameObject.GetComponent<Text>().text = outText;
		Debug.Log ("------ Attempting to change timer text to: " + outText + " -------");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
