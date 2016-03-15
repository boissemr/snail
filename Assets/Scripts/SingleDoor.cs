using UnityEngine;
using System.Collections;

public class SingleDoor : MonoBehaviour { //door that is openned with "E", closes automatically

	public GameObject guiText;
	public GameObject door;
	public int openAngle; // angle the door opens to 
	public bool open; //door told to open
	public bool close; //door told to close
	public int frameCounter;

	// Use this for initialization
	void Start () {
		guiText.SetActive(false);
		open=false;
		close=false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(open)//door to be opened
		{
			if(frameCounter<openAngle)
			{
				door.transform.Rotate(0,-3,0);
				frameCounter+=3;
			}
			else //door is open
			{
				open=false;
			}
		}
		if(close)
		{
			if(frameCounter>0)
			{
				door.transform.Rotate(0,3,0);
				frameCounter-=3;
			}
			else //door is closed
			{
				close=false;
			}
		}
	}
	void OnTriggerEnter(Collider other){
		if(other.CompareTag("Player"))
		{
			guiText.SetActive(true);
		}
		if(other.CompareTag("NPC"))
		{
			open=true;
		}
	}
	void OnTriggerStay(){
		if(Input.GetKeyUp(KeyCode.E))
		{
			guiText.SetActive(false);
			open=true;
		}
	}
	void OnTriggerExit(Collider other){
		close=true;
		guiText.SetActive(false);
	}
}
