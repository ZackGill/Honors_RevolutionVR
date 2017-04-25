using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour {

	public InfoDump dump;

	public void EnglishClick(){
		dump.language = 1; // 1 for English, else french
		SceneManager.LoadScene("TennisCourtOath");
	}
		
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
