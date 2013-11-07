using UnityEngine;
using System.Collections;

public class SafetyPowerUp : PowerUpController {
	
	public GameObject safebar;
	private Quaternion rotation;
	private float time;
	
	public override void Awake()
	{
		gameObject.SetActive(false);

	}
	
	public override void Start ()
	{
		base.Start ();
		time = 10;
	}
	
	public override void Update ()
	{
		time -= Time.deltaTime;
		
		if (time <= 0)
		{
			//destroy the bar...
		}
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
