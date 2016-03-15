using UnityEngine;
using System.Collections;

public class RemoveOnTrigger : MonoBehaviour {
	public GameObject toRemove;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider Other){
		toRemove.SetActive(false);
	}
}
