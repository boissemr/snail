using UnityEngine;
using System.Collections;

public class WristBandCheck : MonoBehaviour {
	public GameObject worldRunner; //used to send messages to world runner
	public Camera camera;
	public GameObject question;
	public GameObject band;
	private Ray camRay; //get if player looking at answers 
	private RaycastHit hit;
	public bool lookingAtBand;
	// Use this for initialization
	void Start () {
		lookingAtBand=false;
		camRay=camera.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
		print("wrist check");
	}
	
	// Update is called once per frame
	void Update () {
		camRay=camera.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
		if(Physics.Raycast(camRay, out hit))
		{
			if(hit.collider.tag=="Answer")
			{
				if(hit.transform.name==band.transform.name)
				{
					band.GetComponent<Renderer>().material.color=Color.blue;
					lookingAtBand=true;
				}
			}
			else
			{
				band.GetComponent<Renderer>().material.color=Color.red;
				lookingAtBand=false;
			}
		}
		if(lookingAtBand)
		{
			if(Input.GetKey(KeyCode.E))
			{
				worldRunner.SendMessage("BandCheck");
				question.SetActive(false);
			}
		}
	}
}
