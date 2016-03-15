using UnityEngine;
using System.Collections;

public class lightFlicker : MonoBehaviour {

	public float minIntensity = 2f;
	public float maxIntensity = 3f;

	public float minRange = 10f;
	public float maxRange = 12;

	public float randomIntensity, randomRange;
	private float intensityStep, rangeStep;
	private bool intensityWasGreater, rangeWasGreater = false;

	public float stepFrames = 5;

	private Light thisLight;

	// Use this for initialization
	void Start () {
	
		randomIntensity = Random.Range (minIntensity, maxIntensity);
		randomRange = Random.Range (minRange, maxRange);

		thisLight = this.gameObject.GetComponent<Light> ();
		rangeStep = (randomRange - thisLight.range)/stepFrames;
		intensityStep = (randomIntensity - thisLight.intensity)/stepFrames;

		if (thisLight.intensity > randomIntensity) {
			intensityWasGreater = true;
		}

		if (thisLight.range > randomRange) {
			rangeWasGreater = true;
		}

	}
	
	// Update is called once per frame
	void Update () {

		if ((thisLight.intensity < randomIntensity && intensityWasGreater) || (thisLight.intensity > randomIntensity && !intensityWasGreater)) {
			randomIntensity = Random.Range (minIntensity, maxIntensity);
			intensityStep = (randomIntensity - thisLight.intensity)/stepFrames;
			if (thisLight.intensity > randomIntensity) {
				intensityWasGreater = true;
			}else{
				intensityWasGreater = false;
			}
		}
		if ((thisLight.range < randomRange && rangeWasGreater) || (thisLight.range > randomRange && !rangeWasGreater)) {
			randomRange = Random.Range (minRange, maxRange);
			rangeStep = (randomRange - thisLight.range)/stepFrames;
			if (thisLight.range > randomRange) {
				rangeWasGreater = true;
			}else{
				rangeWasGreater = false;
			}
		}

		thisLight.intensity += intensityStep;
		thisLight.range += rangeStep;


	}
}
