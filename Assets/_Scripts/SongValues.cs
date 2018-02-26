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


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AssignValues(){
		TitleText.text = DatabaseManager.instance.songDetails.Title.ToString ();
		AlbumText.text = DatabaseManager.instance.songDetails.Album.ToString ();
		ArtistText.text = DatabaseManager.instance.songDetails.Artist.ToString ();
		URLText.text = DatabaseManager.instance.songDetails.ImgURL.ToString ();
	}
}
