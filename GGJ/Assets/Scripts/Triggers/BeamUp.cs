using UnityEngine;
using System.Collections;

public class BeamUp : MonoBehaviour {

	public Light beamLight, overLight;
	public GameObject player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (beamLight.range >= 28)
		{
			overLight.intensity -= .001f;
		}
		if (overLight.intensity <= .01)
		{
			Application.LoadLevel("Credits");
		}
		if (collider.bounds.Intersects(player.collider.bounds))
		{
			beamLight.range += (Time.deltaTime * 2);
		}
	
	}
	void OnCollisionEnter(Collision col)
	{
		//if (col.gameObject.GetComponent<PlayerScript>())
		{

		}
	}
}
