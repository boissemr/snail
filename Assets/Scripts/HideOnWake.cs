using UnityEngine;
using System.Collections;

public class HideOnWake : MonoBehaviour {

	public GameObject show;
	
	// Use this for initialization
	void Start () {
		show.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
