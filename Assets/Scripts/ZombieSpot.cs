using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpot : MonoBehaviour {

	public float time;
	public GameObject zombie = null;
	public float interval;
	public float genTime;

	// Use this for initialization
	void Start () {
		Create ();
	}
	
	// Update is called once per frame
	void Update()
	{
		time += Time.deltaTime;
		interval += Time.deltaTime;
		if (time >= 10) {
			if (time < 25) {
				genTime = 4f;
			} else if (time < 40) {
				genTime = 3f;
			} else if (time < 70) {
				genTime = 2f;
			} else if (time < 90) {
				genTime = 1.7f;
			} else {
				genTime = 1.2f;
			}

			if (interval > genTime) {
				Create ();
				interval = 0;
			}	
		}
	}

	void Create(){
		GameObject obj = Instantiate (zombie);
		obj.transform.position = transform.position;
	}
}