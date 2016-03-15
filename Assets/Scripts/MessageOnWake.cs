using UnityEngine;
using System.Collections;

public class MessageOnWake : MonoBehaviour {

	public GameObject target;
	public string message;

	// Use this for initialization
	void Start () {
		target.SendMessage(message);
	}

}
