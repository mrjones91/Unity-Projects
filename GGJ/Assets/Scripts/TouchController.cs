using UnityEngine;
using System.Collections;

public class TouchController : MonoBehaviour {

	private Ray ray;
	private RaycastHit rayCastHit;

	public GameObject Key;
	public TextMesh message;
	private bool spell;
	private char[] letters;
	private float counter;
	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt("HasKey", 0);
		counter = 0;
		spell = false;
		letters = new char[13];
		letters[0] = '.';
		letters[1] = '.';
		letters[2] = '.';
		letters[3] = 'T';
		letters[4] = 'H';
		letters[5] = 'E';
		letters[6] = ' ';
		letters[7] = 'K';
		letters[8] = 'E';
		letters[9] = 'Y';
		letters[10] = '.';
		letters[11] = '.';
		letters[12] = '.';
	}
	
	// Update is called once per frame
	void Update () {
	
		/*if (spell)
		{
			if ( (int)counter < letters.Length)
			{
				counter += Time.deltaTime;
				message.text = message.text + letters[(int)counter];
			}
		}*/

		if (Input.GetMouseButton(0) )
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast (ray, out rayCastHit) )
			{
				if (rayCastHit.transform.name == "KeyObject")
				{
					//message.text = "...THE KEY...";
					spell = true;
					InvokeRepeating("Spell", .5f, 1f);
					PlayerPrefs.SetInt("HasKey", 1);
					Destroy (Key);
				}

				if (rayCastHit.transform.name == "Door")
				{
					if (PlayerPrefs.GetInt("HasKey") == 1)
					{
						Application.LoadLevel("Level 2");
					}
				}
			}
		}
	}

	void Spell()
	{
		message.text = message.text + letters[(int)counter];
		counter++;
		if (counter == 6)
		{
			message.text = message.text + letters[(int)counter];
			counter = 7;
		}
		if (counter == 13)
		{
			CancelInvoke("Spell");
		}
	}
}
