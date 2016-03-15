using UnityEngine;
using System.Collections;

public class rotationFreeze : MonoBehaviour {
	
	// Update is called once per frame
	void FixedUpdate () {
		this.transform.localRotation = Quaternion.Euler (new Vector3 (this.transform.localRotation.x, 0, this.transform.localRotation.z));
	}
}
