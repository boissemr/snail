using UnityEngine;
using System.Collections;

public class MarkerRotate : MonoBehaviour {

	private int speed;

	// Use this for initialization
	void Start () {
		speed = 1;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0,speed,0);
	}
}
