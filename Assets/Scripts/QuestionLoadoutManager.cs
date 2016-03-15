using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QuestionLoadoutManager : MonoBehaviour {

	private Hashtable allEvents = new Hashtable ();

	// These 4 lists are declared to hold every question in the scene, all questions relevant
	// to job1, all questions relevant to job2, and all questions relevant to job3, respectively.
	private List<questiontest> allQuestions;
	private List<questiontest> job1Questions;
	private List<questiontest> job2Questions;
	private List<questiontest> job3Questions;

	// This list holds every question series.
	private List<QuestionSeriesManager> allSeries = new List<QuestionSeriesManager>();
	private bool seriesDone;

	// These booleans store which role has been selected for the simulation.
	public bool job1, job2, job3;

	// Use this for initialization
	void Start () {
		foreach (GameObject gObj in GameObject.FindGameObjectsWithTag ("QuestionSeriesManager")) {
			allSeries.Add(gObj.GetComponent<QuestionSeriesManager>());
			gObj.GetComponent<QuestionSeriesManager>().enabled = (false);
		}

		foreach (QuestionSeriesManager qsm in allSeries) {
			allEvents [qsm.gameObject.GetComponent<orderManager>().order] = qsm;
		}

		// If, in some freak accident, multiple roles are selected simultaneously, there
		// would be horrendous errors. In this case, the reason for hella errors is logged to
		// the console.
		if ((job1 && job2) || (job1 && job3) || (job2 && job3)) {
			Debug.Log ("MULTIPLE JOBS SELECTED, PROGRAM WILL NOT RUN AS INTENDED");
		}

		// All those questiontest lists are instantiated to empy lists.
		allQuestions = new List<questiontest> ();
		job1Questions = new List<questiontest> ();
		job2Questions = new List<questiontest> ();
		job3Questions = new List<questiontest> ();

		// Now we add every individual question to the allQuestions list.
		// QUESTIONS ARE ONLY ADDED IF QUESTIONS HAVE THE TAG "QUESTION" ATTACHED TO THEM.
		foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Question")) {
			allQuestions.Add (obj.gameObject.GetComponent<questiontest> ());
		}

		// The allQuestions list is iterated through, and if the question is set to respond
		// to the "job1" variable, then that question is added to the job1Questions list. The
		// same is true for job2 and job3. Every question, after being added to the allQuestions
		// list, is then deactivated.
		foreach (questiontest ques in allQuestions) {
				if (ques.job1 == true) {
				job1Questions.Add (ques);
				}
				if (ques.job2 == true) {
				job2Questions.Add (ques);
				}
				if (ques.job3 == true) {
				job3Questions.Add (ques);
				}
			ques.gameObject.SetActive(false);

		}

		// If the job1 boolean of this component is true, then all job1Questions are activated.
		// The same is true for job2 and job3. After all appropriate questions have been activated
		// the proper elements within the simulation can be activated. In this test case, the only
		// thing which needs to be activated is an object tagged as "QuestionSeriesManager". This
		// will probably be changed in a later implementation to increment the state manager, or
		// something similar.
		if (job1) {
			Debug.Log ("Job 1 selected.");
			foreach(questiontest ques in job1Questions){
				ques.gameObject.SetActive(true);
			}
		}
		if (job2) {
			Debug.Log ("Job 2 selected.");
			foreach(questiontest ques in job2Questions){
				ques.gameObject.SetActive(true);
			}
		} 
		if (job3) {
			Debug.Log ("Job 3 selected.");
			foreach(questiontest ques in job3Questions){
				ques.gameObject.SetActive(true);
			}
		}
		foreach(QuestionSeriesManager qsm in allSeries){
			qsm.enabled = false;
		}
		allSeries [0].enabled = true;
		allSeries [0].questions [0].gameObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		foreach(QuestionSeriesManager que in allSeries){
			// If the questionSeries is active and completed, then the "step" coroutine is 
			// started.
			if(que.gameObject.activeSelf == true && !seriesDone){
				if(que.seriesCompleted){
					StartCoroutine(step (que));
				}
			}
		}
	}

	IEnumerator step(QuestionSeriesManager cur){
		seriesDone = true;
		yield return new WaitForSeconds(1.5f);	
		cur.gameObject.SetActive(false);
		// If there is another questionseries  in the questionseries list, then the next 
		// questionseries's first question is activated.
		if (allSeries.IndexOf (cur) + 1 < allSeries.Count) {
			allSeries [allSeries.IndexOf (cur) + 1].gameObject.SetActive (true);
			allSeries [allSeries.IndexOf (cur) + 1].enabled = (true);
			allSeries [allSeries.IndexOf (cur) + 1].questions[0].gameObject.SetActive(true);
		} else {
			Debug.Log ("All questions finished!");
		}
		seriesDone = false;
	}

}