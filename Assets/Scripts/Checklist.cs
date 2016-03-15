using UnityEngine;
using System.Collections;

public class Checklist : MonoBehaviour {

	public GameObject worldRunner;
	public Camera camera;
	public GameObject question;
	public GameObject q1;
	public GameObject q2;
	public GameObject q3;
	public GameObject q4;

	public GameObject s1;//selection mark appears if selected by player
	public GameObject s2;
	public GameObject s3;
	public GameObject s4;
	public GameObject done; //done answering
	public GameObject cont; //continue with sim

	public bool isDone; //done answering
	public string contMes;
	public int lookingAt;
	public bool correct; //worldRunner will pull this variable for each question in the scene
	public bool i1; //true means they were selected
	public bool i2;
	public bool i3;
	public bool i4;
	public bool ans1; //true mean it needs to be selected for a correct answer
	public bool ans2;
	public bool ans3;
	public bool ans4;

	private Ray camRay; //get if player looking at answers 
	private RaycastHit hit;

	private Color fade= new Color(1,1,1,.25f);

	// Use this for initialization
	void Start () {
		isDone=false;
		camRay=camera.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
		print("checklist is live");
		lookingAt=0;
		i1=false;
		i2=false;
		i3=false;
		i4=false;
	}
	
	// Update is called once per frame
	void Update () {
		camRay=camera.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
		if(!isDone) //if the player hasnt clicked done
		{
			//Check player gaze
			if(Physics.Raycast(camRay, out hit))
			{
				if(hit.collider.tag=="Answer")
				{
					if((hit.transform.name==q1.transform.name)&&i1==false)
					{
						lookingAt=1;
						q1.GetComponent<Renderer>().material.color=Color.blue;
						q2.GetComponent<Renderer>().material.color=Color.white;
						q3.GetComponent<Renderer>().material.color=Color.white;
						q4.GetComponent<Renderer>().material.color=Color.white;
						done.GetComponent<Renderer>().material.color=Color.white;
					}
					if((hit.transform.name==q2.transform.name)&&i2==false)
					{
						lookingAt=2;
						q1.GetComponent<Renderer>().material.color=Color.white;
						q2.GetComponent<Renderer>().material.color=Color.blue;
						q3.GetComponent<Renderer>().material.color=Color.white;
						q4.GetComponent<Renderer>().material.color=Color.white;
						done.GetComponent<Renderer>().material.color=Color.white;
					}
					if((hit.transform.name==q3.transform.name)&&i3==false)
					{
						lookingAt=3;
						q1.GetComponent<Renderer>().material.color=Color.white;
						q2.GetComponent<Renderer>().material.color=Color.white;
						q3.GetComponent<Renderer>().material.color=Color.blue;
						q4.GetComponent<Renderer>().material.color=Color.white;
						done.GetComponent<Renderer>().material.color=Color.white;
					}
					if((hit.transform.name==q4.transform.name)&&i4==false)
					{
						lookingAt=4;
						q1.GetComponent<Renderer>().material.color=Color.white;
						q2.GetComponent<Renderer>().material.color=Color.white;
						q3.GetComponent<Renderer>().material.color=Color.white;
						q4.GetComponent<Renderer>().material.color=Color.blue;
						done.GetComponent<Renderer>().material.color=Color.white;
					}
					if(hit.transform.name==done.transform.name)
					{
						lookingAt=5;
						q1.GetComponent<Renderer>().material.color=Color.white;
						q2.GetComponent<Renderer>().material.color=Color.white;
						q3.GetComponent<Renderer>().material.color=Color.white;
						q4.GetComponent<Renderer>().material.color=Color.white;
						done.GetComponent<Renderer>().material.color=Color.blue;
					}
				}
				else
				{
					lookingAt=0;
					q1.GetComponent<Renderer>().material.color=Color.white;
					q2.GetComponent<Renderer>().material.color=Color.white;
					q3.GetComponent<Renderer>().material.color=Color.white;
					q4.GetComponent<Renderer>().material.color=Color.white;
					done.GetComponent<Renderer>().material.color=Color.white;
				}
			}
			//end check player gaze
			//get gaze answers
			if(Input.GetKey(KeyCode.E))
			{
				if(lookingAt==1)
				{
					i1=true;
					s1.SetActive(true);
					q1.GetComponent<Renderer>().material.color=Color.yellow;
					print("player selected 1");
				}
				if(lookingAt==2)
				{
					i2=true;
					s2.SetActive(true);
					q2.GetComponent<Renderer>().material.color=Color.yellow;
					print("player selected 2");
				}
				if(lookingAt==3)
				{
					i3=true;
					s3.SetActive(true);
					q3.GetComponent<Renderer>().material.color=Color.yellow;
					print("player selected 3");
				}
				if(lookingAt==4)
				{
					i4=true;
					s4.SetActive(true);
					q4.GetComponent<Renderer>().material.color=Color.yellow;
					print("player selected 4");
				}
				if(lookingAt==5)
				{
					isDone=true;
					print("player is finished selecting");
				}
				if(lookingAt==0)
				{
					print("input answer while not looking at selection");
				}
			}
			//end get gaze answers
		}

		if(isDone) //Check answers and change colors
		{
			cont.SetActive(true);
			//check correct answer
			if((i1&&ans1)&&(i2&&ans2)&&(i3&&ans3)&&(i4&&ans4))
			{
				correct=true;
			}
			else
			{
				correct=false;
			}
			//end check answer
			//set final color
			if(i1==true&&ans1==true)//set q1
			{
				q1.GetComponent<Renderer>().material.color=Color.green;
			}
			else if(i1==true&&ans1==false)
			{
				q1.GetComponent<Renderer>().material.color=Color.red;
			}
			else if(i1==false&&ans1==false)
			{
				q1.GetComponent<Renderer>().material.color=fade;
			}
			else if(i1==false&&ans1==true)
			{
				q1.GetComponent<Renderer>().material.color=Color.green;
			}//end q1

			if(i2==true&&ans2==true)//set q2
			{
				q2.GetComponent<Renderer>().material.color=Color.green;
			}
			else if(i2==true&&ans2==false)
			{
				q2.GetComponent<Renderer>().material.color=Color.red;
			}
			else if(i2==false&&ans2==false)
			{
				q2.GetComponent<Renderer>().material.color=fade;
			}
			else if(i2==false&&ans2==true)
			{
				q2.GetComponent<Renderer>().material.color=Color.green;
			}//end q2

			if(i3==true&&ans3==true)//set q3
			{
				q3.GetComponent<Renderer>().material.color=Color.green;
			}
			else if(i3==true&&ans3==false)
			{
				q3.GetComponent<Renderer>().material.color=Color.red;
			}
			else if(i3==false&&ans3==false)
			{
				q3.GetComponent<Renderer>().material.color=fade;
			}
			else if(i3==false&&ans3==true)
			{
				q3.GetComponent<Renderer>().material.color=Color.green;
			}//end q3

			if(i4==true&&ans4==true)//set q4
			{
				q4.GetComponent<Renderer>().material.color=Color.green;
			}
			else if(i4==true&&ans4==false)
			{
				q4.GetComponent<Renderer>().material.color=Color.red;
			}
			else if(i4==false&&ans4==false)
			{
				q4.GetComponent<Renderer>().material.color=fade;
			}
			else if(i4==false&&ans4==true)
			{
				q4.GetComponent<Renderer>().material.color=Color.green;
			}//end q4
			//end set final color

			//continue
			if(Physics.Raycast(camRay, out hit))
			{
				if(hit.collider.tag=="Answer")
				{
					if(hit.transform.name==cont.transform.name)
					{
						cont.GetComponent<Renderer>().material.color=Color.blue;
						if(Input.GetKey(KeyCode.E))
						{
							worldRunner.SendMessage(contMes);
							question.SetActive(false);
						}
					}
					else
					{
						cont.GetComponent<Renderer>().material.color=Color.white;
					}
				}
			}
			//end continue

		}
	}//end update
}