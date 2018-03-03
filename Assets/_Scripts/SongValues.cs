using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SongValues : MonoBehaviour {

	public Text TitleText;
	public Text AlbumText;
	public Text ArtistText;
	public Text URLText;
	public DatabaseManager.Song songDetail;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AssignValues(){
		TitleText.text = songDetail.Title;
		AlbumText.text = songDetail.Album;
		ArtistText.text = songDetail.Artist;

	}
}
