﻿using UnityEngine;
using System.Collections;

public class MusicPlayer : RtBehaviour {

	public AudioClip[] songs;
	public AudioSource music;
	public bool playing;

	private int songN;
	private float place;

	void Awake()
	{
		if (PlayerPrefs.GetInt("Music") == 1)
		{
			playing = true;
		}
		else
			playing = false;

	}

	// Use this for initialization
	void Start () {
		//soGlad, shabba, funk, feds, lala, mix, party;
		if (playing)
		{
			songN = 0;
			music.clip = songs[songN];
			music.Play();
		}

	}
	protected override void Update()
	{
		if (PlayerPrefs.GetInt("Music") == 1)
		{
			playing = true;
		}
		else
		{
			playing = false;
		}

		if (playing)
		{
			if (music.clip = songs[songN])
			{
				if (!music.isPlaying)
				{
					songN++;
					if (songN > songs.Length - 1)
					{
						songN = 0;
					}
					music.clip = songs[songN];
					music.Play();
				}
			}
		}
		else if (!playing)
		{
			music.Stop();
		}
	}


	

}
