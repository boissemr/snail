using UnityEngine;
using System.Collections;

public class CompletionTimer : MonoBehaviour {

	public float timeSoFar = 0;
	public bool timerOn = false;


	
	// Update is called once per frame
	void Update () {
		if (timerOn){
			timeSoFar += Time.deltaTime;
		}
	}

	public void StartTimer() {
		timerOn = true;
	}

	public void StopTimer(){
		timerOn = false;
		gameObject.GetComponent<DataStorage>().timeToCompletion = timeSoFar;
	}
}
