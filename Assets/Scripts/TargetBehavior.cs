//controls the MoveToTarget object, when the player steps in the target 
//	it sends a message to the WoldRunner to trigger the next events
//Brian Neibecker
//Mike Sosan


using UnityEngine;
using System.Collections;

public class TargetBehavior : MonoBehaviour {
	public GameObject worldRunner;
	public GameObject nextTarget;
	public string playerAtLoc;

	void OnTriggerEnter(Collider other){
		if(other.tag=="Player"){
			print ("PlayerAtStart sent to WorldRunner");
			worldRunner.SendMessage(playerAtLoc);
			//nextTarget.SetActive(true);
			this.gameObject.SetActive(false);
		}
	}
}
