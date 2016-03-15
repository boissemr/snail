using UnityEngine;
using System.Collections;

public class alarmStop : MonoBehaviour {
	
	void OnTriggerEnter(Collider col) {

		// stop sound if triggered by player
		if(col.gameObject.tag == "Player") {
			GameObject.Find ("Alarm").GetComponent<AudioSource>().Stop();
		}
	}
}
