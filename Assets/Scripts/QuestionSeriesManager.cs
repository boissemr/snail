using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QuestionSeriesManager : MonoBehaviour {

	// Declaration of variables used for question iteration management.
	public bool seriesCompleted = false;
	public List<questiontest> questions = new List<questiontest>();

	private questiontest currentQuestion;
	private bool questionDone;

	// Declaration of variables for "report card" exporting.
	private ReportCardManager reportCard;

	// For accessing and using functions of the game manager.
	private GameObject gameManager;

	// Use this for initialization
	void Start () {
	
		try {
			gameManager = GameObject.Find("Game Manager");
			reportCard = gameManager.GetComponent<ReportCardManager>();
		} catch {
			Debug.Log("Game Manager not found.");
			return;
		}

		foreach (questiontest que in this.GetComponentsInChildren<questiontest>()) {
			if(gameManager.GetComponent<eventLoadoutManager>().job1 && que.job1){
				questions.Add(que);
			}
			if(gameManager.GetComponent<eventLoadoutManager>().job2 && que.job2){
				questions.Add(que);
			}
			if(gameManager.GetComponent<eventLoadoutManager>().job3 && que.job3){
				questions.Add(que);
			}
			que.gameObject.SetActive(false);
		}

		currentQuestion = questions [0];

		this.gameObject.GetComponent<EventManager> ().setupDone = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.gameObject.GetComponent<EventManager> ().current && questions[0].completed == false) {
			questions[0].gameObject.SetActive(true);
			currentQuestion = questions[0];
		}

		if (currentQuestion.completed && !questionDone) {
			StartCoroutine (step ());
		}
	}

	// Step is handed a questiontest paramater, waits one and a half seconds, and then
	// turns off the object it is handed. Specifically, it sets the "questionDone" variable
	// to true at the beginning, to prevent further firings of the same CoRoutine. Then,
	// It increments the MaxScore of the reportCard object, and if the current question
	// was answered correctly, then it increments the score and adds " - CORRECT" to the
	// output string of the "questiontest" object. (See the questiontest component's Start() 
	// function for further information and documentation on the reportCardExportString 
	// object.) After the score is modified and the exporstring has the appropriate 
	// correct/incorrect tags added, the line is written out to the reportcard file. 
	// (Further documentation on the reportcard file can be found in the ReportCardManager 
	// component.) After all that is done, the object it has been handed is deactivated.
	IEnumerator step(){
		questionDone = true;
		if (currentQuestion.incorrectAnswer != null && !currentQuestion.correct) {
			yield return new WaitForSeconds (currentQuestion.incorrectAnswer.length);	
		} else {
			yield return new WaitForSeconds(1.5f);
		}
		reportCard.MaxScore++;
		if (currentQuestion.correct) {
			reportCard.score++;
			currentQuestion.reportCardExportString += " - CORRECT\n";
		} else if(!currentQuestion.correct && currentQuestion.multipleAnswers){
			currentQuestion.reportCardExportString += " - INCORRECT\n";
		}
		reportCard.writeLine (currentQuestion.reportCardExportString);
		reportCard.writeWrongLine (currentQuestion.computerReportCardExportString);
		currentQuestion.gameObject.SetActive (false);
		// If there is another question in the questions list, then the next question
		// is activated.
		if (questions.IndexOf (currentQuestion) + 1 < questions.Count) {
			questions [questions.IndexOf (currentQuestion) + 1].gameObject.SetActive (true);
			currentQuestion = questions [questions.IndexOf (currentQuestion) + 1];
		} else {
			Debug.Log ("Questions for " + this.gameObject.name + " finished! Final score: " + reportCard.score + '/' + reportCard.MaxScore);
			seriesCompleted = true;
			this.GetComponent<EventManager>().completed = true;
		}
		questionDone = false;
	}
}