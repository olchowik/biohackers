using UnityEngine;
using System.Collections;

public class SpikeMove : MonoBehaviour {

	public float AngleMax = 0f;
	public float AngleMin = 0f;
	public int motorStr = 10;
	HingeJoint2D hinge;
	JointMotor2D motor;

	// Use this for initialization
	void Start () {
		hinge = gameObject.GetComponent<HingeJoint2D>(); 
		motor = hinge.motor;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (hinge.jointAngle);
		if (hinge.jointAngle >= AngleMax && hinge.useMotor == true) {
			motor.motorSpeed = -motorStr;
			hinge.motor = motor;
			}

		if (hinge.jointAngle <= AngleMin && hinge.useMotor == true) {
			motor.motorSpeed = motorStr;
			hinge.motor = motor;
		}
	}
}
