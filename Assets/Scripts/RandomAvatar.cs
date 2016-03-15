using UnityEngine;
using System.Collections.Generic;

public class RandomAvatar : MonoBehaviour {

	public List<Avatar> avatars = new List<Avatar>();
	private int i; 

	// Use this for initialization
	void Start () {
		i = Random.Range (0,avatars.Count);
		gameObject.GetComponent<Animator>().avatar = avatars[i];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
