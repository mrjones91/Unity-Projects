using UnityEngine;
using System.Collections;

public class RtBehaviour : MonoBehaviour {
	
	public GUIText GuiScore;
	public GUIText GuiHighScore;
	
	public BlockGame game;
	public ScoreScript score;
	public PaddleMovement paddle;
	protected PowerUpController powerUp;
	protected BrickScript brick;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
