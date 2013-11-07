using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {
	
	private int score, hiScore, level;
	
	
	public GUIText GuiScore;
	public GUIText GuiHighScore;
	
	
	// Use this for initialization
	void Start () {
		
		
		score = 0;
		level = PlayerPrefs.GetInt("currentlvl");

		GuiScore.text = "Score: " + score;
		if (PlayerPrefs.GetInt("highScore") != score )
			GuiHighScore.text = "High Score: " + PlayerPrefs.GetInt("highScore");
		
	}
	
	// Update is called once per frame
	void Update () {
		if (score > PlayerPrefs.GetInt("highScore"))
			{
				PlayerPrefs.SetInt("highScore", score);
			}
	}
	
	public void AddScore(float points) {
		//Debug.Log("score = " + score + " points = " + points);
		points *= ( (level + 1) * 10);
		//Debug.Log("score = " + score + " points = " + points);
		score += (int)points;
		Debug.Log("score = " + score + " points = " + points);
		GuiScore.text = "Score: " + score.ToString();
		
	}
	
	
	
	
}
