using UnityEngine;
using System.Collections;

public class PowerUpController : RtBehaviour {
	
	protected Vector3 position;
	
	public virtual void Awake()
	{
		gameObject.SetActive(false);
		
	}
	
	public virtual void Start () 
	{
		position = gameObject.transform.position;
	}

	public virtual void Update () 
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
		}
	}
	

}
