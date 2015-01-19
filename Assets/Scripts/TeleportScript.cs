using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TeleportScript : MonoBehaviour {

	public string level = "";
	public string main_chamber = "";
	public float delta_y = 0f;
	public float delta_x = 0f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D bacteria) {
		if(bacteria.gameObject.name == "player"){
			if (Application.loadedLevelName == main_chamber) {
				// saving position of the player
				GameControl.control.last_x = bacteria.gameObject.rigidbody2D.position.x - delta_x;
				GameControl.control.last_y = bacteria.gameObject.rigidbody2D.position.y - delta_y;
				GameControl.control.flag   = "return";
				GameControl.control.base_level = main_chamber;
			}

			// saving position of game objects depending on current level
			GameObject[] glucoses = GameObject.FindGameObjectsWithTag("Glucose");
			if(Application.loadedLevelName.Contains("ch1")) {
				GameControl.control.chamber1.Clear();
				foreach (GameObject glc in glucoses) { GameControl.control.chamber1.Add(new List<float>{glc.gameObject.rigidbody2D.position.x, glc.gameObject.rigidbody2D.position.y}); }}
			if(Application.loadedLevelName.Contains("ch2")) {
				GameControl.control.chamber2.Clear();
				foreach (GameObject glc in glucoses) { GameControl.control.chamber2.Add(new List<float>{glc.gameObject.rigidbody2D.position.x, glc.gameObject.rigidbody2D.position.y}); }}
			if(Application.loadedLevelName.Contains("ch3")) {
				GameControl.control.chamber3.Clear();
				foreach (GameObject glc in glucoses) { GameControl.control.chamber3.Add(new List<float>{glc.gameObject.rigidbody2D.position.x, glc.gameObject.rigidbody2D.position.y}); }}

			Application.LoadLevel (level);
		}
	}

}
