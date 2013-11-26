using UnityEngine;
using System.Collections;

public class BallMovement : RtBehaviour 
{
	

	
	
	//private int speed;
	private Vector3 force;
	
	void Awake() {
 
		//speed = 2;
		force = new Vector3(3f, 5f, 0f);
		rigidbody.velocity = force;
		//constantForce.force = new Vector3(-.5f, -1.5f, 0f);
		
		//InvokeRepeating("IncreaseBallVelocity", 2, 1f);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	protected override void Update () 
	{
		if (!paused)
		{
			if (transform.position.y < -6)
			{
				game.GameOver();
	
			}
		}
		
	}
	
	void OnCollisionEnter(Collision col)
	{
		
		if (col.gameObject.tag != "PowerUp")
		{
			if (col.transform.position.x > rigidbody.transform.position.x)
			{
				if (Mathf.Abs(rigidbody.velocity.x) < 7)
					rigidbody.AddForce(Vector3.left, ForceMode.VelocityChange);
				
			}
			else if (col.transform.position.x < rigidbody.transform.position.x)
			{
				if (Mathf.Abs(rigidbody.velocity.x) < 7)
					rigidbody.AddForce(Vector3.right, ForceMode.VelocityChange);
			}
			if (col.transform.position.y > rigidbody.transform.position.y)
			{
				rigidbody.AddForce(Vector3.down);
				//rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, 0);
			}
			else if (col.transform.position.y < rigidbody.transform.position.y)
			{
				rigidbody.AddForce(Vector3.up);
				//rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, 0);
			}
			//if (Mathf(col.transform.localScale) / 2 
			//rigidbody.AddRelativeForce( (float)(rigidbody.angularVelocity.magnitude * -1), 0, 0);
			//rigidbody.AddForce(force);
		}
	}
	
	protected override void OnPauseGame ()
	{
		
		//force = rigidbody.velocity;
		//rigidbody.velocity = Vector3.zero;
		base.OnPauseGame ();
	}
	
	protected override void OnResumeGame ()
	{
		base.OnResumeGame ();
		//rigidbody.AddForce(force);
	}
	
	

		
	
}
