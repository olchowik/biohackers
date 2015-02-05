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
			GameObject[] glucoses    = GameObject.FindGameObjectsWithTag("Glucose");
			GameObject[] phages      = GameObject.FindGameObjectsWithTag("Phage");
			GameObject[] antibiotics = GameObject.FindGameObjectsWithTag("Antibiotic");
			GameObject[] dnas        = GameObject.FindGameObjectsWithTag("DNA");
			if(Application.loadedLevelName.Contains("ch1")) {
				GameControl.control.chamber1.Clear();
				GameControl.control.chamber1.Add("glucose", new List<List<float>>());
				GameControl.control.chamber1.Add("phage", new List<List<float>>());
				GameControl.control.chamber1.Add("antibiotic", new List<List<float>>());
				GameControl.control.chamber1.Add("dna", new List<List<float>>());
				foreach (GameObject glc in glucoses) { GameControl.control.chamber1["glucose"].Add(new List<float>{glc.gameObject.rigidbody2D.position.x, glc.gameObject.rigidbody2D.position.y}); }
				foreach (GameObject phg in phages) { GameControl.control.chamber1["phage"].Add(new List<float>{phg.gameObject.transform.position.x, phg.gameObject.transform.position.y, phg.GetComponent<PhageBehaviour>().type, phg.GetComponent<PhageBehaviour>().change_type});}
				foreach (GameObject ant in antibiotics) { GameControl.control.chamber1["antibiotic"].Add(new List<float>{ant.gameObject.transform.position.x, ant.gameObject.transform.position.y, ant.GetComponent<PhageBehaviour>().type});}
				foreach (GameObject dna in dnas) { GameControl.control.chamber1["dna"].Add(new List<float>{dna.gameObject.transform.position.x, dna.gameObject.transform.position.y, dna.GetComponent<PhageBehaviour>().type});}
			}

			if(Application.loadedLevelName.Contains("ch2")) {
				GameControl.control.chamber2.Clear();
				GameControl.control.chamber2.Add("glucose", new List<List<float>>());
				GameControl.control.chamber2.Add("phage", new List<List<float>>());
				GameControl.control.chamber2.Add("antibiotic", new List<List<float>>());
				GameControl.control.chamber2.Add("dna", new List<List<float>>());
				foreach (GameObject glc in glucoses) { GameControl.control.chamber2["glucose"].Add(new List<float>{glc.gameObject.rigidbody2D.position.x, glc.gameObject.rigidbody2D.position.y}); }
				foreach (GameObject phg in phages) { GameControl.control.chamber2["phage"].Add(new List<float>{phg.gameObject.transform.position.x, phg.gameObject.transform.position.y, phg.GetComponent<PhageBehaviour>().type, phg.GetComponent<PhageBehaviour>().change_type});}
				foreach (GameObject ant in antibiotics) { GameControl.control.chamber2["antibiotic"].Add(new List<float>{ant.gameObject.transform.position.x, ant.gameObject.transform.position.y, ant.GetComponent<PhageBehaviour>().type});}
				foreach (GameObject dna in dnas) { GameControl.control.chamber2["dna"].Add(new List<float>{dna.gameObject.transform.position.x, dna.gameObject.transform.position.y, dna.GetComponent<PhageBehaviour>().type});}
			}

			if(Application.loadedLevelName.Contains("ch3")) {
				GameControl.control.chamber3.Clear();
				GameControl.control.chamber3.Add("glucose", new List<List<float>>());
				GameControl.control.chamber3.Add("phage", new List<List<float>>());
				GameControl.control.chamber3.Add("antibiotic", new List<List<float>>());
				GameControl.control.chamber3.Add("dna", new List<List<float>>());
				foreach (GameObject glc in glucoses) { GameControl.control.chamber3["glucose"].Add(new List<float>{glc.gameObject.rigidbody2D.position.x, glc.gameObject.rigidbody2D.position.y}); }
				foreach (GameObject phg in phages) { GameControl.control.chamber3["phage"].Add(new List<float>{phg.gameObject.transform.position.x, phg.gameObject.transform.position.y, phg.GetComponent<PhageBehaviour>().type, phg.GetComponent<PhageBehaviour>().change_type});}
				foreach (GameObject ant in antibiotics) { GameControl.control.chamber3["antibiotic"].Add(new List<float>{ant.gameObject.transform.position.x, ant.gameObject.transform.position.y, ant.GetComponent<PhageBehaviour>().type});}
				foreach (GameObject dna in dnas) { GameControl.control.chamber3["dna"].Add(new List<float>{dna.gameObject.transform.position.x, dna.gameObject.transform.position.y, dna.GetComponent<PhageBehaviour>().type});}
			}

			Application.LoadLevel (level);
		}
	}

}
