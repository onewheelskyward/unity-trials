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
		float verticalSpeed = Input.GetAxis("Vertical");     // Input vertical button e.g. W/s
		float horizontalSpeed = Input.GetAxis("Horizontal"); // Input horizontal button e.g. a/d
		Rigidbody rigidBody = GetComponent<Rigidbody>();

		float currentSpeed = Mathf.Abs(transform.InverseTransformDirection(rigidBody.velocity).z);
		
		float maxAngularDrag = 2.5f;
		float currentAngularDrag = 1.0f;
		float angularDragLerpTime = currentSpeed * 0.1f;
		
		float maxDrag = 1.0f;
		float currentDrag = 2.5f;
		float dragLerpTime = currentSpeed * 0.1f;

		if (verticalSpeed > 0.0f) {
			moveDirection = verticalSpeed * speed;
			rigidBody.AddRelativeForce(0, 0, moveDirection);

			if (currentSpeed > 0.05f) {
				turnDirection = horizontalSpeed * turnSpeed;
				rigidBody.AddRelativeTorque(0, turnDirection, 0);
			}
		}

		if (verticalSpeed < 0.0f) {
			moveDirection = verticalSpeed * reverseSpeed;
			rigidBody.AddRelativeForce(0, 0, moveDirection);

			if (currentSpeed < 0.05f) {
				turnDirection = horizontalSpeed * turnSpeed;
				rigidBody.AddRelativeTorque(0, -turnDirection, 0);
			}
		}

		// Set the drag coeffecients.
		float angularDrag = Mathf.Lerp(currentAngularDrag, maxAngularDrag, angularDragLerpTime);
		float drag = Mathf.Lerp (currentDrag, maxDrag, dragLerpTime);

		rigidBody.angularDrag = angularDrag;
		rigidBody.drag = drag;

	}
}
