﻿using UnityEngine;
using System.Collections;

public class RtBehaviour : MonoBehaviour {
	
	public GUIText GuiScore;
	public GUIText GuiHighScore;
	
	public BlockGame game;
	public ScoreScript score;
	public PaddleMovement paddle;
	public BallMovement ball;
	public MusicPlayer mp;
	public EffectPlayer ep;
	//private GameObject menuB;

	private bool sent;
	
	protected PowerUpController powerUp;
	protected BrickScript brick;
	protected bool paused, end;

	private Ray ray;
	private RaycastHit rayCastHit;
	
	public virtual bool Paused
	{
		get
		{
			return paused;
		}
		set
		{
			paused = value;
		}
	}
	// Use this for initialization
	void Start () {
		//menu = GameObject.Find("Menu");


		end = false;
	
	}
	
	// Update is called once per frame
	protected virtual void Update () {
	
		if ( Input.GetKeyDown(KeyCode.Escape) )
		{
			BackButton();
			
		}
		if ( Input.GetKeyDown(KeyCode.Menu) || Input.GetKeyDown(KeyCode.Space) )
		{
			Menu();
		}

		if (game)
		{
			if (game.Lives < 0)
			{
				OnEndGame();
			}

			if (Input.GetMouseButtonDown(0))
			{
				if (paused == true || end == true)
				{
					ray = Camera.main.ScreenPointToRay(Input.mousePosition);
					if (Physics.Raycast(ray, out rayCastHit) )
					{
						if (rayCastHit.transform.name == "Menu1")
						{

							OnResumeGame();
							Application.LoadLevel("Menu");
														
						}
						else if (rayCastHit.transform.name == "Menu2")
						{
							OnResumeGame();
							PlayerPrefs.SetInt("lives", 2);
							PlayerPrefs.SetInt("Score", 0);
							Application.LoadLevel("Level1");
							
						}
					}
				}
			}
		}



	}
	
	protected virtual void BackButton()
	{
		PlayerPrefs.SetInt("Played", 1);
		Application.Quit();
	}
	
	protected virtual void Menu()
	{
		//GameObject[] objects = {GameObject.Find("Ball"), GameObject.Find("Paddle"), 
		//	GameObject.Find ("Pause GUI"), GameObject.Find ("GuiHighScore")};
		//
		//for (int i = 0; i < objects.Length; i++)
		//{

		//can get rid of sent and just use paused, but not sure if want
			if (!sent)
			{
			OnPauseGame();
				//objects[i].SendMessage("OnPauseGame", SendMessageOptions.DontRequireReceiver);
				//Debug.Log(objects[i].name + "Paused");
			}
			else if (sent)
			{
			OnResumeGame();
				//objects[i].SendMessage("OnResumeGame", SendMessageOptions.DontRequireReceiver);
			}
		//}
	}
	
	protected virtual void OnPauseGame()
	{
		sent = true;
		paused = true;
		Time.timeScale = 0;
	}
	protected virtual void OnResumeGame()
	{
		sent = false;
		paused = false;
		end = false;
		Time.timeScale = 1;
	}
	protected virtual void OnEndGame()
	{
		//sent = false;
		end = true;
		paused = true;
		Time.timeScale = 1;

	}
}
