using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Proto1Control : MonoBehaviour {


	public void YesClick(){
		print ("Yes");
		SceneManager.LoadScene ("Proto2");
	}

	public void NoClick(){
		print ("No");
		SceneManager.LoadScene ("Execute_viewer");
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
