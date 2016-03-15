using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class characterSelectQuestion : MonoBehaviour {
	
	// Public variable for statemanagement by the "QuestionSeriesManager" code.
	public bool completed;
	public bool job1, job2, job3;
	
	// Variables for managing question/answer stuff.
	public string questionText;
	public bool multipleAnswers;
	
	private Color shouldaPicked = new Color32(72, 170, 72, 255);
	private Color originalColor;
	private List<questionObjectTest> answers;
	
	// Declaration of variables used for raycasting out of the camera.
	private Camera mCamera; // mCamera is the Main Camera, thus the M.
	private Ray cameRay;
	private RaycastHit hit;
	
	// Declaration of variables used for "report card" stuff.
	public bool correct;
	public string reportCardExportString;
	
	// Use this for initialization
	void Start () {
		
		// The reportCardExportString variable is used to create a human-readable string that 
		// can easily be written to a .txt file. The format of this line is as follows:
		// "QuestionGameObjectName: ActualQuestionText - CORRECT/INCORRECT". These values
		// are set here, and then also in the questionSeriesManager.
		reportCardExportString += (this.gameObject.name + ": " + questionText);
		
		this.GetComponent<Text> ().text = questionText;
		
		// Grabs the camera in the scene tagged as "MainCamera" and is used as the main camera
		// for raycasting and such. Logs an error if the Main Camera isn't found.
		mCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		if (mCamera == null) {
			Debug.Log ("Main camera not found.");
		} else {
			Debug.Log ("Main Camera Found");
		}
		
		// Creates a ray shooting straight out of the center of the viewpoint of the camera.
		cameRay = mCamera.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
		
		// This section grabs all the answers from the child objects and adds them to an array
		// of possible answers. If answers have text that is left empty, the answer is removed
		// from the array. In this test, correct answers are highlighted green and incorrect
		// answers are highlighted red. In addition, all correctly entered question text is
		// logged to the console for testing purposes.
		
		bool notEmpty = false; // Tracks whether or not the answers array is empty.
		
		// Here, we instantiate a list for the sole purpose of  checking for empty strings
		// inside of answers.
		List<questionObjectTest> tempAnswers = new List<questionObjectTest>();
		answers = new List<questionObjectTest>();
		
		// Answers is populated with the questionObjectTest components of each of its children
		// which have a questionObjecttest component.
		foreach(questionObjectTest quest in this.GetComponentsInChildren<questionObjectTest>()){
			originalColor = quest.gameObject.GetComponent<Text>().color;
			answers.Add (quest);
		}
		foreach(questionObjectTest quest in answers){
			tempAnswers.Add(quest);
		}
		
		// If an answer has no text for its answer, the answer is removed from the array.
		foreach(questionObjectTest ans in tempAnswers){
			if(ans.answerText == string.Empty){
				ans.gameObject.SetActive(false);
				answers.Remove(ans);
			}else{
				notEmpty = true;
			}
		}
		
		// Now we check if the question is a multiple-answer or "list-style" question. If
		// more than one answer is labeled as correct, then it is a list-style question.
		bool answer1 = false;
		foreach(questionObjectTest ans in answers){
			if(ans.correct == true){
				if(answer1){
					multipleAnswers = true;
				}else{
					answer1 = true;
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		// This variable is used to track whether or not the raycast from the camera hit
		// anything. This information is used for 'hovering' purposes.
		bool noHit = true;
		
		// This draws a new raycast every frame.
		cameRay = mCamera.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
		Debug.Log (cameRay.direction);
		
		// Iterates through every answer object in the answers array.
		foreach(questionObjectTest ans in answers){
			// Checks if the raycast hit an answer, and only runs if the question has not
			// been completed.
			if(Physics.Raycast(cameRay, out hit) && !completed){
				
				Debug.Log (hit.collider.gameObject.name);
				// If the raycast hits a possible answer, the answer is "hovered" and noHit
				// is set to false. If the Fire1 (LMB at time of writing) is pressed, the
				// answer is selected.
				if(hit.collider.gameObject == ans.gameObject){
					Debug.Log ("HIT AT " + answers.IndexOf(ans));
					hover (ans.gameObject);
					noHit = false;
					if(Input.GetButtonDown("Fire1")){
						// If the clicked answer is tagged as a selector, answerValidation
						// is run.
						if(ans.selector){
							answerValidation();
						}else{
							select(ans.gameObject);
						}
					}
				}
				// Checks if the raycast hits the gameObject attached to this code.
				
			}
		}
		// If the raycast didn't hit anything, then all answers are "unhovered".
		if(noHit){
			unHover();
		}
	}
	
	// Answer validation is run when the "done" button is pressed. It checks all selected answers
	// against the answers list. If the selected answer(s) is/are correct, they are turned 
	// bright green. If the selected answer(s) is/are incorrect, they are turned red, and the correct
	// answers are highlighted in a color to indicate they should have been selected (dark green, at
	// time of writing). Additionally, if a correct answer is indicated, the boolean "correct" is set
	// to correct, and any incorrect answers set the boolean "correct" to false.
	void answerValidation(){
		correct = true;
		foreach(questionObjectTest ans in answers){
			if(ans.selected){
				Debug.Log (ans.gameObject.name + " has been selected and confirmed");
			}
		}
		if (correct) {
			this.gameObject.GetComponent<AudioSource> ().clip = (AudioClip)Resources.Load ("CORRECT");
		} else {
			this.gameObject.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load ("INCORRECT");
		}
		this.gameObject.GetComponent<AudioSource> ().Play ();
		selectNone ();
		completed = true;
	}
	
	// Hover is passed a gameobject, which has the FontStyle of its text component changed to
	// bold and italics. Every other object has the FontStyle of its text component set to normal.
	void hover(GameObject que){
		foreach(questionObjectTest que2 in answers){
			que2.gameObject.GetComponent<Text>().fontStyle = FontStyle.Normal;
		}
		que.gameObject.GetComponent<Text>().fontStyle = FontStyle.BoldAndItalic;
	}
	
	// UnHover changes all the FontStyle of all answers in the answer array, as well as the
	// FontStyle of this object itself, to normal.
	void unHover(){
		foreach (questionObjectTest que in answers){
			que.gameObject.GetComponent<Text>().fontStyle = FontStyle.Normal;
		}
	}
	
	// SelectNone changes the "selected" value of all answers in the answers list to false.
	void selectNone(){
		foreach(questionObjectTest qObj in answers){
			qObj.selected = false;
		}
	}
	
	// This method is used to select one answer within the "answers" array and change its
	// selected value to true, and if the question is not list-style, then it changes all 
	// other selected values to false.
	void select(GameObject obj){
		if (obj.GetComponent<questionObjectTest> ().selected == false) {
			if (!multipleAnswers) {
				foreach (questionObjectTest qObj in answers) {
					qObj.selected = false;
					qObj.gameObject.GetComponent<Text> ().color = originalColor;
				}
			}
			obj.GetComponent<questionObjectTest> ().selected = true;
			obj.gameObject.GetComponent<Text> ().color = Color.yellow;
		} else {
			obj.GetComponent<questionObjectTest>().selected = false;
			obj.GetComponent<Text>().color = originalColor;
		}
	}
}