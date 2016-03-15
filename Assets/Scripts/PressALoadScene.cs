using UnityEngine;
using System.Collections;

public class PressALoadScene : MonoBehaviour {

	public string LevelName;
	private bool locked;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonUp("A_Button")&&!locked){
			Application.LoadLevel(LevelName);
		}
		StartCoroutine(Waiting());
	}

	public IEnumerator Waiting(){
		yield return new WaitForSeconds(2);
		locked=false;
	}
}
