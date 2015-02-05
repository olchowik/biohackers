using UnityEngine;
using System.Collections;

public class PhageBehaviour : MonoBehaviour {

	/* this script controls not only phage behaviour but also
	 * DNA, antibiotics
	 * because they all basicaly do same thing in game
	 */

	public float driftMax = 0.25f;
	public float driftStr = 0.01f;
	public float moveFreq = 0.1f;

	// for normal non-changing phage change_type should be set for 4f - it turns off approach trigger 
	// for changing phage set type to 4f and change_type to desired phage type
	public float type = 0f;
	public float change_type = 4f;

	int moveDuration = 0;
	Vector2 current_move = new Vector2(0f,0f);
	float start_x = 0f;
	float start_y = 0f;

	void Start() {
		start_x = transform.position.x;
		start_y = transform.position.y;
		InvokeRepeating("MakeRandomMove", 1, moveFreq);
	}

	void OnTriggerEnter2D(Collider2D bacteria) {
		if(bacteria.gameObject.name == "player"){
			Destroy(this.gameObject);
		}
		else {
			Vector2 escapeMove = new Vector2(start_x - transform.position.x, start_y - transform.position.y) * driftStr * 2f;
			transform.Translate(escapeMove);
		}
	}


	
	void MakeRandomMove() {
		if (moveDuration <= 0) {
						current_move = new Vector2 (Random.Range (-driftStr, driftStr), Random.Range (-driftStr, driftStr));
						moveDuration = 10;
				} else if (transform.position.x + current_move.x < start_x + driftMax && transform.position.x + current_move.x > start_x - driftMax
						&& transform.position.y + current_move.y < start_y + driftMax && transform.position.y + current_move.y > start_y - driftMax) {
						transform.Translate (current_move);
				} else {
			moveDuration = 0;
				}
		moveDuration -= 1;
	}

}
