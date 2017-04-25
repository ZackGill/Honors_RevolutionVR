using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CivilControl : MonoBehaviour {
	public GameObject[] texts;
	public GameObject painting;
	public DecisionHolder decisions;

	int index = 0;
	bool chose = false; // Did player make choice yet?

	string nextScene;

	void updateTexts(){
		if (index == 2) {
			painting.SetActive (true);
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

	public void jacobin(){
		nextScene = "KingVote";
		index++;
		chose = true;
		updateTexts ();
		decisions.Club = "J";
	}

	public void feuillant(){
		nextScene = "KingVote";
		index++;
		chose = true;
		updateTexts ();
		decisions.Club = "F";
	}

	public void clergy(){
		// Since you wouldn't probably be reelected or even particpate in the
		// Convention, if you were this royalist, I'm doing Paris Update
		// And eventual execution
		nextScene = "ParisUpdate";
		index++;
		chose = true;
		updateTexts ();
		decisions.Club = "C";
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			updateTexts ();
		}
	}
}