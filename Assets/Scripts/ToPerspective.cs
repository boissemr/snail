using UnityEngine;
using UnityEngine.VR;
using System.Collections;

public class ToPerspective : MonoBehaviour {

	public GameObject dButton,iButton,detail,initial;

	// Use this for initialization
	void Start () {
		if(VRDevice.isPresent){
			Debug.Log ("HMD DETECTED...");

			GameObject.Find("Main Camera").GetComponent<Camera>().orthographic = false;
			Debug.Log ("CAMERA SET TO PERSPECTIVE...");

			detail.transform.SetParent(iButton.transform);
			initial.transform.SetParent(dButton.transform);
			Debug.Log ("READOUTS REPARENTED...");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
