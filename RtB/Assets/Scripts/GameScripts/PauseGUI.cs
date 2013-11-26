using UnityEngine;
using System.Collections;

public class PauseGUI : RtBehaviour {
	
	public TextMesh text;
	
	void Awake()
	{
		text.text = "";
		//renderer.isVisible = false;
	}
	
	protected override void OnPauseGame ()
	{
		base.OnPauseGame ();
		text.text = "Paused";
		//renderer.isVisible = true;
	}
	
	protected override void OnResumeGame ()
	{
		base.OnResumeGame();
		text.text = "";
		//renderer.isVisible = false;
	}
}
