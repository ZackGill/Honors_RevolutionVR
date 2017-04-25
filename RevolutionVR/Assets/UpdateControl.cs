using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UpdateControl : MonoBehaviour {

	public GameObject[] texts;
	public DecisionHolder decisions;

	int index = 0;

	string nextScene;

	void updateTexts(){
		if (index >= texts.Length) {
			SceneManager.LoadScene (nextScene);
			return;
		}
		for (int a = 0; a < texts.Length; a++) {
			texts [a].SetActive (false);
		}
		texts [index].SetActive (true);
		index++; 
	}


	void Start () {
		updateTexts ();
		GameObject temp = GameObject.FindGameObjectsWithTag ("Decisions")[0];
		decisions = temp.GetComponent<DecisionHolder> ();
		determineScene ();

	}


	void determineScene(){
		// Weighted formula for it. Positive means executed. 
		// Vote to not kill King: + 2
		// Vote to kill, but delayed: +1
		// Not take the Tennis Court Oath: +2
		// Take the Oath: -1
		// Royalist Sympathy: + 2
		// Feuillant : 0
		// Jacobin: - 1
		// Greater than 0 means death, otherwise, survive and see another die.
		// Maybe Bailly Dies and you are conflicted. Oh well, a price you pay.
		// This means it is possible to escape, if you were a Jacobin of some sort.

		int grade = 0;
		if (decisions.King_Vote == "N")
			grade += 2;
		if (decisions.King_Vote == "DD")
			grade++;
		if (decisions.Club == "J")
			grade--;
		else if (decisions.Club == "C")
			grade+=2;
		if (decisions.oath)
			grade--;
		else
			grade += 2;


		if (grade > 0)
			nextScene = "Execute_viewer";
		else
			nextScene = "Execute_Watch";

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			updateTexts ();
		}
	}
}
