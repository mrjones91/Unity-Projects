using UnityEngine;
using System.Collections;

public class Background : RtBehaviour {

	public Texture[] frames;
	public float FPS;
	private float secondsToWait, scrollSpeed, offset, xOffset, yOffset, x, y;
	private bool inBounds;
	private int currentFrame;
	private Vector3 force;
	Color bg;
	
	void Awake()
	{
		bg = Color.white;
		bg.a = .30f;
	}
	void Start () 
	{
		scrollSpeed = 0.5f;
		xOffset = yOffset = Time.time * scrollSpeed;
		currentFrame = 0;
		secondsToWait = 1/FPS;
		renderer.material.mainTexture = frames[currentFrame];
		renderer.material.color = bg;
		StartCoroutine(Animate());
		inBounds = true;
		
		force = new Vector3(50f, 80f, 0f);
		rigidbody.velocity = force;

	}
	
	void Scroll()
	{
		if (inBounds)
		{
			x = Mathf.Clamp(xOffset, 7f, -7f);
			y = Mathf.Clamp(yOffset, 12f, -10f);
			gameObject.transform.position = new Vector3(x, y, 0);
			
		}
		
	}
	IEnumerator Animate()
	{
				
		yield return new WaitForSeconds(secondsToWait);

		if (currentFrame == 14)
		{
			currentFrame = 0;
		}
		else
			currentFrame++;
		
		renderer.material.mainTexture = frames[currentFrame];
		
		StartCoroutine(Animate());

	}

}
