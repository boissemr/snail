#pragma strict

private var visible : boolean = false;   // keep track of whether object should be on or off
var thingsToShow : GameObject[];
var textToShow : GameObject[];

function Start () {
	visible = false;
	ToggleVisibility();
	
}

function ToggleVisibility(){
	for (var i:int=0; i< thingsToShow.Length; i++){
		//thingsToShow[i].GetComponent(MeshRenderer).enabled = visible;   // visible should start as false, make sure helper object is hidden
		thingsToShow[i].SetActive( visible );  // this toggles a parent node to show the children
	}
	
	for (var ii:int=0; ii< textToShow.Length; ii++){
		textToShow[ii].GetComponent(MeshRenderer).enabled = visible;  // also need to hide text
		// note that we can't disable the text node itself, because it has to be active for events to change text
	} 
}


function Update () {

	// This will toggle on when the button is pressed, then off the next time it's released
	
    if (Input.GetButtonDown("Fire2")){
    	visible = true;    //toggle visibility on
    	 ToggleVisibility();
    }
    
    // This will toggle on when the button is pressed, then off the next time it's pressed
    if (Input.GetButtonUp("Fire2")){
    	visible = false;    //toggle visibility to opposite value - True / False
    	ToggleVisibility();
    }
}