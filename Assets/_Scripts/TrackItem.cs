﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackItem : MonoBehaviour {

	public Text TrackTitleText;
	public Text TrackAlbumText;
	public Text TrackArtistText;
	public Text TrackYearText;
	public Text TrackMusicDirText;
	public Text TrackLyricistText;

	public static TrackItem instance;

	// Use this for initialization
	void Awake(){
		instance = this;
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
