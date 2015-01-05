using UnityEngine;
using System.Collections;

public class TeleportScript : MonoBehaviour {

	public string level = "";

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D bacteria) {
		if(bacteria.gameObject.name == "player"){
			if (Application.loadedLevelName == "chamber1") {
				GameControl.control.last_x = bacteria.gameObject.rigidbody2D.position.x;
				GameControl.control.last_y = bacteria.gameObject.rigidbody2D.position.y - 0.5f;
				GameControl.control.flag   = "return";
			}
			Application.LoadLevel (level);
		}
	}

}
