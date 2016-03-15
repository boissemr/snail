using UnityEngine;
using System.Collections;

public class changeNPCDestination : MonoBehaviour {

	public string NPCName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player") {
			GameObject.Find(NPCName).GetComponent<NPCMoveTo>().nextPosition();
		}
	}
}
