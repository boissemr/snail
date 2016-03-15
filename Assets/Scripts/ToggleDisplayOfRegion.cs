using UnityEngine;
using System.Collections;

public class ToggleDisplayOfRegion : MonoBehaviour {

	public GameObject[] showOnEnter;
	public GameObject[] hideOnExit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other) {
		if(other.tag == "Player"){
			foreach (GameObject i in showOnEnter) {
				i.SetActive(true);
			}
		}
	}

	void OnTriggerExit (Collider other) {
		if(other.tag == "Player"){
			foreach (GameObject i in hideOnExit) {
				i.SetActive(false);
			}
		}
	}
}
