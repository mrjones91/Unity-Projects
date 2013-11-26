using UnityEngine;
using System.Collections;

public class Pause : TBehaviour {

	public bool Paused;
	
	public TextMesh ui;
	
	public void Update()
	{
		if (Paused)
		{
			ui.text = "Play";
		}
		else
		{
			ui.text = "Pause";
		}
	}
}
