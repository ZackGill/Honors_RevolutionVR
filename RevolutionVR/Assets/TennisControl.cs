using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TennisControl : MonoBehaviour {
	public GameObject[] texts;
	public GameObject painting;
	public GameObject soldiers;

	public DecisionHolder decisions;
	int index = 0;
	bool chose = false; // Did player make choice yet?
	// Use this for initialization

	string nextScene;

	void updateTexts(){
		if (index == 2) {
			painting.SetActive (true);
			soldiers.SetActive (true);
		} else {
			painting.SetActive (false);
		}
		if (index >= texts.Length) {
			SceneManager.LoadScene (nextScene);
			return;
		}
		for (int a = 0; a < texts.Length; a++) {
			texts [a].SetActive (false);
		}
		texts [index].SetActive (true);
		if (index == 3 && !chose)
			return;
		index++; 
	}


	void Start () {
		updateTexts ();
		GameObject temp = GameObject.FindGameObjectsWithTag ("Decisions")[0];
		decisions = temp.GetComponent<DecisionHolder> ();
	}

	public void swearOath(){
		nextScene = "Civil_Con";
		index++;
		chose = true;
		updateTexts ();
		decisions.oath = true;
	}

	public void noOath(){
		nextScene = "ParisUpdate";
		index++;
		chose = true;
		updateTexts ();
		decisions.oath = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			updateTexts ();
		}
	}
}
