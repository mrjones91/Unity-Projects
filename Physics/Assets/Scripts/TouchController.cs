using UnityEngine;
using System.Collections;

public class TouchController : TBehaviour {
	
	private Ray ray;
	private RaycastHit rayCastHit;
	private ArrayList Positions;
	private int tp;
	private int[] notes;
	
	public override void Awake()
	{		
		base.Awake();
		notes = new int[7];
		notes[0] = embo.First.Length;
		notes[1] = embo.Second.Length;
		notes[2] = embo.Third.Length;
		notes[3] = embo.Fourth.Length;
		notes[4] = embo.Fifth.Length;
		notes[5] = embo.Sixth.Length;
		notes[6] = embo.Seventh.Length;
		tp = (int)trombone.transform.position.x + 3;
	}
	
	void Update () {
		
		
		
		
		if(Input.GetMouseButton(0) )
		{
			
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			//if (rayCastHit.collider.gameObject.tag == "Player")
			{
				if (Physics.Raycast(ray, out rayCastHit) )
				{
					if (rayCastHit.transform.name == "PositionArea")
					{
						trombone.transform.position = new Vector3(Mathf.Clamp((int)rayCastHit.point.x, -3f, 3f), trombone.transform.position.y, 0);
						tp = (int)trombone.transform.position.x + 3;
						
						embo.transform.position = new Vector3(embo.transform.position.x, 0, 0);
						
					}
					
					else if (rayCastHit.transform.name == "NoteArea")
					{
						print (tp);
						if ( (int)rayCastHit.point.y < notes[tp])
						{
							embo.transform.position = new Vector3(embo.transform.position.x, (int) Mathf.Clamp (rayCastHit.point.y, 0 , 7),0);
						}
					}
				
					embo.PlayNote();
					
					
				}
			}
			
		}
		
		if (Input.GetMouseButtonDown(0) )
		{
			if (Physics.Raycast(ray, out rayCastHit) )
			{
				if (rayCastHit.transform.name == "Pause")
				{
					if (pause.Paused)
					{
						pause.Paused = false;
					}
					else
					{
						pause.Paused = true;
					}
				}
			}
			
			
					
		}
		
		
	}
}
