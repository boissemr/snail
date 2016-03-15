#pragma strict
var mainCam : Transform;

function Start () {
	if (mainCam == null){
    	mainCam = GameObject.Find("Main Camera").transform;
    }
}

function Update () {
	transform.eulerAngles.y = mainCam.eulerAngles.y;
}