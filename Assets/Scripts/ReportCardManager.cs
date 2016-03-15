using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class ReportCardManager : MonoBehaviour {

	// Declaration of score variables accessible by external objects. Used for "Scoring" a 
	// given report card.
	public int score;
	public int MaxScore;

	// The filename of the file to write the report card to.
	public string enteredFileName = "REPORTCARD";
	
	private string fileName;
	private string wrongFileName;
	// Use this for initialization
	void Start () {
		// Formats the filename using the entered file name, and formats it so that all 
		// report cards are put in the ReportCards directory, and are formatted to match
		// the format "FileName MM-DD-YYYY HH.MM.SS.txt".
		DateTime today = System.DateTime.Now;
		fileName += "ReportCards/";
		fileName += enteredFileName;
		fileName += " " + today.Month.ToString () + "-" + today.Day.ToString() + "-" + today.Year.ToString() + " " + today.Hour.ToString () + "." + today.Minute.ToString () + "." + today.Second.ToString ();
		wrongFileName = fileName;
		fileName += ".txt";
		Debug.Log (fileName);
		wrongFileName += "details.txt";

		// If the file already exists (In case of a weird error), then the previous file is
		// deleted and overwritten by the new file.
		if(File.Exists(fileName)){
			Debug.Log("File " + '"' + fileName + '"' + " already exists.");
			System.IO.File.Delete(fileName);
		}

		// Timestamps the first line of the file with the current date and time.
		System.IO.File.AppendAllText (fileName, ("TEST OCCURED ON " + DateTime.Now.ToString () + Environment.NewLine));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Public method which can be called by external objects for the purpose of writing
	// to the reportcard. 
	public void writeLine(string str){
		str += Environment.NewLine;
		System.IO.File.AppendAllText(fileName, str);
	}

	public void writeWrongLine(string str){
		str += Environment.NewLine;
		System.IO.File.AppendAllText (wrongFileName, str);
	}

	public string getFileName(){
		return fileName.ToString ();
	}

	public string getWrongFileName(){
		return wrongFileName.ToString ();
	}
}
