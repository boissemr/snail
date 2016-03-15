using UnityEngine;
using System.Collections;

public class DeveloperSkipScene : MonoBehaviour {

	public string sceneToLoad;

	void Update() {

		// crtl + alt + shift to skip
		if(Input.GetButton("Fire1") && Input.GetButton("Fire2") && Input.GetButton("Fire3")) {
			Application.LoadLevel(sceneToLoad);
		}
	}
}
