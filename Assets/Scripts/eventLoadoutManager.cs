
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class eventLoadoutManager : MonoBehaviour {
	
	public Hashtable eventList = new Hashtable();
	public bool job1, job2, job3;
	
	private EventManager currentEvent;
	private characterSelectManager charSelect;
	
	void Awake(){
		DontDestroyOnLoad (this.gameObject);
		DontDestroyOnLoad (GameObject.Find ("First Person Controller"));	// also leave the FPC intact
		//this.gameObject.SendMessage("OnLevelWasLoaded",Application.loadedLevel);
	}
	
	// Use this for initialization
	IEnumerator OnLevelWasLoaded () {
		
		eventList.Clear ();
		
		Debug.Log ("------------ Level Loaded ------------");
		
		charSelect = GameObject.Find ("Character Select Manager").GetComponent<characterSelectManager> ();
		
		job1 = charSelect.job1;
		job2 = charSelect.job2;
		job3 = charSelect.job3;

		//NOTE: while editing, the game crashes if you skip the intro tutorial, because no job has been picked.
		//  This code block checks for a "no selection" condition and assigns Job1 by default
		//  ...also note that this code block doesn't seem to have any effect in preventing the bug.  Oops.
		if (!job1 && !job2 && !job3) {
			job3 = true;
		}
		
		// Finding and adding relevant events (tagged as "Event") to a hashtable.
		
		foreach (GameObject gobj in GameObject.FindGameObjectsWithTag ("Event")) {
			EventManager gobjE = gobj.GetComponent<EventManager> ();
			Debug.Log("Adding event: " + gobjE.order.ToString() + " -- " + gobj.gameObject.name.ToString() );
			//Debug.Log (gobjE.order);
			if (job1 && gobjE.job1) {
				gobjE.relevant = true;
			} else if (job2 && gobjE.job2) {
				gobjE.relevant = true;
			} else if (job3 && gobjE.job3) {
				gobjE.relevant = true;
			}
			if (gobjE.relevant) {
				eventList.Add (gobjE.order.ToString(), gobjE);
				//Debug.Log ("Event List Order: " + eventList[gobjE.order.ToString()].ToString());
			}
			// Questions, deliveries, and destinations are turned off entirely. All other events remain with their
			// gameObjects turned on.
			if(gobjE.question || gobjE.delivery || gobjE.destination || gobjE.text){
				gobjE.gameObject.SetActive(false);
			}else{
				gobjE.enabled = false;
			}
		}
		// Activating the smallest hashtable key's object, breaking if the lowest is key is higher than 10000.
		// If the lowest key is over 10000, what are you doing?
		for (int i = 0; i > -1; i++) {
			if(eventList.ContainsKey(i.ToString())){
				Debug.Log ("Activating Event " + eventList[i.ToString()].ToString() );
				((EventManager)eventList[i.ToString()]).current = true;
				currentEvent = (EventManager)eventList[i.ToString ()];
				currentEvent.gameObject.SetActive(true);
				currentEvent.enabled = true;
				if(currentEvent.text){
					//Debug.Log ("Activating delayText event " + currentEvent.gameObject.name );
					return currentEvent.GetComponent<TimedText>().delayText();
				}
				break;
			}
			if(i > 1000){
				break;
			}
		}
		return null;
	}
	
	// Update is called once per frame
	void Update () {
		// If there is a current event, and it's completed, then the program moves forward.
		if (currentEvent != null) {
			if (currentEvent.completed == true) {
				StartCoroutine("step"); 
			}
		}
	}
	
	// Step is used to iterate to the next event.
	IEnumerator step(){
		// The current event component is deactivated, and if it is a question, delivery, or 
		// destination event, then the whole game object is deactivated.
		currentEvent.enabled = false;
		if (currentEvent.question || currentEvent.destination) {
			currentEvent.gameObject.SetActive(false);
		}
		
		// THIS COULD BE AN INFINITE LOOP.
		// This loop WILL break if it doesn't complete in a timely (1000 iterations) manner.
		for (int i = currentEvent.order + 1; i > -1; i++) {
			Debug.Log ("Iterating - " + i.ToString() );
			if(eventList.ContainsKey(i.ToString())){
				//Debug.Log("hi how ya doin");
				((EventManager)eventList[(i).ToString()]).current = true;
				currentEvent = (EventManager)eventList[i.ToString()];
				currentEvent.gameObject.SetActive(true);
				currentEvent.enabled = true;
				if(currentEvent.text){
					Debug.Log ("Text event " + currentEvent.gameObject.name + " delayText method started.");
					return currentEvent.GetComponent<TimedText>().delayText();
				}
				break;
			}
			
			// If this loop iterates too long, then it is mercilessly killed and an error is thrown.
			if(i - currentEvent.order > 1000){
				currentEvent.completed = false;
				Debug.Log ("FATAL ERROR - iterated event step too many times");
				break;
			}
		}
		return null;
	}
}