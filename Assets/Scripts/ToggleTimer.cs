using UnityEngine;
using System.Collections;

public class ToggleTimer : MonoBehaviour {

	public GameObject timerObject;
	public enum StartStop {Start, Stop};
	public StartStop timerAction;

	// Use this for initialization
	void Awake () {
		// find timer
		timerObject = GameObject.Find("Utility_Helper");

		/*
		// start or stop as necessary
		if (timerAction == StartStop.Start){
			timerObject.GetComponent<CompletionTimer>().StartTimer();
		}
		if (timerAction == StartStop.Stop){
			timerObject.GetComponent<CompletionTimer>().StopTimer();
		}
		// */
	}

	void Update(){
		// start or stop as necessary
		//    if we should start, and it's off, make it go
		if (timerAction == StartStop.Start  && !timerObject.GetComponent<CompletionTimer>().timerOn){
			timerObject.GetComponent<CompletionTimer>().StartTimer();
		}
		//    if we should stop, and it's on, make it end
		if (timerAction == StartStop.Stop  && timerObject.GetComponent<CompletionTimer>().timerOn ){
			timerObject.GetComponent<CompletionTimer>().StopTimer();
		}
	}
	

}
