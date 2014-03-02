using UnityEngine;
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
	
	private bool sent;
	
	protected PowerUpController powerUp;
	protected BrickScript brick;
	protected bool paused;
	
	// Use this for initialization
	void Start () {
	
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
	}
	
	protected virtual void BackButton()
	{
		PlayerPrefs.SetInt("Played", 1);
		Application.Quit();
	}
	
	protected virtual void Menu()
	{
		GameObject[] objects = {GameObject.Find("Ball"), GameObject.Find("Paddle"), 
			GameObject.Find ("Pause GUI"), GameObject.Find ("GuiHighScore")};

		for (int i = 0; i < objects.Length; i++)
		{
			if (!sent)
			{
				objects[i].SendMessage("OnPauseGame", SendMessageOptions.DontRequireReceiver);
				Debug.Log(objects[i].name + "Paused");
			}
			else if (sent)
			{
				objects[i].SendMessage("OnResumeGame", SendMessageOptions.DontRequireReceiver);
			}
		}
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
		Time.timeScale = 1;
	}
}
