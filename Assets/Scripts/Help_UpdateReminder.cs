using UnityEngine;
using System.Collections;

public class Help_UpdateReminder : MonoBehaviour {

	public TextMesh reminderObject;
	public string textToDisplay = "";
	private bool hasBeenShown = false;

	// Use this for initialization
	void Start () {
		if (reminderObject == null){ 
			reminderObject = GameObject.Find("Instruction_Text").GetComponent<TextMesh>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.GetComponent<EventManager>().current && !hasBeenShown){
			reminderObject.text = textToDisplay;
		}
	}
}
