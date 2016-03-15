#pragma strict

function Start () {

}

function Update () {
	// Quits the player when the user hits escape
	if (Input.GetKeyDown ("escape")) {
		//UnityEditor.EditorApplication.isPlaying = false;  	// quit play mode in editor
		Application.Quit();									// quit built application
	}
}