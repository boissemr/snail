using UnityEngine;
using UnityEngine.VR;
using System.Collections;

public class OculusEndScreen : MonoBehaviour {

	public GameObject HMD,nonHMD;

	// Use this for initialization
	void Start () {
		if(VRDevice.isPresent){
			nonHMD.SetActive(false);
			HMD.SetActive(true);
		}
		else{
			nonHMD.SetActive(true);
			HMD.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
