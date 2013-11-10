using UnityEngine;
using System.Collections;

public class SafetyPowerUp : PowerUpController {
	
	public GameObject safebar;
	private Quaternion rotation;
	
	
	public override void Awake()
	{
		gameObject.SetActive(false);

	}
	
	public override void Start ()
	{
		base.Start ();
		
	}
	
	public override void Update ()
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
			
			GameObject bar = (GameObject)Instantiate(safebar, new Vector3(-1f, -4f, 0f) , Quaternion.identity );

         
		}
	
	}
	
	
	

	
}
