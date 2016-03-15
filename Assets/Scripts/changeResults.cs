using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class changeResults : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.GetComponent<Button> ().onClick.AddListener (GameObject.Find ("EndCard").GetComponent<endCardScript> ().Toggle);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
