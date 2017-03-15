using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Proto2Control : MonoBehaviour {


	public void Jacobin(){
		print ("Jacobin");
		SceneManager.LoadScene ("Execute_Watch");
	}

	public void Girondin(){
		print ("Girondin");
		SceneManager.LoadScene ("Execute_viewer");
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
