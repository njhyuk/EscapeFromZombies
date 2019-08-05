using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManager : MonoBehaviour {

	public GameObject ball = null;
	public GameObject startBall = null;
	float interval =  0;
	public Vector3 velocity;

	// Update is called once per frame
	void Update () {
		interval += Time.deltaTime;
		if (interval > 0.1f) {
			if (Input.GetMouseButton (0) == true) {
				Fire ();
				interval = 0;
			}
		}
		if (Input.GetMouseButtonDown (0) == true) {
			Fire ();
			interval = 0;
		}
	}

	void Fire() {
		AudioSource shoot = GetComponent<AudioSource> ();
		shoot.Play ();

		GameObject obj = Instantiate (ball);
		obj.transform.position = startBall.transform.position;
	}
}
