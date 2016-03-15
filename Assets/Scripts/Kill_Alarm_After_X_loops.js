#pragma strict

var nTimesToPlay : int = 3;
var myAudio : AudioSource;
internal var hasStarted : boolean = false;
internal var isPlaying : boolean = false;
internal var nTimesPlayed : int = 0;

function Start () {
	myAudio = GetComponent.<AudioSource>();
}

function Update () {
    //Debug.Log("Looping" );
	if(nTimesPlayed < nTimesToPlay) {
		if(GetComponent.<AudioSource>().isPlaying && !hasStarted){
			hasStarted = true;  // this triggers if another script starts this audio clip
			// Need to register that the clip has started, so we can count the number of times it plays
			nTimesPlayed++; // take note that it's been played once; increment counter (should've been at zero)
			Debug.Log("Audio Started playing" );
		}
	
		if(!GetComponent.<AudioSource>().isPlaying && hasStarted){
			myAudio.Play(); //If the clip stops playing, restart it.
			nTimesPlayed++; //...and count how many times it's been restarted
			Debug.Log("counting audio loops: " + nTimesPlayed.ToString());
         }
     }
     
     else if(nTimesPlayed == nTimesToPlay){
     	nTimesPlayed = 0;  // once we've exceeded the max counter, reset count to zero
     	hasStarted = false; // and also reset the 'hasStarted' flag to make the audio be triggered elsewhere
     }
}