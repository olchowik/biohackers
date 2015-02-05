using UnityEngine;
using System.Collections;

public class MoveBlockTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter2D(Collider2D bacteria) {
		if(bacteria.gameObject.name == "player"){
			transform.parent.GetComponent<Rigidbody2D>().isKinematic = false;

		}
	}
}
