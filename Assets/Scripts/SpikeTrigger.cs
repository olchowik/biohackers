using UnityEngine;
using System.Collections;

public class SpikeTrigger : MonoBehaviour {

	HingeJoint2D hinge;
	
	// Use this for initialization
	void Start () {
		hinge = gameObject.GetComponent<HingeJoint2D>(); 
		hinge.useMotor = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D bacteria) {
		if (bacteria.gameObject.name == "player") {
			hinge.useMotor = true;
		}
	}

	void OnTriggerExit2D(Collider2D bacteria) {
		if (bacteria.gameObject.name == "player") {
			hinge.useMotor = false;
		}
	}

}
