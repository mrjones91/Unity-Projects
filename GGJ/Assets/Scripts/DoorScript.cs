using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

	public GameObject player, door;
	private Vector3 up;
	void Start () {
		up = new Vector3(0f, .05f, 0f);
	
	}
	
	// Update is called once per frame
	void Update () {
		if (player.collider.bounds.Intersects(this.collider.bounds))
		{
			door.transform.position += up;
		}
	}
}
