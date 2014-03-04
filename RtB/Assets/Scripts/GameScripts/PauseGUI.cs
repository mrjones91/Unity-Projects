using UnityEngine;
using System.Collections;

public class PauseGUI : RtBehaviour {
	
	public TextMesh text, hiScore, menu;
	
	void Awake()
	{
		text.text = hiScore.text = "";
		hiScore.text = "";
		menu.text = "";
		//renderer.isVisible = false;
	}
	
	protected override void OnPauseGame ()
	{
		base.OnPauseGame ();
		text.text = "Paused";
		hiScore.text = "Hi Score: " + PlayerPrefs.GetInt("highScore");
		menu.text = "Quit to Menu?";
		menu.collider.isTrigger = false;
		//renderer.isVisible = true;
	}
	
	protected override void OnResumeGame ()
	{
		base.OnResumeGame();
		text.text = "";
		hiScore.text = "";
		menu.text = "";
		menu.collider.isTrigger = true;
		//renderer.isVisible = false;
	}

	protected override void OnEndGame ()
	{
		base.OnResumeGame();
		menu.collider.isTrigger = false;
		text.text = "Game Over";
		text.transform.localScale = new Vector3(0.14327f, 0.14327f, 0.14327f);
		text.transform.position = new Vector3(-2.719229f, 0f, 0f);

		hiScore.alignment = TextAlignment.Center;
		hiScore.transform.position = new Vector2(-1.604901f, 1.737249f);
		hiScore.text = "Score: " + PlayerPrefs.GetInt("Score") + "\nYour Best: " + PlayerPrefs.GetInt("highScore");

		menu.text = "Try Again?";
		menu.transform.position = new Vector3(-1.159526f, -0.9863482f, 0);
		//renderer.isVisible = false;
	}
}
