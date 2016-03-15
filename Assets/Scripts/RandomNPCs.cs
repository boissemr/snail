using UnityEngine;
using System.Collections.Generic;

public class RandomNPCs : MonoBehaviour {

	public List<GameObject> NPCs = new List<GameObject>();
	private int i, active; //i = random member of the List, active tracks the number of activated NPCs
	public int desiredNPCs; //number of NPCs wanted 

	// Use this for initialization
	void Start () {
		foreach(GameObject g in NPCs){ //make sure all NPCs are off
			g.SetActive (false);
		}
		active = 0;
		while(active < desiredNPCs){
			i = Random.Range (0,NPCs.Count);
			if(!(NPCs[i].activeInHierarchy)){
				NPCs[i].SetActive(true);
				active++;
				Debug.Log (NPCs[i].name + " was activated");
				Debug.Log ((desiredNPCs-active) + " more NPCs needed");
			}
			else{
				Debug.Log (NPCs[i].name + " is already active, selecting again...");
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
}
