using UnityEngine;
using System.Collections;

public class PaddleMovement : MonoBehaviour {
	
		
	private Ray ray;
	private RaycastHit rayCastHit;
	private Vector3 position;
	
	// Use this for initialization
	void Start () {
		
		//ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		 
		position = new Vector3(0, -3, 0);
	}
	
	// Update is called once per frame
	void Update () {
		// Touch Movement
		if(Input.GetMouseButton(0) )
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out rayCastHit) )
			{
				//Vector3 position = Mathf.Clamp (rayCastHit.point.x, 0f, 10f);
				transform.position = new Vector3(Mathf.Clamp(rayCastHit.point.x, -3.5f, 3.5f), transform.position.y, transform.position.z);
				
			}
		}
		
		//Keyboard Movement
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			if (transform.position.x > -3.5)
			{
				position.x -= .15f;
				transform.position = position;
			}
		}
		else if (Input.GetKey(KeyCode.RightArrow))
		{
			if (transform.position.x < 3.5)
			{
				position.x += .15f;
				transform.position = position;
			}
		}
	}
}
