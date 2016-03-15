using UnityEngine;
using System.Collections;

public class cribScript : MonoBehaviour {

	public GameObject crib;

	// Use this for initialization
	void Start () {
		if (crib == null) {
			crib = GameObject.Find("CribPivot").transform.GetChild(0).gameObject;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
