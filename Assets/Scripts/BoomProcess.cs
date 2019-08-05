using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomProcess : MonoBehaviour {

	public GameObject particle;
	public float movementSpeed;
	public GameObject startBall = null;
	public Vector3 initForward;

	// Use this for initialization

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.layer == LayerMask.NameToLayer("zombie")) {
			GameObject obj = Instantiate (particle);
			obj.transform.position = transform.position;
			Destroy (obj, 2.0f);
		}

		Debug.Log (other.gameObject.name);
		Destroy (gameObject);
	}

	void Start () {
		startBall = GameObject.Find ("BulletStart");
		initForward = startBall.transform.forward;
		Destroy (gameObject, 4.0f);
	}

	void Update () {
		transform.Translate(initForward*movementSpeed*Time.deltaTime);
	}
}
