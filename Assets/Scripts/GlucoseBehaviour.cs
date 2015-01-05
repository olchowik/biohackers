using UnityEngine;
using System.Collections;

public class GlucoseBehaviour : MonoBehaviour {

	public float driftMax = 0.25f;
	public float driftStr = 0.01f;
	public float moveFreq = 0.1f;
	float start_x = 0f;
	float start_y = 0f;

	void OnTriggerEnter2D(Collider2D bacteria) {
		if(bacteria.gameObject.name == "player"){
			GameControl.control.glucose += 10;
			Destroy(this.gameObject);
		}
		else {
			Vector2 escapeMove = new Vector2(start_x - transform.position.x, start_y - transform.position.y) * driftStr * 2f;
			transform.Translate(escapeMove);
		}
	}

	void Start() {
		start_x = transform.position.x;
		start_y = transform.position.y;
		InvokeRepeating("MakeRandomMove", 1, moveFreq);
	}

	void MakeRandomMove() {
		Vector2 move = new Vector2(Random.Range(-driftStr,driftStr), Random.Range(-driftStr,driftStr));
		if (transform.position.x + move.x < start_x + driftMax && transform.position.x + move.x > start_x - driftMax
		    && transform.position.y + move.y < start_y + driftMax && transform.position.y + move.y > start_y - driftMax) {
			transform.Translate (move);
		}
	}

	void Update() {
		//move = Camera.main.ScreenToWorldPoint(move);
		//rigidbody2D.AddForce (move);
		//InvokeRepeating("MakeRandomMove", 1, 3.0F);
		//transform.position.x += 5;
	}

	

}
