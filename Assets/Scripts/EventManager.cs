using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {

	// All accessable values by other classes for order of initialization, determining
	// relevance, event type, etc., etc.
	public int order;
	public bool completed, relevant, current;
	public bool job1, job2, job3;
	public bool question, pickup, delivery, destination, doorClose, text;
	public bool setupDone;
}
