using UnityEngine;
using System.Collections;

public class AnimationControl : MonoBehaviour {
	
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	void OnTriggerEnter2D(Collider2D bacteria) {
		if (bacteria.gameObject.name == "player") {
			anim.SetBool ("start_anim", true);

		}
	}

}
