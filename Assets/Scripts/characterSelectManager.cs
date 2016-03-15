using UnityEngine;
using System.Collections;

public class characterSelectManager : MonoBehaviour {
	public bool job1, job2, job3;

	void Awake(){
		DontDestroyOnLoad (this);
	}
}
