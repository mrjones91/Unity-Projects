using UnityEngine;
using System.Collections;

public class CreditCamera : MonoBehaviour {

	private Vector3 fall;
	public TextMesh hudmessage, sig;
	// Use this for initialization
	void Start () {
		fall = gameObject.transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if ((gameObject.transform.position.y >= 50))
		{
			fall.y -= (Time.deltaTime * 3);
			gameObject.transform.position = fall;
		}
		else
		{
			GameObject.Destroy(GameObject.Find("KeyObject"));
		}
		//else
		{
			sig.text = "- Daniel Jones\nWayOfTheJones.blogspot.com";
			hudmessage.text = "Woo! Finished a game jam!\n& Thank you for playing!\nAll music from\nFacebook.com/NewAgeMusicGarden\nShout out to the chat room!";
		}

		if (Input.GetMouseButton(0) || Input.anyKeyDown )
		{
			Application.LoadLevel("Level 1");
		}
	}
}
