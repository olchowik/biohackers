using UnityEngine;
using System.Collections;

public class PhageRange : MonoBehaviour {

	public Sprite[] phages;

	// Use this for initialization
	void Awake() {
		transform.parent.GetComponent<SpriteRenderer> ().sprite = phages [(int)transform.parent.GetComponent<PhageBehaviour> ().type];
		if (transform.parent.GetComponent<PhageBehaviour>().change_type == 4f) {
			Destroy(this.gameObject);
		}
	}

	public void SetSprite(){
		transform.parent.GetComponent<SpriteRenderer> ().sprite = phages [(int)transform.parent.GetComponent<PhageBehaviour> ().type];
		if (transform.parent.GetComponent<PhageBehaviour>().type != 4f) {
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D bacteria) {
		if(bacteria.gameObject.name == "player"){
			transform.parent.GetComponent<SpriteRenderer> ().sprite = phages [(int)transform.parent.GetComponent<PhageBehaviour> ().change_type];
		}
	}

	void OnTriggerExit2D(Collider2D bacteria) {
		if(bacteria.gameObject.name == "player"){
			transform.parent.GetComponent<SpriteRenderer> ().sprite = phages [4];
		}
	}
}
