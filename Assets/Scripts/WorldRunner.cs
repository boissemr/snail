//Author: Brian Neibecker
//Jan. 15, 2015
//WorldRunner:  handles the flow of the simulation using message listeners to check if tasks 
//	have been completed then sets the next tasks and gives prompts to the user

using UnityEngine;
using System.Collections;

public class WorldRunner : MonoBehaviour {

	public GameObject audioCodeRed;
	public GameObject MT; //MT character
	public GameObject CN; //CN character
	public GameObject CN2; //CN-Speech_2
	public GameObject CN3; //CN-Speech_3
	public GameObject CN4; //CN-Speech_4
	public GameObject Aud2; //Jpod audio
	public GameObject Aud3;
	public GameObject Aud4;
	public GameObject CN6; //CN-Speech_6
	public GameObject CN7;
	

	//message listeners

	void PlayerAtStart(){
		print ("Code red audio on");
		audioCodeRed.SetActive(true);
		MT.SendMessage("nextPosition");
	}

	void None(){
		print ("nothing important to do here...");
	}

	void PlayerAtPos3(){
		print ("code red audio off... man that was annoying");
		audioCodeRed.SetActive(false);
	}

	void Q1Complete(){
		CN2.SetActive(true);
	}

	void Q2Complete(){
		CN3.SetActive(true);
	}

	void Q3Complete(){
		CN4.SetActive(true);
	}

	void Q4Complete(){
		Aud2.SetActive(true);
	}

	void Q5Complete(){
		Aud3.SetActive(true);
	}

	void MovedItems(){
		Aud4.SetActive(true);
	}

	void FinalCheck(){
		CN6.SetActive(true);
	}

	void BandCheck(){
		CN7.SetActive(true);
	}
}
