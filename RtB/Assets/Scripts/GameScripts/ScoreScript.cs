using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {
	
	private int score, hiScore, level;
	
	
	public TextMesh GuiScore;
	
	
	// Use this for initialization
	void Start () {
		
		
		score = PlayerPrefs.GetInt("Score");
		level = PlayerPrefs.GetInt("currentlvl");

		GuiScore.text = "Score: " + score;

		
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
		PlayerPrefs.SetInt("Score", score);
	}
	
	
	
	
}
