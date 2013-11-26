using UnityEngine;
using System.Collections;

public class MenuScene : RtBehaviour {
	private Ray ray;
	private RaycastHit rayCastHit;
	//private int gp;

	
	public GUIText HiScore;
	public TextMesh PlayButton;
	
	bool displayed;
	
	void Awake() {
		
		//Set level to 0
		PlayerPrefs.SetInt("currentLvl", 0);
		PlayerPrefs.SetInt("lives", 2);
		displayed = false;
		
		//Figuring out how to keep track of High scores..
		//re do this...
		//try to set make sure highscore starts at something and keep track of games played...s
		//gp = 0;
		PlayerPrefs.SetInt("gamesPlayed", (PlayerPrefs.GetInt("gamesPlayed") + 1) );
//		if (PlayerPrefs.GetInt("gamesPlayed") != gp)
//		{
//			PlayerPrefs.SetInt("highScore", 0);
//			PlayerPrefs.SetInt("gamePlayed", gp);
//		}PlayerPrefs.GetInt("gamesPlayed") != 0 && 
//		
		PlayerPrefs.SetInt("highScore", 10000);
//		if (PlayerPrefs.GetInt("highScore") > 0)
//		{
			HiScore.text = "Your High Score: " + PlayerPrefs.GetInt("highScore");
//		}
		
	}
	// Use this for initialization
	void Start () {
		InvokeRepeating("Blink", 1f, .5f);
	}
	
	void Blink()
	{
		displayed = !displayed;
		
		if (displayed)
			PlayButton.text = "Click to Play";
		else
			PlayButton.text = "";
	}
	// Update is called once per frame
	protected override void Update () 
	{
		
		
		base.Update();
		if(Input.GetMouseButton(0) )
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out rayCastHit) )
			{
				if (rayCastHit.transform.name == "creditsPLAY")
				{
					Application.LoadLevel("Credits");
				}
				else if (rayCastHit.transform.name == "newGamePLAY")
				{
					Application.LoadLevel("Level1");
					//s.NextLevel(1);
					
				}
			}
		}
		
		
	}
}
