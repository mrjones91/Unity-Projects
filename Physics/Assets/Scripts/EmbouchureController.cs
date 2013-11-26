using UnityEngine;
using System.Collections;

public class EmbouchureController : TBehaviour {

	public AudioClip[] First, Second, Third, Fourth, Fifth, Sixth, Seventh;
	
	public TextMesh Note, Position, NoPo, NoNu;
	
	private int height, slide, num;
	private Ray ray;
	private RaycastHit rayCastHit;
	
	
	public override void Awake () 
	{
		base.Awake();
		audio.clip = First[(int)transform.position.y];
		AudioSource op;
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		if (Input.GetKey(KeyCode.LeftArrow)  || Input.GetKey(KeyCode.RightArrow) )
		{
			PlayNote();
		}
		
		if (Input.GetKey(KeyCode.UpArrow) )
		{
			PlayNote();
			if (height < 7)
			{
				height++;
			}
			transform.position = new Vector3(transform.position.x, height, transform.position.z);
			
		}
		if (Input.GetKey(KeyCode.DownArrow) )
		{
			PlayNote();
			if (height > 0)
			{
				height--;
			}
			transform.position = new Vector3(transform.position.x, height, transform.position.z);
			
		}
		
	}
	
	public void PlayNote()
	{
		if (trombone.transform.position.x == -3)
		{
			if ( (int)embo.transform.position.y > First.Length)
			{
				embo.transform.position = new Vector3( embo.transform.position.x , (float)First.Length, 0);
				height = First.Length;
			}
			audio.clip = First[(int)transform.position.y];
			NoPo.text = "There are " + First.Length + " notes on this position.";
		}
		if (trombone.transform.position.x == -2)
		{
			if ( (int)transform.position.y > Second.Length)
			{
				embo.transform.position = new Vector3( transform.position.x , (float)Second.Length, 0);
				height = Second.Length;
			}
			audio.clip = Second[(int)transform.position.y];
			NoPo.text = "There are " + Second.Length + " notes on this position.";
		}
		if (trombone.transform.position.x == -1)
		{
			if ( (int)transform.position.y > Third.Length)
			{
				embo.transform.position = new Vector3( transform.position.x , (float)Third.Length, 0);
				height = Third.Length;
			}
			audio.clip = Third[(int)transform.position.y];
			NoPo.text = "There are " + Third.Length + " notes on this position.";
		}
		if (trombone.transform.position.x == 0)
		{
			if ( (int)transform.position.y > Fourth.Length)
			{
				embo.transform.position = new Vector3( transform.position.x , (float)Fourth.Length, 0);
				height = Fourth.Length;
			}
			audio.clip = Fourth[(int)transform.position.y];
			NoPo.text = "There are " + Fourth.Length + " notes on this position.";
		}
		if (trombone.transform.position.x == 1)
		{
			if ( (int)transform.position.y > Fifth.Length)
			{
				embo.transform.position = new Vector3( transform.position.x , (float)Fifth.Length, 0);
				height = Fifth.Length;
			}
			audio.clip = Fifth[(int)transform.position.y];
			NoPo.text = "There are " + Fifth.Length + " on this position.";
		}
		if (trombone.transform.position.x == 2)
		{
			if ( (int)transform.position.y > Sixth.Length)
			{
				embo.transform.position = new Vector3( transform.position.x , (float)Sixth.Length, 0);
				height = Sixth.Length;
			}
			audio.clip = Sixth[(int)transform.position.y];
			NoPo.text = "There are " + Sixth.Length + " notes on this position.";
		}
		if (trombone.transform.position.x == 3)
		{
			if ( (int)transform.position.y > Seventh.Length)
			{
				embo.transform.position = new Vector3( transform.position.x , (float)Seventh.Length, 0);
				height = Seventh.Length;
			}
			audio.clip = Seventh[(int)transform.position.y];
			NoPo.text = "There are " + Seventh.Length + " notes on this position.";
		}
		if (pause.Paused)
		{
			audio.Pause();
		}
		else
		{
			
			audio.Play();
			
			
		}
		num = (int)embo.transform.position.y + 1;
		slide = (int)trombone.transform.position.x + 4;
		Note.text = audio.clip.name;
		Position.text = "Slide Position: " + slide;
		NoNu.text = "Note #: " + num;
		
	}
}
