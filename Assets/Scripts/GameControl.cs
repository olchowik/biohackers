using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameControl : MonoBehaviour {

	public static GameControl control;
	public float last_x      = 0f;
	public float last_y      = 0f;
	public string flag       = "";
	public string base_level = "";
	public int health        = 100;
	public int glucose       = 0;
	// 3 states: ON: begin eating, OFF: not eating, EATING: eating in progress, don't start more
	public string eat_glc    = "OFF"; 

	public Rigidbody2D prefab_glucose;
	public GameObject prefab_phage;
	public GameObject[] prefabs_antibiotics;
	public GameObject prefab_DNA;

	public Dictionary<string, List<List<float>>> chamber1 = new Dictionary<string, List<List<float>>>();
	public Dictionary<string, List<List<float>>> chamber2 = new Dictionary<string, List<List<float>>>();
	public Dictionary<string, List<List<float>>> chamber3 = new Dictionary<string, List<List<float>>>();

	// Use this for initialization
	void Awake () {
		if (control == null) {
			DontDestroyOnLoad (gameObject);
			control = this;
		}
		else if (control != this) {
			Destroy(gameObject);
		}

		// initialize previous position of game elements
		if (Application.loadedLevelName.Contains ("ch1") && control.chamber1.Count != 0) {
			GameObject[] glucoses    = GameObject.FindGameObjectsWithTag("Glucose");
			GameObject[] phages      = GameObject.FindGameObjectsWithTag("Phage");
			GameObject[] antibiotics = GameObject.FindGameObjectsWithTag("Antibiotic");
			GameObject[] dnas        = GameObject.FindGameObjectsWithTag("DNA");
			// destroy all objects
			foreach (GameObject glc in glucoses) {Destroy(glc);}
			foreach (GameObject phg in phages) {Destroy(phg);}
			foreach (GameObject ant in antibiotics) {Destroy(ant);}
			foreach (GameObject dna in dnas) {Destroy(dna);}
			// rebuild scene from saved positions of objects
			// glucose
			foreach(List<float> coords in control.chamber1["glucose"]) {
				Instantiate(prefab_glucose, new Vector2(coords[0], coords[1]), Quaternion.identity);
			}
			// phages
			foreach(List<float> coords in control.chamber1["phage"]) {
				GameObject phg = Instantiate(prefab_phage, new Vector2(coords[0], coords[1]), Quaternion.identity) as GameObject;
				phg.GetComponent<PhageBehaviour>().type = coords[2];
				phg.GetComponent<PhageBehaviour>().change_type = coords[3];
				Debug.Log("sprite created");
				phg.GetComponentInChildren<PhageRange>().SetSprite();
			}
			// antibiotics
			foreach(List<float> coords in control.chamber1["antibiotic"]) {
				Instantiate(prefabs_antibiotics[(int)coords[2]], new Vector2(coords[0], coords[1]), Quaternion.identity);
			}
			// DNAs
			foreach(List<float> coords in control.chamber1["dna"]) {
				GameObject dna = Instantiate(prefab_DNA, new Vector2(coords[0], coords[1]), Quaternion.identity) as GameObject;
				dna.GetComponent<PhageBehaviour>().type = coords[2];
			}
		// next chamber
		}
		else if (Application.loadedLevelName.Contains ("ch2") && control.chamber2.Count != 0) {
			GameObject[] glucoses = GameObject.FindGameObjectsWithTag("Glucose");
			foreach (GameObject glc in glucoses) {
				Destroy(glc);
			}
			foreach(List<float> coords in control.chamber2["glucose"]) {
				Instantiate(prefab_glucose, new Vector2(coords[0], coords[1]), Quaternion.identity);
			}
		}
		else if (Application.loadedLevelName.Contains ("ch3") && control.chamber3.Count != 0) {
			GameObject[] glucoses = GameObject.FindGameObjectsWithTag("Glucose");
			foreach (GameObject glc in glucoses) {
				Destroy(glc);
			}
			foreach(List<float> coords in control.chamber3["glucose"]) {
				Instantiate(prefab_glucose, new Vector2(coords[0], coords[1]), Quaternion.identity);
			}
		}
	}

	void Start() {

	}
	
	// Update is called once per frame
	void Update () {
		if (eat_glc == "ON") {
			InvokeRepeating("EatGlucose", 1, 1);
			GameControl.control.eat_glc = "EATING";
		}
		if (eat_glc == "OFF") {
			CancelInvoke("EatGlucose");
		}
	}

	void EatGlucose() {
		GameControl.control.glucose -= 1;
		}

	public void ButtonSelect() {
		if (eat_glc == "OFF") { GameControl.control.eat_glc = "ON"; }
		if (eat_glc == "EATING") { GameControl.control.eat_glc = "OFF"; }
	}

	//testing UI
	void OnGUI() {
		GUI.Label (new Rect (400, 10, 100, 30), "Health: " + health);
		GUI.Label (new Rect (400, 25, 100, 30), "Glucose: " + glucose);
		GUI.Label (new Rect (400, 40, 100, 30), Application.loadedLevelName);
	}

}
