using UnityEngine;
using System.Collections;

public class RandomizeCompletionCode : MonoBehaviour {
	public string myCode;
	public GameObject DataStor;
	public string[] seedWords;
	public int nNumbers = 3;
	private bool hasRunOnce = false;
		
	// Use this for initialization
	void Start () {
		int randIndex = Random.Range(0, seedWords.Length + 1);
		string whichWord = seedWords[randIndex];
		for (int i=0; i < nNumbers; i++){
			whichWord = whichWord + Random.Range(0, 10).ToString();
		}

		//shuffle in place
		myCode =RandomizeString(whichWord);

		GetComponent<TextMesh>().text = myCode;
		DataStor.GetComponent<DataStorage>().completionCode = myCode; //.ToString ();
		hasRunOnce = true;
	}
	


	void Update () {
		// make sure that 
		if (!hasRunOnce){
			Start();
		}
		//if (Input.GetKeyDown(KeyCode.Space)){
		//	Awake();
		//}
	}

	public static void ShuffleArray<T>(T[] arr) {
		// implementation of clasic Fisher Yates shuffle, via Unity forums
		for (int i = arr.Length - 1; i > 0; i--) {
			int r = Random.Range(0, i + 1);
			T tmp = arr[i];
			arr[i] = arr[r];
			arr[r] = tmp;
		}
	}

	public static string RandomizeString(string inputText) {
		// samples one string and outputs a randomized version
		int textLen = inputText.Length;
		int[] indexes = new int[textLen];
		string outText = "";
		for (int i=0; i< textLen; i++){
			indexes[i] = i;
		}

		ShuffleArray(indexes);  // randomize here
		for (int t=0; t< textLen; t++){
			outText = outText + inputText[indexes[t]];
		}
		return outText;
	}
}
