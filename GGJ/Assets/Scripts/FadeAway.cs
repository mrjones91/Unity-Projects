using UnityEngine;
using System.Collections;

public class FadeAway : MonoBehaviour {

	public GameObject player;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.light.range -= Time.deltaTime;
		//if (gameObject.light.range <= 0)
		if (player.GetComponent<PlayerScript>().time <= 0)
		{
			player.GetComponent<PlayerScript>().hudmessage.text = "You were lost\nin your own\ndarkness....";
			Invoke("Level2", 5f);
		}
	}

	void Level2()
	{
		Application.LoadLevel("Level 2");
	}
}
