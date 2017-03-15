using UnityEngine;
using System.Collections;

public class ExecutionControl : MonoBehaviour {

	public Rigidbody blade;


	void go(){
		blade.isKinematic = false;
	}


	// Use this for initialization
	void Start () {
		Invoke ("go", 5f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
