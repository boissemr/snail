using UnityEngine;
using System.Collections;

public class FadeScreenIn : MonoBehaviour {

	private bool hasStarted = false;


	
	// Update is called once per frame
	void Update () {
		if (!hasStarted) {
			hasStarted = true;
			GameObject.Find("FadeToBlack").SendMessage("StartScene");
			GameObject.Destroy(this.gameObject, 1);		//once the fade in starts, we can kill this object
		}
	}
}
