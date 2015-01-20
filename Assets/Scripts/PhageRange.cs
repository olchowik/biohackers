using UnityEngine;
using System.Collections;

public class PhageRange : MonoBehaviour {

	public Sprite[] phages;

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter2D(Collider2D bacteria) {
		if(bacteria.gameObject.name == "player"){
			transform.parent.GetComponent<SpriteRenderer> ().sprite = phages [0];
		}
	}
}
