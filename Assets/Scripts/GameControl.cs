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

	public Rigidbody2D prefab_glucose;
	
	public List<List<float>> chamber1 = new List<List<float>> ();
	public List<List<float>> chamber2 = new List<List<float>> ();
	public List<List<float>> chamber3 = new List<List<float>> ();

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
			GameObject[] glucoses = GameObject.FindGameObjectsWithTag("Glucose");
			foreach (GameObject glc in glucoses) {
				Destroy(glc);
			}
			foreach(List<float> coords in control.chamber1) {
				Instantiate(prefab_glucose, new Vector2(coords[0], coords[1]), Quaternion.identity);
			}
		}
		else if (Application.loadedLevelName.Contains ("ch2") && control.chamber2.Count != 0) {
			GameObject[] glucoses = GameObject.FindGameObjectsWithTag("Glucose");
			foreach (GameObject glc in glucoses) {
				Destroy(glc);
			}
			foreach(List<float> coords in control.chamber2) {
				Instantiate(prefab_glucose, new Vector2(coords[0], coords[1]), Quaternion.identity);
			}
		}
		else if (Application.loadedLevelName.Contains ("ch3") && control.chamber3.Count != 0) {
			GameObject[] glucoses = GameObject.FindGameObjectsWithTag("Glucose");
			foreach (GameObject glc in glucoses) {
				Destroy(glc);
			}
			foreach(List<float> coords in control.chamber3) {
				Instantiate(prefab_glucose, new Vector2(coords[0], coords[1]), Quaternion.identity);
			}
		}
	}

	void Start() {

	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnGUI() {
		GUI.Label (new Rect (10, 10, 100, 30), "Health: " + health);
		GUI.Label (new Rect (10, 25, 100, 30), "Glucose: " + glucose);
		GUI.Label (new Rect (10, 40, 100, 30), Application.loadedLevelName);
	}
}
