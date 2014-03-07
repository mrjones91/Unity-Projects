﻿using UnityEngine;
using System.Collections;

public class PauseGUI : RtBehaviour {
	
	public TextMesh text, hiScore, menu1, menu2;
	
	void Awake()
	{
		text.text = hiScore.text = "";
		hiScore.text = "";
		menu1.text = "";
		menu1.collider.isTrigger = true;
		menu2.text = "";
		menu2.collider.isTrigger = true;
		//renderer.isVisible = false;
	}
	
	protected override void OnPauseGame ()
	{
		base.OnPauseGame ();
		text.text = "Paused";
		hiScore.text = "Hi Score: " + PlayerPrefs.GetInt("highScore") + "\nYour Best: " + PlayerPrefs.GetInt ("best");
		menu1.text = "Quit to Menu?";
		menu1.collider.isTrigger = false;
		menu2.text = "";
		menu2.collider.isTrigger = true;
		//renderer.isVisible = true;
	}
	
	protected override void OnResumeGame ()
	{
		base.OnResumeGame();
		text.text = "";
		hiScore.text = "";
		menu1.text = "";
		menu1.collider.isTrigger = true;
		menu2.text = "";
		menu2.collider.isTrigger = true;
		//renderer.isVisible = false;
	}

	protected override void OnEndGame ()
	{
		base.OnResumeGame();
		menu1.collider.isTrigger = true;
		menu2.collider.isTrigger = false;
		text.text = "Game Over";
		text.transform.localScale = new Vector3(0.14327f, 0.14327f, 0.14327f);
		text.transform.position = new Vector3(-2.719229f, 0f, 0f);

		hiScore.alignment = TextAlignment.Center;
		hiScore.transform.position = new Vector2(-1.2f, 1.737249f);
		hiScore.text = "Score: " + PlayerPrefs.GetInt("Score") + "\nYour Best: " + PlayerPrefs.GetInt("best");

		menu2.text = "Try Again?";
		menu2.transform.position = new Vector3(-1.159526f, -0.9863482f, 0);
		//renderer.isVisible = false;
	}
}
