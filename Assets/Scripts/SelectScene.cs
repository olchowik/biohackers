using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelectScene : MonoBehaviour {

	public List<string> level = new List<string>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ButtonSelect(int lvl) {
		Application.LoadLevel (level[lvl]);
	}
}
