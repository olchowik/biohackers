using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public GameObject player;
	public float x_align = 0f;
	

	// Update is called once per frame
	void Update () {
		if (player.gameObject.transform.position.x >= 0 && player.gameObject.transform.position.x <= 150) {
			this.gameObject.transform.position = new Vector3 (player.gameObject.transform.position.x + x_align, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
		}

	}
}
