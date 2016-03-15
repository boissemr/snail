using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class characterSound : MonoBehaviour {

	private List<AudioClip> steps = new List<AudioClip> ();

	// Use this for initialization
	void Start () {
		// Grabs two audioclips in the resources folder named STEP1 and STEP2. These are our choices for
		// step sounds.
		steps.Add ((AudioClip)Resources.Load ("STEP1"));
		steps.Add ((AudioClip)Resources.Load ("STEP2"));
	}
	
	// Update is called once per frame
	void Update () {
	
		// If this controller receives WASD input of any kind, then the clip of the audio source connected to
		// the gameObject of this component is changed to a random clip in the "steps" list. If the audioSource
		// is not already playing, the sound clip is then played.
		if(Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.D) ){
			if(!this.gameObject.GetComponent<AudioSource>().isPlaying){
				this.gameObject.GetComponent<AudioSource>().clip = steps[(int)(Random.value * steps.Count)];
				this.gameObject.GetComponent<AudioSource>().Play();
			}
		}

	}
}
