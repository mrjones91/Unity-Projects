using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	private Vector3 distance;
	public GameObject player;
	// Use this for initialization
	void Start () {
		distance = new Vector3(0f, 8f, -2f);
	}
	
	// Update is called once per frame
	void LateUpdate () {
		gameObject.transform.position = player.transform.position + distance;
	}
}
