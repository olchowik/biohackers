using UnityEngine;
using System.Collections;

public class SpikeBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D bacteria) {
		if (bacteria.gameObject.name == "player") {
			GameControl.control.health -= 10;
		}
	}
}
