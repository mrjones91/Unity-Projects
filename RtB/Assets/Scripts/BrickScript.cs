using UnityEngine;
using System.Collections;

public class BrickScript : MonoBehaviour {
	public ScoreScript scoreKeeper;
	public BlockGame game;
	public int type;
	float points;
	public MeshRenderer mesh;
	
	
	//public MainGame mainGameScript;
	void Start () {
		
		
		//mesh = (MeshRenderer)(gameObject.GetComponent("Mesh"));
		
		
		// Set point to BrickType...
		switch(type)
		{
		case 1:
			//figure out enums
			//set color to Blue
			//points = BrickType.Blue;
			mesh.material.color = Color.blue;
			points = 1;
			//PlayerPrefs.SetInt("BricksLeft", (PlayerPrefs.GetInt("BricksLeft") + 1) );
			break;
		case 2:
			//set color to Red
			mesh.material.color = Color.red;
			points = 1;
			//PlayerPrefs.SetInt("BricksLeft", (PlayerPrefs.GetInt("BricksLeft") + 1) );
			break;
		case 3:
			//set color to Yellow
			mesh.material.color = Color.yellow;
			points = 1;
			PlayerPrefs.SetInt("BricksLeft", (PlayerPrefs.GetInt("BricksLeft") + 1) );
			break;
		case 4:
			//set color to Green
			mesh.material.color = Color.green;
			points = 1.5f;
			//PlayerPrefs.SetInt("BricksLeft", (PlayerPrefs.GetInt("BricksLeft") + 1) );
			break;
		case 5:
			//set color to Purple
			Color purple = new Color(200, 100, 200, 50);
			mesh.material.color = purple;
			points = 1.5f;
			//PlayerPrefs.SetInt("BricksLeft", (PlayerPrefs.GetInt("BricksLeft") + 1) );
			break;
		case 6:
			//set color to Brown
			Color brown = new Color(100, 100, 100, 50);
			mesh.material.color = brown;
			points = 2;
			//PlayerPrefs.SetInt("BricksLeft", (PlayerPrefs.GetInt("BricksLeft") + 1) );
			break;
		case 7:
			//set color to White
			mesh.material.color = Color.white;
			points = 2;
			//PlayerPrefs.SetInt("BricksLeft", (PlayerPrefs.GetInt("BricksLeft") + 1) );
			break; 
		default:
			points = 100;
			Debug.Log("Fix " + gameObject.name + " you dummy!");
			break;
			
		}
	}
	
	
	
	void OnCollisionEnter(Collision col)
	{
		//mainGameScript.UpdateScore(BrickType);
		//mesh.material = 
		
		//Debug.Log ("Total Bricks: " + PlayerPrefs.GetInt("BricksLeft") + "Current Level: " + PlayerPrefs.GetInt("currentLvl"));
		//Score.score += points;
		Destroy (gameObject);
		scoreKeeper.AddScore(points);
		game.AddBrick(1);
		
		
	}
	
	void Update()
	{
		
	}
}

public enum BrickType{
	Blue = 1,
	Red = 1,
	Yellow = 1,
	Green = 1, //1.5
	Purple = 1, //1.5
	Brown = 2,
	White = 2,
}
