using UnityEngine;
using System.Collections;

public class TextLookAtPlayer : MonoBehaviour {

	public GameObject target; //object to Behaviour looked at
	private Transform targetTrans;

	// Use this for initialization
	void Start () {
		// The target will always be the main camera. 
		target = GameObject.Find ("Main Camera");
		targetTrans = target.transform;
	}
	
	// Update is called once per frame
	void Update () {

		// The target should be the main camera, and the position is updated every frame to be the same height
		// as the main camera so that there is no weird tilting. Additionally the text twists to look at the
		// player every frame.
		if(target != null)
		{
			//this.transform.position = new Vector3(this.transform.position.x, targetTrans.position.y, this.transform.position.z);
			transform.LookAt(targetTrans);
		}
	}
}
