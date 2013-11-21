using UnityEngine;
using System.Collections;

public class TromboneController : TBehaviour {

	
	private Ray ray;
	private RaycastHit rayCastHit;
	private Vector3 position;
	// Use this for initialization
	void Start () {
		
		//ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		 
		position = new Vector3(-3, -2, 0);
	}
	
	
	void Update () {
		// Touch Movement
		
		
		//Keyboard Movement
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			if (transform.position.x > -3)
			{
				position.x -= 1f;
				transform.position = position;
			}
		}
		else if (Input.GetKey(KeyCode.RightArrow))
		{
			if (transform.position.x < 3)
			{
				position.x += 1f;
				transform.position = position;
			}
		}
	}
}
