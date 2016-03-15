using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;
using System;

public class endCardScript : MonoBehaviour {

	private ReportCardManager rcm;
	private StreamReader inpStm;
	private string[] individualLines;
	public GameObject detRes;
	public GameObject iniRes;
	public GameObject DButton, IButton;
	public GameObject creditScreen;

	public GameObject dataStor;


	// Use this for initialization
	void Start () {
		// find timer
		dataStor = GameObject.Find("Utility_Helper");

		rcm = GameObject.Find ("Game Manager").GetComponent<ReportCardManager>();

		inpStm = new StreamReader (rcm.getWrongFileName());
		//inpStm = new StreamReader ("ReportCards/test.txt");

		string fullText = inpStm.ReadToEnd ();
		individualLines = fullText.Split ('#');

		fillInitialResults ();
		fillDetailResults ();
		//detRes = GameObject.Find ("Detail Results");
		//iniRes = GameObject.Find ("Initial Results");
		detRes.SetActive (false);
		//GameObject.Find ("Initial Results").SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
		//if(Input.GetButtonDown ("Fire1")){
			//Toggle();
		//}
	}

	string FormattedTime(float totalSec){
		float min = Mathf.Floor(totalSec /60f);
		float sec = Mathf.Round(totalSec % 60); // totalSec - (min * 60f);
		string outText;
		if (sec < 10f){ 
			// add zero for single-digit sec
			outText = min.ToString() + ":0" + sec.ToString();
		}else{
			outText = min.ToString() + ":" + sec.ToString();
		}
		return outText;
	}

	void fillInitialResults(){
		Text tex = GameObject.Find ("Initial Results").transform.FindChild ("Results Text").GetComponent<Text>();
		string superString = "";

		//superString += "Goal Time: " + individualLines [individualLines.Length - 5].Replace(Environment.NewLine, "");
		superString += "Goal Time: 10 min";
		superString += Environment.NewLine;
		//superString += "Your Time: " + individualLines [individualLines.Length - 4].Replace(Environment.NewLine, "");
		superString += "Your Time: " + FormattedTime( dataStor.GetComponent<DataStorage>().timeToCompletion );
		superString += Environment.NewLine;
		superString += "Max Score: " + individualLines [individualLines.Length - 3].Replace(Environment.NewLine, "");
		superString += Environment.NewLine;
		superString += "Your Score: " + individualLines [individualLines.Length - 2].Replace(Environment.NewLine, "");

		tex.text = superString;
	}

	void fillDetailResults(){
		Text tex = GameObject.Find ("Detail Results").transform.FindChild("Results Scroll Rect").transform.FindChild ("Results Text").GetComponent<Text> ();
		string superString = "";

		for (int i = 0; i < individualLines.Length - 5; i++){
			if(individualLines[i].IndexOf(Environment.NewLine) == individualLines[i].LastIndexOf(Environment.NewLine)){
				Debug.Log ("New Line removed for line " + individualLines[i]);
				superString += individualLines[i].Replace(Environment.NewLine, "");
			}else{
				Debug.Log ("yes hello");
				superString += individualLines[i].Remove(0, 2);
			}
			superString += Environment.NewLine;
		}

		tex.text = superString;
	}

	public void Toggle(){
		if (detRes.activeSelf == false) {
			detRes.SetActive (true);
			iniRes.SetActive (false);

		} else {
			detRes.SetActive (false);
			iniRes.SetActive (true);
		}
	}

	public void Detailed(){
		Debug.Log ("Detailed Report activated from button");
		detRes.SetActive (true);
		iniRes.SetActive (false);
		DButton.SetActive(false);
		IButton.SetActive(true);
	}
	public void Initial(){
		Debug.Log ("Initial Report activated from button");
		detRes.SetActive (false);
		iniRes.SetActive (true);
		DButton.SetActive(true);
		IButton.SetActive(false);
	}

	public void ShowCredits(){
		creditScreen.SetActive(true);
	}
	public void HideCredits(){
		creditScreen.SetActive(false);
	}
}
