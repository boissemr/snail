//When the player steps into a collision box the will be prompted to press "E"
//	the drawer will open and a GUI of objects in the drawer will appear 

using UnityEngine;
using System.Collections;

public class OpenDrawer : MonoBehaviour {
	public GameObject floatText;
	public GameObject SelectGUI; //placeheld with text currently
	public GameObject drawer;
	public bool open; //is the droor open
	public bool move; //allows the drawer to move
	public bool showGUI; //shows or hides the GUI
	private Vector3 closedLoc;
	private Vector3 openLoc;

	// Use this for initialization
	void Start () {
		floatText.SetActive(false);
		open=false;
		move=false;
		showGUI=false;
		closedLoc= new Vector3(drawer.transform.position.x,drawer.transform.position.y,drawer.transform.position.z);
		openLoc= new Vector3(drawer.transform.position.x,drawer.transform.position.y,drawer.transform.position.z+.25f);
	}
	
	// Update is called once per frame
	void Update () {
		if(move){
			//print ("Moving");
			if(!open){ //drawer was closed
				drawer.transform.position=Vector3.Lerp(closedLoc,openLoc,Time.time);
				if(drawer.transform.position==openLoc){
					open=!open;
					move=false;
					showGUI=true;
					SelectGUI.SetActive(true);
					//print("Drawer is open");
				}
			}
			else{
				drawer.transform.position=Vector3.Lerp(openLoc,closedLoc,Time.time);
				if(drawer.transform.position==closedLoc){
					open=!open;
					move=false;
					SelectGUI.SetActive(false);
					//floatText.SetActive(true);
					//print ("drawer is closed");
				}
			}
		}

	}

	void OnTriggerEnter(){
		floatText.SetActive(true);
	}
	void OnTriggerStay(){
		if(Input.GetKeyUp(KeyCode.E)){
			print ("player interacted with drawer");
			move=true;
			if(!open){
				floatText.SetActive(false);
			}
			else{
				floatText.SetActive(true);
			}
		}
	}
	void OnTriggerExit(){
		if(open){
			move=true;
			showGUI=false;
		}
		floatText.SetActive(false);
	}
}
