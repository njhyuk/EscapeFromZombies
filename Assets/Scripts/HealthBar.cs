using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
	public Image currentHealthBar;
	public Text ratioText;
	public GameObject scratch;

	private float hitpoint = 150;
	private float maxHitpoint = 150;
	private float damageInterval = 0;

	// Use this for initialization
	void Start () {
		UpdateHealthBar ();
	}

	void Update(){
		damageInterval -= Time.deltaTime;
		if (damageInterval < 0) {
			damageInterval = 0;
			scratch.gameObject.SetActive (false);
		}
	}


	private void UpdateHealthBar(){
		float ratio = hitpoint / maxHitpoint;
		currentHealthBar.rectTransform.localScale = new Vector3 (ratio, 1, 1);
		ratioText.text = (ratio * 100).ToString("0") + "%";
	}

	public void TakeDamage(float damage){
		scratch.gameObject.SetActive (true);
		damageInterval = 0.5f;

		hitpoint -= damage;
		if (hitpoint < 0) {
			hitpoint = 0;
			Debug.Log ("Death");
		}
		UpdateHealthBar ();
	}

	public void HealDamage(float heal){

	}

}
