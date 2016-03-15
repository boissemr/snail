using UnityEngine;
using UnityEngine.VR;
using System.Collections;

public class oculusRotationHelper : MonoBehaviour {

	public Vector3 oculusRotation, thisRotation;

	// Update is called once per frame
	void FixedUpdate () {
		oculusRotation = InputTracking.GetLocalRotation(VRNode.CenterEye).eulerAngles;
		thisRotation = this.gameObject.transform.rotation.eulerAngles;

		this.gameObject.transform.localRotation = Quaternion.Euler (new Vector3 (thisRotation.x, oculusRotation.y, thisRotation.z));
	
	}
}
