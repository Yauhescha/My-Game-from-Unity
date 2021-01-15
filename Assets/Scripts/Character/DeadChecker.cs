using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadChecker : MonoBehaviour {

	[SerializeField]
	private float maxYLevel = -10;
	[SerializeField]
	private int damageFromYLevel = 10;
	// Update is called once per frame
	void FixedUpdate() {
		if (transform.position.y < maxYLevel) {
			Vector3 p = transform.position;
			GetComponent<Rigidbody2D>().velocity = Vector3.zero;
			p.x = 0f;
			p.y = 0f;
			GetComponent<Character>().ReceiveDamage(damageFromYLevel);
			GetComponent<CharacterMovement>().IsJump = false; 
			transform.position = p;
		}
			
	}
	void Update() {
		if (GetComponent<Character>().CurrentHealth <= 0) {
						
			Time.timeScale = 0;
			GameObject.FindObjectOfType<GameUIController>().DeadScreen_ActiveScreen();

		}

	}
}
