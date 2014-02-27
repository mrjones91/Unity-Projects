using UnityEngine;
using System.Collections;

public class BlockGame : RtBehaviour {
	public ScoreScript scoreKeeper;
	public Background bg;
	private int bricks, level, lives;
	private int[] LvlReq;
	private GameObject ballb, player;
	private Vector3 ballPos;
	

	//private int score = 0;
	// Use this for initialization
	void Start () {
		bg.renderer.material.color = Color.gray;
		ballb = GameObject.Find("Ball");
		player = GameObject.Find ("Paddle");
		ballPos = new Vector3 (0, 1, 0);
		bricks = 0;
		LvlReq = new int[4];
		LvlReq[0] = 28;
		LvlReq[1] = 28;
		LvlReq[2] = 25;
		LvlReq[3] = 25;

		
		lives = PlayerPrefs.GetInt("lives");

		Debug.Log("Current Level: " + level + "Lives: " + lives + "BricksLeft" + LvlReq[level]);
		
		//GuiScore.text = "Score: " + score.ToString();
		//InvokeRepeating("UpdateScore", 0.05f, 0.05f);
		switch (Application.loadedLevelName)
		{
		case "Level1":
			print (Application.loadedLevelName);
			PlayerPrefs.SetInt("BricksLeft", LvlReq[0]);
			PlayerPrefs.SetInt("currentlvl", 1);
			level = PlayerPrefs.GetInt("currentlvl");
			break;
		case "Level2":
			print (Application.loadedLevelName);
			PlayerPrefs.SetInt("BricksLeft", LvlReq[1]);
			PlayerPrefs.SetInt("currentlvl", 2);
			level = PlayerPrefs.GetInt("currentlvl");
			break;
		case "Level3":
			print (Application.loadedLevelName);
			PlayerPrefs.SetInt("BricksLeft", LvlReq[2]);
			PlayerPrefs.SetInt("currentlvl", 3);
			level = PlayerPrefs.GetInt("currentlvl");
			break;
		default:
			print ("not a playable level");
			break;
		}
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update();
		
		//if (PlayerPrefs.GetInt("BricksLeft") == 0 )
		{

		//	NextLevel(level + 1);
			
		}


		
	}
	
	public void NextLevel(int _level)
	{
		//level = _level;
		Application.LoadLevel("Level" + _level);
		PlayerPrefs.SetInt("currentLvl", _level);
		//level = PlayerPrefs.GetInt("currentlvl");
	}
	
	public void AddBrick(int brick){
		bricks += brick;
		print ("level: " + level + " Bricks broken: " + bricks + "   Bricks Left: " + LvlReq[level]) ;
		if (bricks == LvlReq[level])
			NextLevel(PlayerPrefs.GetInt("currentLvl") + 1);
	}
	
	public void GameOver() {
		if (lives > 0)
		{
			// Reset positions
			ballb.transform.position = ballPos;
			ballb.rigidbody.velocity = new Vector3(3f, 5f, 0f);

			player.transform.localScale = new Vector3(1.5f, 0.2f, 1f);
			player.transform.position = paddle.Position;

			lives--;
			PlayerPrefs.SetInt("lives", lives);
			
	}
		else{
		Debug.Log(PlayerPrefs.GetInt("highScore"));
			Application.LoadLevel("Menu");
		}
	}
		
}