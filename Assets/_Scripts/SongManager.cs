using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongManager : MonoBehaviour {
	
	public DatabaseManager.ProgDate selectedDate;
	public bool isAM = true;
	public List<DatabaseManager.Song> SongInfo;

	public static SongManager instance;

	public GameObject SongPrefab;
	public Transform songContainer;
	// Use this for initialization
	void Awake(){
		instance = this;	
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AssignList(){
		SongInfo.Clear ();
		ClearSongContainer ();

		if (isAM) {
			foreach (DatabaseManager.Song S in selectedDate.Timelist[0].Songlist) {
				SongInfo.Add (S);
				AddSong (S);
			}
		} else {
			foreach (DatabaseManager.Song S in selectedDate.Timelist[1].Songlist) {
				SongInfo.Add (S);
				AddSong (S);
			}
		}


	}

	void AddSong(DatabaseManager.Song S){
		GameObject GO = Instantiate (SongPrefab, songContainer);
		SongPrefab.GetComponent<SongItem> ().songDetail = S;

		SongPrefab.GetComponent<SongItem> ().Assign ();
	}

	void ClearSongContainer(){

		foreach (Transform Child in songContainer)
			Destroy (Child.gameObject);
	}
		
}
