using UnityEngine;
using System.Collections;

public class HideCursor : MonoBehaviour {

	public bool HideOnStart = false;

	// Use this for initialization
	void Start () {
		//Cursor.lockState = CursorLockMode.Locked;	// lock the (hidden) cursor to the center of the game window

		if (HideOnStart){ 
			Hide();
		}
	}
	
	// Hide the cursor on demand
	public void Hide () {
		//Debug.Log ( "Hiding Curor------------");
		Cursor.visible = false;						// hide the standard mouse cursor... we'll use aiming reticule
		Cursor.lockState = CursorLockMode.Locked;	// lock the (hidden) cursor to the center of the game window
	}

	// Show the cursor on demand
	public void Show () {
		Cursor.visible = true;						// show the standard mouse cursor
		Cursor.lockState = CursorLockMode.None;		// unlock the cursor to permit normal mouse movement
	}
}
