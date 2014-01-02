using UnityEngine;
using System.Collections;

public class PauseGUI : RtBehaviour {
	
	public TextMesh text, hiScore;
	
	void Awake()
	{
		text.text = hiScore.text = "";
		hiScore.text = "";
		//renderer.isVisible = false;
	}
	
	protected override void OnPauseGame ()
	{
		base.OnPauseGame ();
		text.text = "Paused";
		hiScore.text = "Hi Score: " + PlayerPrefs.GetInt("highScore");
		//renderer.isVisible = true;
	}
	
	protected override void OnResumeGame ()
	{
		base.OnResumeGame();
		text.text = "";
		hiScore.text = "";
		//renderer.isVisible = false;
	}
}
