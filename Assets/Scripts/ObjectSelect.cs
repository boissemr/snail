using UnityEngine;
using System.Collections;

public class ObjectSelect : MonoBehaviour {

	public GameObject worldRunner;
	public Camera camera;
	public GameObject text;
	public GameObject o1;
	public GameObject o2;
	public GameObject o3;
	public GameObject o4;

	public Material o1Mat;
	public Material o2Mat;
	public Material o3Mat;
	public Material o4Mat;
	public Material lookMat;

	public bool b1;
	public bool b2;
	public bool b3;
	public bool b4;

	public int lookingAt;

	public string contMes;

	private Ray camRay; //get if player looking at answers 
	private RaycastHit hit;

	// Use this for initialization
	void Start () {
		print ("grab objects live");
		camRay=camera.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
		o1Mat=o1.GetComponent<Renderer>().material;
		o2Mat=o2.GetComponent<Renderer>().material;
		o3Mat=o3.GetComponent<Renderer>().material;
		o4Mat=o4.GetComponent<Renderer>().material;
		b1=false;
		b2=false;
		b3=false;
		b4=false;
		lookingAt=0;
	}
	
	// Update is called once per frame
	void Update () {
		camRay=camera.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
		if(b4==false)//(b1==false||b2==false||b3==false||b4==false)
		{
			//gaze tracking
			//print ("gaze tracking");
			if(Physics.Raycast(camRay, out hit))
			{
				//print ("in tracking");
				if(hit.collider.tag=="Answer")
				{
					if(hit.transform.name==o1.transform.name)
					{
						print ("hit 1");
						lookingAt=1;
						o1.GetComponent<Renderer>().material.color=Color.blue;
						o2.GetComponent<Renderer>().material.color=Color.yellow;
						o3.GetComponent<Renderer>().material.color=Color.yellow;
						o4.GetComponent<Renderer>().material.color=Color.yellow;
					}
					if(hit.transform.name==o2.transform.name)
					{
						print ("hit 2");
						lookingAt=2;
						o2.GetComponent<Renderer>().material.color=Color.blue;
						o1.GetComponent<Renderer>().material.color=Color.yellow;
						o3.GetComponent<Renderer>().material.color=Color.yellow;
						o4.GetComponent<Renderer>().material.color=Color.yellow;
					}
					if(hit.transform.name==o3.transform.name)
					{
						print ("hit 3");
						lookingAt=3;
						o3.GetComponent<Renderer>().material.color=Color.blue;
						o2.GetComponent<Renderer>().material.color=Color.yellow;
						o1.GetComponent<Renderer>().material.color=Color.yellow;
						o4.GetComponent<Renderer>().material.color=Color.yellow;
					}
					if(hit.transform.name==o4.transform.name)
					{
						print ("hit 4");
						lookingAt=4;
						o4.GetComponent<Renderer>().material.color=Color.blue;
						o2.GetComponent<Renderer>().material.color=Color.yellow;
						o3.GetComponent<Renderer>().material.color=Color.yellow;
						o1.GetComponent<Renderer>().material.color=Color.yellow;
					}
					else
					{
						//print ("hit nothing");
						lookingAt=0;
						o1.GetComponent<Renderer>().material.color=Color.yellow;//fix material
						o2.GetComponent<Renderer>().material.color=Color.yellow;
						o3.GetComponent<Renderer>().material.color=Color.yellow;
						o4.GetComponent<Renderer>().material.color=Color.yellow;
					}
				}
			}
			//end gaze tracking
			//get gaze answer
			if(Input.GetKey(KeyCode.E))
			{
				if(lookingAt==1)
				{
					b1=true;
					o1.SetActive(false);
				}
				if(lookingAt==2)
				{
					print ("selected 2");
					b2=true;
					o2.SetActive(false);
				}
				if(lookingAt==3)
				{
					b3=true;
					o3.SetActive(false);
				}
				if(lookingAt==4)
				{
					b4=true;
					o4.SetActive(false);
				}
				if(lookingAt==0)
				{
					print("input answer while not looking at selection");
				}
			}
			//end get gaze answer
		}
		else
		{
			worldRunner.SendMessage(contMes);
			text.SetActive(false);
		}
	}//end update
}
