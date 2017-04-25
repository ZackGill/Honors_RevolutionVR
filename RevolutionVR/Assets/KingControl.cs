using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class KingControl : MonoBehaviour {
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
			// Transition to next scene
			print(nextScene);
			SceneManager.LoadScene(nextScene);
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

	public void dontExecute(){
		decisions.King_Vote = "N"; //Not death
		determineScene ();
		chose = true;
		index++;
		updateTexts ();
	}

	public void delayExecute(){
		decisions.King_Vote = "DD"; // Delayed Death
		determineScene ();
		chose = true;
		index++;
		updateTexts ();
	}

	public void execute(){
		decisions.King_Vote = "D"; // Immediate Death
		determineScene ();
		chose = true;
		index++;
		updateTexts ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			updateTexts ();
		}
	}

	// Goes through the current votes of player, see if they will be killed or not.
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
}
