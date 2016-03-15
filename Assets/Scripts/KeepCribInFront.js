#pragma strict

var mainCam : Transform;

function Start () {

}

function Update () {
	
	transform.rotation.y = mainCam.rotation.y;
}