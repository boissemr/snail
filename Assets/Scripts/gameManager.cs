using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (Application.loadedLevelName != "End Scene") {
			Cursor.visible = false;
		} else {
			Cursor.visible = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
