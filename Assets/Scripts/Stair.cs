using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stair : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D collider)
	{
		CharacterMovement character = collider.gameObject.GetComponent<CharacterMovement>();
		if (character)
		{
			character.IsOnStair = true;
			
			character.GetComponent<Rigidbody2D>().gravityScale = 0;
		}
	}
	private void OnTriggerExit2D(Collider2D collider)
	{
		CharacterMovement character = collider.gameObject.GetComponent<CharacterMovement>(); 
		if (character) {
			character.IsOnStair = false;
			character.GetComponent<Rigidbody2D>().gravityScale = 3;;
			character.IsJump = false;
		}
	}

}
