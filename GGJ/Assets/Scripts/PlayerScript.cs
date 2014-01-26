using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour 
{
	public GameObject player;
	private Vector3 move, startPos;
	public TextMesh hudmessage, score;
	//hudmessage has 30 character limit
	private int scor;
	public float time;
	public Light biglt;
	private bool fading;


	void Awake()
	{
		if (Application.loadedLevelName == "Darkness")
		{
			hudmessage.text = "........";
			Invoke("NullText", 5f);
		}
		PlayerPrefs.SetInt("LastKey", 0);
	}
	// Use this for initialization
	void Start () {
		move = new Vector3();
		startPos = player.transform.position;
		scor = 0;
		time = 15;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) )
		{
			move.z = -.1f;

		}
		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) )
		{
			move.x = .1f;
		}
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) )
		{
			move.z = .1f;
		}
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) )
		{
			move.x = -.1f;
		}
		player.transform.position += move;
		move = Vector3.zero;

		if (player.transform.position.y <= -60)
		{
			Application.LoadLevel("Darkness");
		}
		if (PlayerPrefs.GetInt("LastKey") == 1)
		{
			score.text = "∞";
		}
		else if (Application.loadedLevelName == "Level 2")
		{
			score.text = (int)time + " seconds";
		}
		else if (Application.loadedLevelName == "Credits")
		{
			score.text = "∞";
		}
		else
		{
			score.text = "∞";
		}

		time -= Time.deltaTime;
		if (time <= 0)
		{

			Application.LoadLevel("Darkness");
		}

		if (fading)
		{
			biglt.intensity -= .001f;
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.GetComponent<KeyScript>() != null)
		{
			hudmessage.text = col.gameObject.GetComponent<KeyScript>().message;
			if (col.gameObject.GetComponent<KeyScript>().type == 1)
			{
				fading = true;
				Invoke ("DarkLevel", 5f);
			}
			else if (col.gameObject.GetComponent<KeyScript>().type == 15)
			{
				Invoke("GameLevel", 2f);
			}
			else if (col.gameObject.GetComponent<KeyScript>().type == 3)
			{
				hudmessage.text = "You have " + scor + "/7 points.\nThanks for playing.";
				Invoke ("Credits", 2f);
			}
			else
			{
				scor ++;
				time += col.gameObject.GetComponent<KeyScript>().juice;
				col.gameObject.GetComponent<KeyScript>().flashing = null;
				Destroy(col.gameObject);
				Invoke ("NullText", 4f);

				if (col.gameObject.GetComponent<KeyScript>().type == 2)
				{
					PlayerPrefs.SetInt("LastKey", 1);
					time = int.MaxValue;
				}
			}
		}


	}

	void NullText()
	{
		hudmessage.text ="";
	}
	void GameLevel()
	{
		Application.LoadLevel("Level 2");
	}
	void DarkLevel()
	{
		Application.LoadLevel("Darkness");
	}
	void Credits()
	{
		Application.LoadLevel("Credits");
	}
}
