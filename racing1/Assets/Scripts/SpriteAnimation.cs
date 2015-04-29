using UnityEngine;
using System.Collections;

public class SpriteAnimation : MonoBehaviour {

	public int columns = 8;
	public int rows = 8;

	public int currentFrame = 1;
	public int currentAnimation = 0;

	public float animationTime = 0.0f;
	public float fps = 10.0f;

	private Vector2 framePostition;
	private Vector2 frameSize;
	private Vector2 frameOffset;

	private int i;  // Not real sure why we're storing this on the instance.

	private int idleFrame = 17;
	private int idleLeft = 1;
	private int idleRight = 2;
	private int driveMin = 3;
	private int driveMax = 4;
	private int driveLeftMin = 5;
	private int driveLeftMax = 6;
	private int driveRightMin = 7;
	private int driveRightMax = 8;
	private int spin = 9;
	private int explosionMin = 10;
	private int explosionMax = 16;


	private int animIdle = 0;
	private int animIdleLeft = 1;
	private int animIdleRight = 2;
	private int animDrive = 3;
	private int animDriveLeft = 4;
	private int animDriveRight = 5;
	private int animSpin = 6;
	private int animExplosion = 7;

			// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		HandleAnimation();
	}

	void HandleAnimation() {
		FindAnimation();
		PlayAnimation();
	}

	void FindAnimation() {
		if (Input.GetAxis("Vertical") > 0.0f) {
			currentAnimation = animDrive;
		} else {
			currentAnimation = animIdle;
		}
	}

	void PlayAnimation() {
		Renderer renderer = GetComponent<Renderer>();
		animationTime -= Time.deltaTime;

		if (animationTime <= 0) {
			currentFrame++;
			animationTime++;
		}

		// Enter the weird magic...this is just strange.
		framePostition.y = 1;

		for (i = currentFrame; i > columns; i -= rows) {
			framePostition.y++;
		}

		framePostition.x = i - 1;

		// End weird magic

		frameSize = new Vector2(1.0f / columns, 1.0f / rows);
		frameOffset = new Vector2(framePostition.x / columns, 1.0f - (framePostition.y / rows));

		renderer.material.SetTextureScale("_MainTex", frameSize);
		renderer.material.SetTextureOffset("_MainTex", frameOffset);
	}
}
