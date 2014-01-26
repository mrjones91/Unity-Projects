using UnityEngine;
using System.Collections;

public class KeyScript : MonoBehaviour {

	public Light flashing;
	private bool lighty;

	public string message;
	public int type, m, juice;
	// Use this for initialization
	void Start () {
		string [] messages = new string[30];
		//hudmessage has 30 character limit
		messages[0] = "A family photo!\nEveryone seems so Lively!";
		messages[1] ="The book shelf looks neatly organized\nSo many subjects!";
		messages[2] ="A letter from your mentor\nMaybe you can be as wise one day";
		messages[3] ="A picture from your\nsignificant other :)";
		messages[4] ="Your dumbbells and running\nshoes look lonely...";
		messages[5] ="Your favorite Sci Fi movie!\nWhere will you boldly go?";
		messages[6] ="Do you Understand who you are?\nWhat Will you do?";
		messages[7] = "All that glitters...\nisn't gold";
		messages[8] ="Tricky trinkets take\ntoo much time";
		messages[9] ="Lost your way?";
		messages[10] ="You've met with a terrible fate,\nhaven't you?";
		messages[11] ="This is not the droid\nyou're looking for";
		messages[12] ="Sorry, hero,\nthe princess is in another castle!";
		messages[13] ="Life's a *****\nand then you die";
		messages[14] ="GAME OVER";
		messages[15] = "Escape the darkness\nFind your light!";
		message = messages[m];
	}
	
	// Update is called once per frame
	void Update () {
	
		if (flashing != null)
		{
			if (!lighty)
			{
				flashing.range += .15f;
			}
			else if (lighty)
			{
				flashing.range -= .15f;
			}
			
			if (flashing.range >= 5)
			{
				lighty = true;
			}
			else if (flashing.range <= 0)
			{
				lighty = false;
			}
		}
	}
}
