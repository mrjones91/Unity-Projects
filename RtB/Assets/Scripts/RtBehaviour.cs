using UnityEngine;
using System.Collections;

public class RtBehaviour : MonoBehaviour {
	
	public GUIText GuiScore;
	public GUIText GuiHighScore;
	
	public BlockGame game;
	public ScoreScript score;
	public PaddleMovement paddle;
	public BallMovement ball;
	
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
		if ( Input.GetKeyDown(KeyCode.Menu) || Input.GetKey(KeyCode.Space) )
		{
			Menu();
		}
	}
	
	protected virtual void BackButton()
	{
		Application.Quit();
	}
	
	protected virtual void Menu()
	{
		Object[] objects = FindObjectsOfType (typeof(GameObject));
		foreach (GameObject go in objects)
		{
			if (!sent)
			{
				go.SendMessage("OnPauseGame", SendMessageOptions.DontRequireReceiver);
			}
			else if (sent)
			{
				go.SendMessage("OnResumeGame", SendMessageOptions.DontRequireReceiver);
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
