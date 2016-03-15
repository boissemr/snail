using UnityEngine;
using System.Collections;

public class TimedActive : MonoBehaviour {

	public GameObject thisObject;
	public GameObject nextObject;

	public float lifeTime; //set in inspector

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(lifeTime<=0)
		{
			nextObject.SetActive(true);
			thisObject.SetActive(false);
		}
		lifeTime-=Time.deltaTime;
	}
}
