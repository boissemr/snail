using UnityEngine;
using System.Collections;

public class TestIfOriented : MonoBehaviour {
	
	void Start () {

		/*
			If there is no character select manager in this scene,
			the player has not gone through orientation. So, we
			send him back to pick a job.
		*/
		if(GameObject.Find("Character Select Manager") == null) {
			Debug.Log(Application.loadedLevelName + " loaded, but player has not been orientated.\nPlayer sent back to orientation.");
			Application.LoadLevel("SplashScreen_2");
		}
	}
}
