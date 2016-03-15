using UnityEngine;
using System.Collections;

public class LongCheckList : MonoBehaviour {

	public GameObject worldRunner;
	public Camera camera;
	public GameObject question;
	public GameObject q1;
	public GameObject q2;
	public GameObject q3;
	public GameObject q4;
	public GameObject q5;
	public GameObject q6;
	public GameObject q7;
	public GameObject q8;
	public GameObject q9;
	public GameObject q10;

	
	public GameObject s1;//selection mark appears if selected by player
	public GameObject s2;
	public GameObject s3;
	public GameObject s4;
	public GameObject s5;
	public GameObject s6;
	public GameObject s7;
	public GameObject s8;
	public GameObject s9;
	public GameObject s10;

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
	public bool i5;
	public bool i6;
	public bool i7;
	public bool i8;
	public bool i9;
	public bool i10;

	public bool ans1; //true mean it needs to be selected for a correct answer
	public bool ans2;
	public bool ans3;
	public bool ans4;
	public bool ans5;
	public bool ans6;
	public bool ans7;
	public bool ans8;
	public bool ans9;
	public bool ans10;

	private Ray camRay; //get if player looking at answers 
	private RaycastHit hit;
	
	private Color fade= new Color(1,1,1,.25f);

	// Use this for initialization
	void Start () {
		isDone=false;
		camRay=camera.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
		print("long checklist is live");
		lookingAt=0;
		i1=false;
		i2=false;
		i3=false;
		i4=false;
		i5=false;
		i6=false;
		i7=false;
		i8=false;
		i9=false;
		i10=false;
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
						q5.GetComponent<Renderer>().material.color=Color.white;
						q6.GetComponent<Renderer>().material.color=Color.white;
						q7.GetComponent<Renderer>().material.color=Color.white;
						q8.GetComponent<Renderer>().material.color=Color.white;
						q9.GetComponent<Renderer>().material.color=Color.white;
						q10.GetComponent<Renderer>().material.color=Color.white;
						done.GetComponent<Renderer>().material.color=Color.white;
					}
					if((hit.transform.name==q2.transform.name)&&i2==false)
					{
						lookingAt=2;
						q1.GetComponent<Renderer>().material.color=Color.white;
						q2.GetComponent<Renderer>().material.color=Color.blue;
						q3.GetComponent<Renderer>().material.color=Color.white;
						q4.GetComponent<Renderer>().material.color=Color.white;
						q5.GetComponent<Renderer>().material.color=Color.white;
						q6.GetComponent<Renderer>().material.color=Color.white;
						q7.GetComponent<Renderer>().material.color=Color.white;
						q8.GetComponent<Renderer>().material.color=Color.white;
						q9.GetComponent<Renderer>().material.color=Color.white;
						q10.GetComponent<Renderer>().material.color=Color.white;
						done.GetComponent<Renderer>().material.color=Color.white;
					}
					if((hit.transform.name==q3.transform.name)&&i3==false)
					{
						lookingAt=3;
						q1.GetComponent<Renderer>().material.color=Color.white;
						q2.GetComponent<Renderer>().material.color=Color.white;
						q3.GetComponent<Renderer>().material.color=Color.blue;
						q4.GetComponent<Renderer>().material.color=Color.white;
						q5.GetComponent<Renderer>().material.color=Color.white;
						q6.GetComponent<Renderer>().material.color=Color.white;
						q7.GetComponent<Renderer>().material.color=Color.white;
						q8.GetComponent<Renderer>().material.color=Color.white;
						q9.GetComponent<Renderer>().material.color=Color.white;
						q10.GetComponent<Renderer>().material.color=Color.white;
						done.GetComponent<Renderer>().material.color=Color.white;
					}
					if((hit.transform.name==q4.transform.name)&&i4==false)
					{
						lookingAt=4;
						q1.GetComponent<Renderer>().material.color=Color.white;
						q2.GetComponent<Renderer>().material.color=Color.white;
						q3.GetComponent<Renderer>().material.color=Color.white;
						q4.GetComponent<Renderer>().material.color=Color.blue;
						q5.GetComponent<Renderer>().material.color=Color.white;
						q6.GetComponent<Renderer>().material.color=Color.white;
						q7.GetComponent<Renderer>().material.color=Color.white;
						q8.GetComponent<Renderer>().material.color=Color.white;
						q9.GetComponent<Renderer>().material.color=Color.white;
						q10.GetComponent<Renderer>().material.color=Color.white;
						done.GetComponent<Renderer>().material.color=Color.white;
					}
					if((hit.transform.name==q5.transform.name)&&i5==false)
					{
						lookingAt=5;
						q1.GetComponent<Renderer>().material.color=Color.white;
						q2.GetComponent<Renderer>().material.color=Color.white;
						q3.GetComponent<Renderer>().material.color=Color.white;
						q4.GetComponent<Renderer>().material.color=Color.white;
						q5.GetComponent<Renderer>().material.color=Color.blue;
						q6.GetComponent<Renderer>().material.color=Color.white;
						q7.GetComponent<Renderer>().material.color=Color.white;
						q8.GetComponent<Renderer>().material.color=Color.white;
						q9.GetComponent<Renderer>().material.color=Color.white;
						q10.GetComponent<Renderer>().material.color=Color.white;
						done.GetComponent<Renderer>().material.color=Color.white;
					}
					if((hit.transform.name==q6.transform.name)&&i6==false)
					{
						lookingAt=6;
						q1.GetComponent<Renderer>().material.color=Color.white;
						q2.GetComponent<Renderer>().material.color=Color.white;
						q3.GetComponent<Renderer>().material.color=Color.white;
						q4.GetComponent<Renderer>().material.color=Color.white;
						q5.GetComponent<Renderer>().material.color=Color.white;
						q6.GetComponent<Renderer>().material.color=Color.blue;
						q7.GetComponent<Renderer>().material.color=Color.white;
						q8.GetComponent<Renderer>().material.color=Color.white;
						q9.GetComponent<Renderer>().material.color=Color.white;
						q10.GetComponent<Renderer>().material.color=Color.white;
						done.GetComponent<Renderer>().material.color=Color.white;
					}
					if((hit.transform.name==q7.transform.name)&&i7==false)
					{
						lookingAt=7;
						q1.GetComponent<Renderer>().material.color=Color.white;
						q2.GetComponent<Renderer>().material.color=Color.white;
						q3.GetComponent<Renderer>().material.color=Color.white;
						q4.GetComponent<Renderer>().material.color=Color.white;
						q5.GetComponent<Renderer>().material.color=Color.white;
						q6.GetComponent<Renderer>().material.color=Color.white;
						q7.GetComponent<Renderer>().material.color=Color.blue;
						q8.GetComponent<Renderer>().material.color=Color.white;
						q9.GetComponent<Renderer>().material.color=Color.white;
						q10.GetComponent<Renderer>().material.color=Color.white;
						done.GetComponent<Renderer>().material.color=Color.white;
					}
					if((hit.transform.name==q8.transform.name)&&i8==false)
					{
						lookingAt=8;
						q1.GetComponent<Renderer>().material.color=Color.white;
						q2.GetComponent<Renderer>().material.color=Color.white;
						q3.GetComponent<Renderer>().material.color=Color.white;
						q4.GetComponent<Renderer>().material.color=Color.white;
						q5.GetComponent<Renderer>().material.color=Color.white;
						q6.GetComponent<Renderer>().material.color=Color.white;
						q7.GetComponent<Renderer>().material.color=Color.white;
						q8.GetComponent<Renderer>().material.color=Color.blue;
						q9.GetComponent<Renderer>().material.color=Color.white;
						q10.GetComponent<Renderer>().material.color=Color.white;
						done.GetComponent<Renderer>().material.color=Color.white;
					}
					if((hit.transform.name==q9.transform.name)&&i9==false)
					{
						lookingAt=9;
						q1.GetComponent<Renderer>().material.color=Color.white;
						q2.GetComponent<Renderer>().material.color=Color.white;
						q3.GetComponent<Renderer>().material.color=Color.white;
						q4.GetComponent<Renderer>().material.color=Color.white;
						q5.GetComponent<Renderer>().material.color=Color.white;
						q6.GetComponent<Renderer>().material.color=Color.white;
						q7.GetComponent<Renderer>().material.color=Color.white;
						q8.GetComponent<Renderer>().material.color=Color.white;
						q9.GetComponent<Renderer>().material.color=Color.blue;
						q10.GetComponent<Renderer>().material.color=Color.white;
						done.GetComponent<Renderer>().material.color=Color.white;
					}
					if((hit.transform.name==q10.transform.name)&&i10==false)
					{
						lookingAt=10;
						q1.GetComponent<Renderer>().material.color=Color.white;
						q2.GetComponent<Renderer>().material.color=Color.white;
						q3.GetComponent<Renderer>().material.color=Color.white;
						q4.GetComponent<Renderer>().material.color=Color.white;
						q5.GetComponent<Renderer>().material.color=Color.white;
						q6.GetComponent<Renderer>().material.color=Color.white;
						q7.GetComponent<Renderer>().material.color=Color.white;
						q8.GetComponent<Renderer>().material.color=Color.white;
						q9.GetComponent<Renderer>().material.color=Color.white;
						q10.GetComponent<Renderer>().material.color=Color.blue;
						done.GetComponent<Renderer>().material.color=Color.white;
					}
					if(hit.transform.name==done.transform.name)
					{
						lookingAt=11;
						q1.GetComponent<Renderer>().material.color=Color.white;
						q2.GetComponent<Renderer>().material.color=Color.white;
						q3.GetComponent<Renderer>().material.color=Color.white;
						q4.GetComponent<Renderer>().material.color=Color.white;
						q5.GetComponent<Renderer>().material.color=Color.white;
						q6.GetComponent<Renderer>().material.color=Color.white;
						q7.GetComponent<Renderer>().material.color=Color.white;
						q8.GetComponent<Renderer>().material.color=Color.white;
						q9.GetComponent<Renderer>().material.color=Color.white;
						q10.GetComponent<Renderer>().material.color=Color.white;
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
					q5.GetComponent<Renderer>().material.color=Color.white;
					q6.GetComponent<Renderer>().material.color=Color.white;
					q7.GetComponent<Renderer>().material.color=Color.white;
					q8.GetComponent<Renderer>().material.color=Color.white;
					q9.GetComponent<Renderer>().material.color=Color.white;
					q10.GetComponent<Renderer>().material.color=Color.white;
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
					i5=true;
					s5.SetActive(true);
					q5.GetComponent<Renderer>().material.color=Color.yellow;
					print("player selected 5");
				}
				if(lookingAt==6)
				{
					i6=true;
					s6.SetActive(true);
					q6.GetComponent<Renderer>().material.color=Color.yellow;
					print("player selected 6");
				}
				if(lookingAt==7)
				{
					i7=true;
					s7.SetActive(true);
					q7.GetComponent<Renderer>().material.color=Color.yellow;
					print("player selected 7");
				}
				if(lookingAt==8)
				{
					i8=true;
					s8.SetActive(true);
					q8.GetComponent<Renderer>().material.color=Color.yellow;
					print("player selected 8");
				}
				if(lookingAt==9)
				{
					i9=true;
					s9.SetActive(true);
					q9.GetComponent<Renderer>().material.color=Color.yellow;
					print("player selected 9");
				}
				if(lookingAt==10)
				{
					i10=true;
					s10.SetActive(true);
					q10.GetComponent<Renderer>().material.color=Color.yellow;
					print("player selected 10");
				}
				if(lookingAt==11)
				{
					isDone=true;
					print("player is done checking");
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
			done.SetActive(false);
			//check correct answer
			q1.GetComponent<Renderer>().material.color=Color.green;
			q2.GetComponent<Renderer>().material.color=Color.green;
			q3.GetComponent<Renderer>().material.color=Color.green;
			q4.GetComponent<Renderer>().material.color=Color.green;
			q5.GetComponent<Renderer>().material.color=Color.green;
			q6.GetComponent<Renderer>().material.color=Color.green;
			q7.GetComponent<Renderer>().material.color=Color.green;
			q8.GetComponent<Renderer>().material.color=Color.green;
			q9.GetComponent<Renderer>().material.color=Color.green;
			q10.GetComponent<Renderer>().material.color=Color.green;
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
