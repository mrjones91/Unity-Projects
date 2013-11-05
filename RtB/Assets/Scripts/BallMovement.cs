using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour {
	

	public BlockGame game;
	
	//private int speed;
	private Vector3 force;
	
	void Awake() {
 
		//speed = 2;
		force = new Vector3(3f, 5f, 0f);
		rigidbody.velocity = force;
		constantForce.force = new Vector3(-.5f, -1.5f, 0f);
		
		//InvokeRepeating("IncreaseBallVelocity", 2, 1f);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//rigidbody.AddForce (0, -5, 0, ForceMode.Acceleration);
		
		
//		if ( (Mathf.Abs(rigidbody.velocity.x) > 12f) || (Mathf.Abs(rigidbody.velocity.y) > 12f) )
//		{
//			
//			rigidbody.AddForce(-1f, -1f, 0, ForceMode.Impulse);
//			Debug.Log ("velocity: " + rigidbody.velocity);
//		}
		//Debug.Log ("velocity: " + rigidbody.velocity);
		if (transform.position.y < -5)
		{
			game.GameOver();
			//Show a GUItext then go to menu
			//Application.LoadLevel("menu");
		}
	}
	
	void OnCollisionEnter(Collision col)
	{
		
		//if (col.gameObject.tag == "Brick")
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
	
	void IncreaseBallVelocity()
	{
		if (Mathf.Abs(rigidbody.velocity.x) < 13)
		{
			if (Mathf.Abs(rigidbody.velocity.y) < 13)
			{
				rigidbody.AddForce(.3f, .7f, 0, ForceMode.Impulse);
				rigidbody.velocity *= 1.25f;
				Debug.Log ("velocity: " + rigidbody.velocity);
			}

			
			
		}
	}
	

		
	
}
