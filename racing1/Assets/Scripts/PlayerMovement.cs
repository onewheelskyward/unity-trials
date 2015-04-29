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
		float verticalSpeed = Input.GetAxis("Vertical");
		float horizontalSpeed = Input.GetAxis("Horizontal");
		Rigidbody rigidBody = GetComponent<Rigidbody>();

		if (verticalSpeed >= 0.0f) {
						// Input vertical button e.g. up arrow
			moveDirection = verticalSpeed * speed;
			rigidBody.AddRelativeForce(0, 0, moveDirection);

			turnDirection = horizontalSpeed * turnSpeed;
			rigidBody.AddRelativeTorque(0, turnDirection, 0);
		}
		if (verticalSpeed < 0.0f) {
			moveDirection = verticalSpeed * reverseSpeed;
			rigidBody.AddRelativeForce(0, 0, moveDirection);

			turnDirection = horizontalSpeed * turnSpeed;
			rigidBody.AddRelativeTorque(0, -turnDirection, 0);
		}

		float currentSpeed = Mathf.Abs(transform.InverseTransformDirection(rigidBody.velocity).z);
			
	}
}
