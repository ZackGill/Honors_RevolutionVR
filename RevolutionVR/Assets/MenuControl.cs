using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour {

	public InfoDump dump;

	public void EnglishClick(){
		dump.language = 1; // 1 for English, else french
		SceneManager.LoadScene("Proto1");
		print ("English Click");
	}

	public void FrenchClick(){
		dump.language = 0; // 1 for English, else french
		SceneManager.LoadScene("Proto1");
		print ("French Click");
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
