using UnityEngine;
using UnityEngine.VR;
using System.Collections;

public class RemoveController : MonoBehaviour {

	private GameObject controller;
	//public GameObject mainCam;
	//public GameObject orthoCam;
	//public GameObject cube;
	//public Camera main;
	//public Camera rend;

	//public Canvas canvas;
	//public string levelName;

	// Use this for initialization
	void Start () {
		controller = GameObject.Find ("First Person Controller");
		controller.SetActive(false);
		//if(VRDevice.isPresent){
		//	cube.SetActive(true);
		//	Debug.Log ("HMD DETECTED");
		//}
	}
	
	// Update is called once per frame
	void Update () {
		//if(cube.activeInHierarchy){
		//	Debug.Log ("Cube is Activate");
		//	StartCoroutine(Waiting());

		//}

	}

}
