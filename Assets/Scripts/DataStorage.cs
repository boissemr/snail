using UnityEngine;
using System.Collections;

public class DataStorage : MonoBehaviour {

	// put info here that should persist throught the simulation (e.g., from intro scene to final scene)
	public string completionCode = "unasigned";		// Pseudo-random alpha-numeric code for proof of completion
	public float timeToCompletion = 0;				// How long did they take to evacuate

	private string oldCompletionCode = "unasigned";

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(gameObject);	// make this object persistant across level loads
	}
	
	void Update(){
		if (oldCompletionCode != completionCode){
			//Debug.Log("Completion Code updated to " + completionCode);
			oldCompletionCode = completionCode;
		}

	}
}
