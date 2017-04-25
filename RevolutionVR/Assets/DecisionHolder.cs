using UnityEngine;
using System.Collections;

public class DecisionHolder : MonoBehaviour {
	public string Club;
	public bool oath;
	public string King_Vote;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
