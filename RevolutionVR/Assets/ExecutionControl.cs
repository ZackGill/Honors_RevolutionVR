using UnityEngine;
using System.Collections;

public class ExecutionControl : MonoBehaviour {
	public GameObject[] texts;
	public Rigidbody blade;
	public Rigidbody head;
	public GameObject body;
	bool execute = false;
	int index = 0;

	void updateTexts(){
		if (index == 1) {
			Invoke ("go", 5f);
		} else {
			head.isKinematic = true;
			body.SetActive (false);
		}
		if (index >= texts.Length) {
			Application.Quit ();
			return;
		}
		for (int a = 0; a < texts.Length; a++) {
			texts [a].SetActive (false);
		}
		texts [index].SetActive (true);
		if (index == 1 && !execute)
			return;
		index++; 
	}

	void go(){
		blade.isKinematic = false;
		execute = true;
		index++;
	}


	// Use this for initialization
	void Start () {
		updateTexts ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			updateTexts ();
		}
	}
}
