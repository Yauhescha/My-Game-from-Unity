using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovedPlatform : MonoBehaviour {

	[SerializeField]
	private float speed = 3.0F;

	[SerializeField]
	private float distance= 3.0F;

	[SerializeField]
	private bool up= false;
	[SerializeField]
	private bool down= false;

	[SerializeField]
	private bool left= false;
	[SerializeField]
	private bool right= true;

	private Vector3 currentPosition;
	// Use this for initialization
	void Start () {
		currentPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (left || right)
			moveLeftOrRight ();
		if (up || down)
			moveUpOrDown ();
	}

	private void moveLeftOrRight (){
		Vector3 direction = right?transform.right:transform.right*-1;

		transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
		if (currentPosition.x > transform.position.x + distance
			|| currentPosition.x < transform.position.x - distance) {
			left = !left;
			right = !right;
		}
	}


	private void moveUpOrDown  (){
		Vector3 direction = up?transform.up:transform.up*-1;
		transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
		if (currentPosition.y > transform.position.y + distance
			|| currentPosition.y < transform.position.y - distance) {
			up = !up;
			down = !down;
		}
	}

	private void OnCollisionExit2D(Collision2D collider){
		if(collider.gameObject.GetComponent<Character>()!=null)
			collider.transform.parent = transform.parent;
	}
	private void OnCollisionEnter2D(Collision2D collider){
		if (collider.gameObject.GetComponent<Character>() != null)
			collider.transform.parent = transform;
	}

}
