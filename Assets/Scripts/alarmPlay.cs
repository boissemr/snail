using UnityEngine;
using System.Collections;

public class alarmPlay : MonoBehaviour {

	public AudioClip alarm;
	public AudioSource playerSource;
	
	void Start () {

		// find audio source
		playerSource = GameObject.Find("Player").GetComponent <AudioSource>();
	}

	void OnTriggerEnter(Collider col) {

		// play sound if triggered by player
		if(col.gameObject.tag == "Player") {
			GameObject.Find("Alarm").GetComponent<AudioSource>().Play();
		}
	}

	/*
	IEnumerator PlayAudio(int times)
	{
		for(int i=0; i<times; i++)
		{
			playerSource.PlayOneShot(alarm, 0.7F);
			yield return new WaitForSeconds(0.5F);
		}
	}
	*/
}


