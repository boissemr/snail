using UnityEngine;
using System.Collections;

public class TestForTutorialCompleted : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (!GameObject.Find("First Person Controller")){
		    Application.LoadLevel(0);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
