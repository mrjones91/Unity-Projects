using UnityEngine;
using System.Collections;

public class BlockGame : RtBehaviour {
	public ScoreScript scoreKeeper;
	
	private int bricks, level, lives;
	private int[] LvlReq;
	private GameObject ball;
	private Vector3 ballPos;
	

	//private int score = 0;
	// Use this for initialization
	void Start () {
		ball = GameObject.Find("Ball");
		ballPos = new Vector3 (0, 1, 0);
		bricks = 0;
		LvlReq = new int[8];
		LvlReq[0] = 28;
		LvlReq[1] = 28;
		LvlReq[2] = 30;
		LvlReq[3] = 30;
		LvlReq[4] = 30;
		LvlReq[5] = 30;
		LvlReq[6] = 30;
		LvlReq[7] = 30;
		
		lives = PlayerPrefs.GetInt("lives");
		level = PlayerPrefs.GetInt("currentlvl");
		PlayerPrefs.SetInt("BricksLeft", LvlReq[level]);
		Debug.Log("Current Level: " + level + "Lives: " + lives + "BricksLeft" + LvlReq[level]);
		
		//GuiScore.text = "Score: " + score.ToString();
		//InvokeRepeating("UpdateScore", 0.05f, 0.05f);
	}
	
	// Update is called once per frame
	void Update () {
	
		if (PlayerPrefs.GetInt("BricksLeft") == 0 )
		{
			NextLevel(level + 1);
			
		}
	}
	
	public void NextLevel(int _level)
	{
		level = _level;
		Application.LoadLevel("Level" + _level);
		PlayerPrefs.SetInt("currentLvl", _level);
	}
	
	public void AddBrick(int brick){
		bricks += brick;
		if (bricks == LvlReq[level])
			NextLevel(PlayerPrefs.GetInt("currentLvl") + 1);
	}
	
	public void GameOver() {
		if (lives > 0)
		{
			// Reset positions
			ball.transform.position = ballPos;
			ball.rigidbody.velocity = new Vector3(3f, 5f, 0f);
			
			lives--;
			PlayerPrefs.SetInt("lives", lives);
			
	}
		else{
		Debug.Log(PlayerPrefs.GetInt("highScore"));
			Application.LoadLevel("Menu");
		}
	}
		
}