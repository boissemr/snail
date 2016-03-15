#pragma strict

private var visible : boolean = false;   // keep track of whether object should be on or off
var thingsToShow : GameObject[];

function Start () {
	for (var i:int=0; i< thingsToShow.Length; i++){
		thingsToShow[i].SetActive( visible );  // visible should start as false, make sure helper object is hidden
	}
}

function Update () {

	// This will toggle on when the button is pressed, then off the next time it's pressed
    if (Input.GetButtonDown("Fire2")){
    	visible = !visible;    //toggle visibility to opposite value - True / False
    	for (var i:int=0; i< thingsToShow.Length; i++){  // apply new visibility state
			thingsToShow[i].SetActive( visible );  // visible should start as false, make sure helper object is hidden
		}  
    }
}