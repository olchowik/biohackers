using UnityEngine;
using System.Collections;

public class BackgroundScroll : MonoBehaviour {

	public float speed = 0;
	public GameObject player;

	void Start () {
		renderer.material.mainTextureOffset = new Vector2 (player.rigidbody2D.position.x * speed, 0f);
		}

	// Update is called once per frame
	void Update () {
		if (player.rigidbody2D.velocity.x != 0) {
			renderer.material.mainTextureOffset = new Vector2 (player.rigidbody2D.position.x * speed, 0f);
		}
	}
}
