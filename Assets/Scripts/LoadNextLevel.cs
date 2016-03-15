using UnityEngine;
using System.Collections;

public class LoadNextLevel : MonoBehaviour {


	public string LevelName;
	public GameObject activate;
	public GameObject deactivate;
	public GameObject agreeButton;
	public GameObject loadButton;
	public GameObject startButton;
	public GameObject startScreen;
	public GameObject fadeScreen;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void Load(){
		//Debug.Log ( "Loading the next level" );
		Application.LoadLevel(LevelName);
	}
	
	public void Agree(){
		activate.SetActive(true);
		deactivate.SetActive(false);
		loadButton.SetActive(true);
		agreeButton.SetActive(false);
	}

	public void StartScene(){
		startButton.SetActive(false);
		startScreen.SetActive(false);
		fadeScreen.SetActive(true);
	}
}