//Brian's code
//Mike Sosan
//Makes an NPC or object turn around before moving to a new destination


using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {
	//private GameObject target= GameObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate(0,1,0);
	}
}
