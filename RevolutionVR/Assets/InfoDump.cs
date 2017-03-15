using UnityEngine;
using System.Collections;

public class InfoDump : MonoBehaviour {
	public byte language;

	// Decisions go here for maping the game out. I.e., sided with nobles? Peasants?


	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (transform.gameObject);
	}


	void Awake(){
		DontDestroyOnLoad (transform.gameObject);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
