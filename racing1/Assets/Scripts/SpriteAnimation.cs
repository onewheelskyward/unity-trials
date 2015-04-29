using UnityEngine;
using System.Collections;

public class SpriteAnimation : MonoBehaviour {

	public int columns = 8;
	public int rows = 8;

	public int currentFrame = 1;
	public float animationTime = 0.0f;
	public float fps = 10.0f;

	private Vector2 framePostition;
	private Vector2 frameSize;
	private Vector2 frameOffset;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		PlayAnimation();
	}

	void PlayAnimation() {
		Renderer renderer = GetComponent<Renderer>();
		animationTime -= Time.deltaTime;

		if (animationTime <= 0) {
			currentFrame++;
			animationTime++;
		}

		frameSize = new Vector2(1.0f / columns, 1.0f / rows);
		frameOffset = new Vector2(1.0f / columns, 1.0f / rows);

		renderer.material.SetTextureScale("_MainTex", frameSize);
		renderer.material.SetTextureOffset("_MainTex", frameOffset);
	}
}
