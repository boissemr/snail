using UnityEngine;
using System.Collections;

public class DelaySpawn : MonoBehaviour {

	public float waitTime;
	public GameObject activate;

	// Use this for initialization
	public void Start() {
		StartCoroutine(Delay());
	}
	
	public IEnumerator Delay() {
		yield return new WaitForSeconds(waitTime);
		activate.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
