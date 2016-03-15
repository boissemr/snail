using UnityEngine;
using System.Collections;

public class Question : MonoBehaviour {

	public GameObject worldRunner; //used to send messages to world runner
	public Camera camera;
	public GameObject question;
	public GameObject q1; //used to change colors of text
	public GameObject q2;
	public GameObject q3;
	public GameObject q4;
	public GameObject cont;

	public string contMes;
	public int lookingAt;
	public bool answered; //has the player given a responce
	public bool correct; //worldRunner will pull this variable for each question in the scene
	public int answerGiven; //answer the player gives
	public int correctAnswer; //correct answer to the question
	public bool lookAtCont; //to continue the sim

	private Ray camRay; //get if player looking at answers 
	private RaycastHit hit;
	private Color fade= new Color(1,1,1,.25f);


	// Use this for initialization
	void Start () {
		answered=false;
		camRay=camera.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
		print("question is live");
		lookingAt=0;
	}
	
	// Update is called once per frame
	void Update () {
		camRay=camera.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
		if(!answered){ //this only needs to be called until the player answers, prevent multiple answering
			//check player gaze
			if(Physics.Raycast(camRay, out hit))
			{
				if(hit.collider.tag=="Answer")
				{
					if(hit.transform.name==q1.transform.name)
					{
						lookingAt=1;
						q1.GetComponent<Renderer>().material.color=Color.blue;
						q2.GetComponent<Renderer>().material.color=Color.white;
						q3.GetComponent<Renderer>().material.color=Color.white;
						q4.GetComponent<Renderer>().material.color=Color.white;
					}
					if(hit.transform.name==q2.transform.name)
					{
						lookingAt=2;
						q1.GetComponent<Renderer>().material.color=Color.white;
						q2.GetComponent<Renderer>().material.color=Color.blue;
						q3.GetComponent<Renderer>().material.color=Color.white;
						q4.GetComponent<Renderer>().material.color=Color.white;
					}
					if(hit.transform.name==q3.transform.name)
					{
						lookingAt=3;
						q1.GetComponent<Renderer>().material.color=Color.white;
						q2.GetComponent<Renderer>().material.color=Color.white;
						q3.GetComponent<Renderer>().material.color=Color.blue;
						q4.GetComponent<Renderer>().material.color=Color.white;
					}
					if(hit.transform.name==q4.transform.name)
					{
						lookingAt=4;
						q1.GetComponent<Renderer>().material.color=Color.white;
						q2.GetComponent<Renderer>().material.color=Color.white;
						q3.GetComponent<Renderer>().material.color=Color.white;
						q4.GetComponent<Renderer>().material.color=Color.blue;
					}
				}
				else
				{
					lookingAt=0;
					q1.GetComponent<Renderer>().material.color=Color.white;
					q2.GetComponent<Renderer>().material.color=Color.white;
					q3.GetComponent<Renderer>().material.color=Color.white;
					q4.GetComponent<Renderer>().material.color=Color.white;
				}
			}
			//end check player gaze

			//get gaze answer
			if(Input.GetKey(KeyCode.E))
			{
				if(lookingAt==1)
				{
					answerGiven=1;
					answered=true;
					print("player answered");
				}
				if(lookingAt==2)
				{
					answerGiven=2;
					answered=true;
					print("player answered");
				}
				if(lookingAt==3)
				{
					answerGiven=3;
					answered=true;
					print("player answered");
				}
				if(lookingAt==4)
				{
					answerGiven=4;
					answered=true;
					print("player answered");
				}
				if(lookingAt==0)
				{
					print("input answer while not looking at selection");
				}
			}
			//end get gaze answer

			//getting player answer keyboard
			if(Input.GetKeyUp(KeyCode.Alpha1))
			{
				answerGiven=1;
				answered=true;
				print("player answered");
			}
			if(Input.GetKeyUp(KeyCode.Alpha2))
			{
				answerGiven=2;
				answered=true;
				print("player answered");
			}
			if(Input.GetKeyUp(KeyCode.Alpha3))
			{
				answerGiven=3;
				answered=true;
				print("player answered");
			}
			if(Input.GetKeyUp(KeyCode.Alpha4))
			{
				answerGiven=4;
				answered=true;
				print("player answered");
			}
			//end getting player answer keyboard

			//check answer and change color
			if(answered)
			{	
				if(answerGiven==correctAnswer)
				{
					correct=true;
				}
				else
				{
					correct=false;
				}
				//color
				if(answerGiven==1)
				{
					if(correctAnswer==1)
					{
						q1.GetComponent<Renderer>().material.color=Color.green;
						q2.GetComponent<Renderer>().material.color=fade; //q2.renderer.material.color.a=.5f; (old not working)
						q3.GetComponent<Renderer>().material.color=fade;
						q4.GetComponent<Renderer>().material.color=fade;
					}
					if(correctAnswer==2)
					{
						q1.GetComponent<Renderer>().material.color=Color.red;
						q2.GetComponent<Renderer>().material.color=Color.green;
						q3.GetComponent<Renderer>().material.color=fade;
						q4.GetComponent<Renderer>().material.color=fade;
					}
					if(correctAnswer==3)
					{
						q1.GetComponent<Renderer>().material.color=Color.red;
						q2.GetComponent<Renderer>().material.color=fade;
						q3.GetComponent<Renderer>().material.color=Color.green;
						q4.GetComponent<Renderer>().material.color=fade;
					}
					if(correctAnswer==4)
					{
						q1.GetComponent<Renderer>().material.color=Color.red;
						q2.GetComponent<Renderer>().material.color=fade;
						q3.GetComponent<Renderer>().material.color=fade;
						q4.GetComponent<Renderer>().material.color=Color.green;
					}
				}
				if(answerGiven==2)
				{
					if(correctAnswer==1)
					{
						q1.GetComponent<Renderer>().material.color=Color.red;
						q2.GetComponent<Renderer>().material.color=Color.green;
						q3.GetComponent<Renderer>().material.color=fade;
						q4.GetComponent<Renderer>().material.color=fade;
					}
					if(correctAnswer==2)
					{
						q1.GetComponent<Renderer>().material.color=fade;
						q2.GetComponent<Renderer>().material.color=Color.green;
						q3.GetComponent<Renderer>().material.color=fade;;
						q4.GetComponent<Renderer>().material.color=fade;
					}
					if(correctAnswer==3)
					{
						q1.GetComponent<Renderer>().material.color=fade;
						q2.GetComponent<Renderer>().material.color=Color.green;
						q3.GetComponent<Renderer>().material.color=Color.red;
						q4.GetComponent<Renderer>().material.color=fade;
					}
					if(correctAnswer==4)
					{
						q1.GetComponent<Renderer>().material.color=fade;
						q2.GetComponent<Renderer>().material.color=Color.green;
						q3.GetComponent<Renderer>().material.color=fade;
						q4.GetComponent<Renderer>().material.color=Color.red;
					}
				}
				if(answerGiven==3)
				{
					if(correctAnswer==1)
					{
						q1.GetComponent<Renderer>().material.color=Color.green;
						q2.GetComponent<Renderer>().material.color=fade;
						q3.GetComponent<Renderer>().material.color=Color.red;
						q4.GetComponent<Renderer>().material.color=fade;
					}
					if(correctAnswer==2)
					{
						q1.GetComponent<Renderer>().material.color=fade;
						q2.GetComponent<Renderer>().material.color=Color.red;
						q3.GetComponent<Renderer>().material.color=Color.green;
						q4.GetComponent<Renderer>().material.color=fade;
					}
					if(correctAnswer==3)
					{
						q1.GetComponent<Renderer>().material.color=fade;
						q2.GetComponent<Renderer>().material.color=fade;
						q3.GetComponent<Renderer>().material.color=Color.green;
						q4.GetComponent<Renderer>().material.color=fade;
					}
					if(correctAnswer==4)
					{
						q1.GetComponent<Renderer>().material.color=fade;
						q2.GetComponent<Renderer>().material.color=fade;
						q3.GetComponent<Renderer>().material.color=Color.red;
						q4.GetComponent<Renderer>().material.color=Color.green;
					}
				}
				if(answerGiven==4)
				{
					if(correctAnswer==1)
					{
						q1.GetComponent<Renderer>().material.color=Color.green;
						q2.GetComponent<Renderer>().material.color=fade;
						q3.GetComponent<Renderer>().material.color=fade;
						q4.GetComponent<Renderer>().material.color=Color.red;
					}
					if(correctAnswer==2)
					{
						q1.GetComponent<Renderer>().material.color=fade;
						q2.GetComponent<Renderer>().material.color=Color.green;
						q3.GetComponent<Renderer>().material.color=fade;
						q4.GetComponent<Renderer>().material.color=Color.red;
					}
					if(correctAnswer==3)
					{
						q1.GetComponent<Renderer>().material.color=fade;
						q2.GetComponent<Renderer>().material.color=fade;
						q3.GetComponent<Renderer>().material.color=Color.green;
						q4.GetComponent<Renderer>().material.color=Color.red;
					}
					if(correctAnswer==4)
					{
						q1.GetComponent<Renderer>().material.color=fade;
						q2.GetComponent<Renderer>().material.color=fade;
						q3.GetComponent<Renderer>().material.color=fade;
						q4.GetComponent<Renderer>().material.color=Color.green;
					}
				}
				//end color
			}
			//end check answer and change color
		}
			//Continue and hide question
			if(answered)
			{
				cont.SetActive(true);
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
			}
			//end continue and hide question
	}
	
}
