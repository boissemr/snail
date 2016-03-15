#pragma strict

internal var hit : RaycastHit;
var raycastFrom : Transform;
internal var curDist;
var minDist : float = .2;
var maxDist : float = 3.0;
var masked : LayerMask;


function Start () {

}

function Update () {
    // Bit shift the index of the layer (8) to get a bit mask
  	var layerMask = 1 << 8;
  	// This would cast rays only against colliders in layer 8.
  	// But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
  	layerMask = ~layerMask;
  	
    var fwd = raycastFrom.transform.TransformDirection (Vector3.forward);
	if (Physics.Raycast (raycastFrom.transform.position, fwd, hit, maxDist, masked)) {
			//Debug.Log( hit.distance.ToString() );
			transform.localPosition.z = hit.distance; // max should be capped by raycast distance 
		}

}