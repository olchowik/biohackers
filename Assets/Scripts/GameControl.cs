using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {

	public static GameControl control;
	public float last_x = 0f;
	public float last_y = 0f;
	public string flag  = "";
	public int health   = 100;
	public int glucose  = 0;

	// Use this for initialization
	void Awake () {
		if (control == null) {
			DontDestroyOnLoad (gameObject);
			control = this;
		}

		else if (control != this) {
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnGUI() {
		GUI.Label (new Rect (10, 10, 100, 30), "Health: " + health);
		GUI.Label (new Rect (10, 25, 100, 30), "Glucose: " + glucose);
	}
}
