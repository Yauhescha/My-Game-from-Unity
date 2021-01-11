using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadChecker : MonoBehaviour {


	public GameObject deadScreen;
	// Update is called once per frame
	void FixedUpdate() {
		if (transform.position.y < -10f) {
			Vector3 p = transform.position;
			GetComponent<Rigidbody2D>().velocity = Vector3.zero;
			p.x = 0f;
			p.y = 0f;
			GetComponent<Character>().ReceiveDamage(10);
			GetComponent<CharacterMovement>().IsJump = false; 
			transform.position = p;
		}
			
	}
	void Update() {
		if (GetComponent<Character>().CurrentHealth <= 0) {

			GetComponent<Character>().CurrentHealth = 1;
			Time.timeScale = 0;
			GameObject.FindWithTag("KeyboardControl").SetActive(false);
			deadScreen.SetActive(true);

		}

	}
}
