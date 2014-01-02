using UnityEngine;
using System.Collections;

public class BallPowerUp : PowerUpController {

	public bool speed;
	private Vector3 accel;

	public override void Start ()
	{
		base.Start ();
		if (speed)
		{
			accel = new Vector3(4.5f, 7f, 0f);
		}
		else
		{
			accel = new Vector3(2f, 3f, 0f);
		}
	}

	protected override void Update ()
	{
		if (!paused)
		{
			if ( gameObject.activeSelf )
			{
				position.y -= .10f;
				gameObject.transform.position = position;
			}
			
			if (position.y < -4f)
			{
				Destroy ( gameObject );
			}
			
			if (collider.bounds.Intersects(paddle.collider.bounds))
			{
				Destroy (gameObject);
				ball.Accelerate(accel);

			}
		}
	}


}
