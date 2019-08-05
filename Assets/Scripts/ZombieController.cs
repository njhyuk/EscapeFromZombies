using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ZombieState {
	Idle = 0,
	Walk,
	Attack,
	Damage,
	Death
}

public class ZombieController : MonoBehaviour {

	ZombieState state = ZombieState.Walk;

	float interval =  0;
	float attackInterval =  0;
	Animator ani = null;
	GameObject playerObj = null; //Spider walk to player
	int hp = 2;
	bool scoreUpdated = false;
	public int moveSpeed = 0;
	public int damage = 3;


	void Start() 
	{
		ani = GetComponent<Animator> ();
		playerObj = GameObject.Find ("Player");
	}

	void Update()
	{
		if (state == ZombieState.Idle) {
			Idle ();
		} else if (state == ZombieState.Walk) {
			Walk ();
		} else if (state == ZombieState.Damage) {
			Damage ();
		} else if (state == ZombieState.Attack) {
			Attack ();
		} else if (state == ZombieState.Death) {
			Death ();
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Bullet")) {
			state = ZombieState.Damage;
		}
	}

	void Idle()
	{
		Debug.Log ("Idle");
		ani.Play ("Idle");

		interval += Time.deltaTime;
		if (interval > 2) {
			state = ZombieState.Walk;
			interval = 0;
		}
	}

	void Walk() {
		Debug.Log ("Walk");


		float distance = Vector3.Distance (playerObj.transform.position, transform.position);
		if (distance < 3) {
			state = ZombieState.Attack;
			interval = 2;
		} else {
			Vector3 dir = playerObj.transform.position - transform.position;
			dir.Normalize ();
			dir.y = 0;
			transform.position += dir * moveSpeed * Time.deltaTime;

			Quaternion from = transform.rotation;
			Quaternion to = Quaternion.LookRotation(dir);
			transform.rotation = Quaternion.Lerp (from, to, 5 * Time.deltaTime); //부드러운 회전 처리

			//ani.Play ("Walk");
		}
	}

	void Attack() {
		Debug.Log ("Attack");
		playerObj.SendMessage ("TakeDamage", Time.deltaTime * damage);
		AudioSource attackSound = GetComponent<AudioSource> ();
		if (attackSound.isPlaying == false) {
			attackSound.Play ();
		}


		state = ZombieState.Idle;
	}

	void Damage()
	{
		//ani.Play ("Damage");

		hp--;
		if (hp <= 0) {
			state = ZombieState.Death;
		} else {
			state = ZombieState.Walk;
		}
	}

	void Death()
	{
		ani.Play ("Death");
		if (scoreUpdated != true) {
			scoreUpdated = true;
			ScoreManager.score += 10;
		}
		Destroy (gameObject, 0.5f);
	}


}
