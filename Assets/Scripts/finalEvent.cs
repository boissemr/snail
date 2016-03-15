using UnityEngine;
using System.Collections;
using System;

public class finalEvent : MonoBehaviour {

	private ReportCardManager rcm;

	// Use this for initialization
	void Start () {
		rcm = GameObject.Find ("Game Manager").gameObject.GetComponent<ReportCardManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (this.gameObject.GetComponent<EventManager> ().current) {
			//MAX TIME 
			rcm.writeWrongLine("XX:XX#" + Environment.NewLine);
			//YOUR TIME 
			rcm.writeWrongLine("XX:XX#" + Environment.NewLine);

			rcm.writeWrongLine(rcm.MaxScore + "#" + Environment.NewLine);
			rcm.writeWrongLine(rcm.score + "#" + Environment.NewLine);

			Application.LoadLevel ("End Scene");

		}
	}
}
