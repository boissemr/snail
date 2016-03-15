using UnityEngine;
using System.Collections;

public class LoadOnWake : MonoBehaviour {
	public string levelName;
	// Use this for initialization
	void Start () {

		Application.LoadLevel(levelName);
	}

}
