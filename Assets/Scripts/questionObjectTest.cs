using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class questionObjectTest : MonoBehaviour {

	// Public variables are declared here for use by the "questiontest" (at time of writing)
	// code component.
	public string answerText;
	public bool correct = false;
	public bool selected = false;
	public bool selector = false;

	// Use this for initialization
	void Start () {
		// Changes the display text of this object to match the entered question text.
		this.gameObject.GetComponent<Text>().text = answerText;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}