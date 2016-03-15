using UnityEngine;
using UnityEngine.VR;
using System.Collections;

public class OculusStart : MonoBehaviour {

	//public GameObject cam;
	public bool oculus;
	public GameObject CursorControl;
	public GameObject keyStart, oculusStart;

	// Use this for initialization
	void Start () {
		//Debug.Log ("------------ Checking for Oculus ----------------");
		oculus = false;
		if (CursorControl == null){
			GameObject.Find("Utility_Helper");
		}
		//cam = GameObject.Find ("Main Camera");
		if(VRDevice.isPresent)
		{
			Debug.Log ("HMD Detected...");
			oculus = true;
		}

		if(oculus){
			//Debug.Log ("HMD Start Loaded...");
			keyStart.SetActive(false);
			oculusStart.SetActive(true);
			CursorControl.GetComponent<HideCursor>().Hide();
		}
	}
	
	// Update is called once per frame
	void Update () {
	


	}
}
