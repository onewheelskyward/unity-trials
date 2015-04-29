using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 10.0f;
	public float reverseSpeed = 5.0f;
	public float turnSpeed = 0.6f;

	private float moveDirection = 0.0f;
	private float turnDirection = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetAxis("Vertical") > 0.0f) {
						// Input vertical button e.g. up arrow
			moveDirection = Input.GetAxis("Vertical") * speed;
			GetComponent<Rigidbody>().AddRelativeForce(0, 0, moveDirection);
		}
		if (Input.GetAxis("Vertical") < 0.0f) {
			moveDirection = Input.GetAxis("Vertical") * reverseSpeed;
			GetComponent<Rigidbody>().AddRelativeForce(0, 0, moveDirection);
		}
			
	}
}
