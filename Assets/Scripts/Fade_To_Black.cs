using UnityEngine;
using System.Collections;

public class Fade_To_Black : MonoBehaviour
{
	public float fadeSpeed = 1.5f;          // Speed that the screen fades to and from black.
	
	
	private bool sceneStarting = true;      // Whether or not the scene is still fading in.

	private int fading = 0;					// 0 = not fading; +1 = fade in;  -1 = fade out
	public float alphaLevel;				// need to store current alpha level and tweak it
	
	
	void Awake () {
		// Set the texture so that it is the the size of the screen and covers it.
		//guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
	}
	
	
	void Update () {
		// show alpha level in inspector
		alphaLevel = GetComponent<Renderer> ().material.color.a;


		// If the scene is starting...
		if(sceneStarting)
			// ... call the StartScene function.
			StartScene();

		if (fading != 0) {
			// make sure renderer is active if fading
			GetComponent<Renderer>().enabled = true;  
			//Debug.Log (fading.ToString() + " * " + Time.deltaTime.ToString() + " * " + fadeSpeed.ToString () + " * " + (fading * (Time.deltaTime / fadeSpeed)).ToString());
			//Debug.Log (GetComponent<Renderer>().material.color.a >= .95);
			//Debug.Log (GetComponent<Renderer>().material.color.a <= .05);
			// get current alpha level
			//alphaLevel = GetComponent<Renderer>().material.color.a;

			// implement fading here by adding (or subtracting) from current alpha value
			GetComponent<Renderer>().material.color += new Color(0,0,0, fading * (Time.deltaTime / fadeSpeed));

			// finish off fade-in (should be completely black)
			if (GetComponent<Renderer>().material.color.a >= .9999){ 
				//Debug.Log ( "Finished Fading to black");
				GetComponent<Renderer>().material.color = Color.black; 	// max alpha of 1
				fading = 0;											// stop fading
			}

			// finish off fade-out (should be completely clear)
			if (GetComponent<Renderer>().material.color.a <= .0001){ 
				//Debug.Log ( "Finished Fading to clear");
				GetComponent<Renderer>().material.color = Color.clear; 	// min alpha of 0
				fading = 0;											// stop fading
				GetComponent<Renderer>().enabled = false;			// disable mesh renderer to boost performance
					//  NOTE:  if this is left enabled, there will be an extra transparency draw on every pixel in the scene
			}
		}
	}
	

	//float myLerp(float current, float goal, float speed){

	//}

	void FadeToClear ()	{
		// Lerp the colour of the texture between itself and transparent.
		//GetComponent<Renderer>().material.color = Color.Lerp(GetComponent<Renderer>().material.color, Color.clear, fadeSpeed * Time.deltaTime);
		fading = -1;
	}
	
	
	void FadeToBlack ()	{
		// Lerp the colour of the texture between itself and black.
		//GetComponent<Renderer>().material.color = Color.Lerp(GetComponent<Renderer>().material.color, Color.black, fadeSpeed * Time.deltaTime);
		fading = 1;
	}
	
	
	public void StartScene ()	{
		// Fade the texture to clear.
		FadeToClear();
		// The scene is no longer starting... we only want to start the fade once
		sceneStarting = false;
	}
	
	
	public void EndScene (){   // THIS IS CALLED EXTERNALLY
		// Start fading towards black.
		FadeToBlack();
	}
}