using UnityEngine;
using System.Collections;

public class BacteriaTouchController : MonoBehaviour {

	public float forceStrength    = 2.0f;
	public float maxHorizontalVel = 2f;
	public float maxVerticalVel   = 2f;

	// Use this for initialization
	void Start () {
		if (GameControl.control.flag == "return" && Application.loadedLevelName == GameControl.control.base_level) {
			gameObject.rigidbody2D.position = new Vector2(GameControl.control.last_x, GameControl.control.last_y);
		}
	}
	
	// Update is called once per frame
	void Update () {

		// trigger on button click or hold
		if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0)) {
			// get clicked position and convert to world coords
			Vector2 clickedPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			clickedPosition = Camera.main.ScreenToWorldPoint(clickedPosition);

			// if velocity is smaller than limit: apply force, otherwise only apply vertical force
			if (Mathf.Abs(rigidbody2D.velocity.x) < maxHorizontalVel) {
				Vector2 forceVector = clickedPosition - rigidbody2D.position;
				if (Mathf.Abs(rigidbody2D.velocity.y) > maxVerticalVel) { 
					forceVector = new Vector2(clickedPosition.x - rigidbody2D.position.x, 0);
				}
				rigidbody2D.AddForce(forceVector * forceStrength);
			}

			else if (Mathf.Abs(rigidbody2D.velocity.y) < maxVerticalVel){
				Vector2 forceVector = new Vector2(0, clickedPosition.y - rigidbody2D.position.y);
				rigidbody2D.AddForce(forceVector * forceStrength);
			}

		}
	}
}
