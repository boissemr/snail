

using UnityEngine;
using System.Collections;

public class NPCMoveTo : MonoBehaviour {
	
	public int currentDestination; // int value where the NPC currently is
	public GameObject[] target; // an aray that holds the NPC's destinations
	private Transform destination; // holds the target at currentDestination's transform value
	private NavMeshAgent agent; // holds the gameObject's navMeshAent value for destination setting


	void Start () {
		currentDestination = 0;
		agent = gameObject.GetComponent<NavMeshAgent>();
		destination = target[currentDestination].transform;
	}

	void Update () {
		//sets the NavMeshAgents destination to the destination's position and continuously updates it
		agent.SetDestination(destination.position);
	
	}

	//sets the NPC's new destination to the next one in the array
	public void nextPosition(){
		currentDestination++;
		destination = target[currentDestination].transform;
	}
}


