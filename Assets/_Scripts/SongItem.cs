using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongItem : MonoBehaviour {

	public Text TitleText;
	public Text AlbumText;
	public Text ArtistText;
	public Text YearText;
	public Text MusicDirText;
	public Text LyricistText;
	public DatabaseManager.Song songDetail;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
		
	public void Assign(){
		TitleText.text = songDetail.Title;
		AlbumText.text = songDetail.Album;
		ArtistText.text = songDetail.Artist;
		YearText.text = songDetail.Year;
		MusicDirText.text = songDetail.MusicDir;
		LyricistText.text = songDetail.Lyricist;
	
	}

	public void OpenSubmitPage(){
		UIManager.instance.OpenPage (4);
	}

	public void AssignTrackvalue(){
		TrackItem.instance.TrackTitleText.text = TitleText.text;
		TrackItem.instance.TrackAlbumText.text = AlbumText.text;
		TrackItem.instance.TrackArtistText.text = ArtistText.text;
		TrackItem.instance.TrackYearText.text = YearText.text;
		TrackItem.instance.TrackMusicDirText.text = MusicDirText.text;
		TrackItem.instance.TrackLyricistText.text = LyricistText.text;
	}
}
