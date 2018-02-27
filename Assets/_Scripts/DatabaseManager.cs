using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using Newtonsoft.Json;


public class DatabaseManager : MonoBehaviour {

	string JsonValue;
	public AppData _AppData;
	public GameObject SongTemplate_prefab;
	public List<Song> ListSong;

	public static DatabaseManager instance = null;

	void Awake(){
		instance = this;	
	}

	void Start () {
		_AppData = new AppData ();

		FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://potatosuryamusic-1519224169380.firebaseio.com/");
		FirebaseApp.DefaultInstance.SetEditorP12FileName("potatosuryamusicapp-e6866a9d36d0.p12");
		FirebaseApp.DefaultInstance.SetEditorServiceAccountEmail("unityeditortest@potatosuryamusic-1519224169380.iam.gserviceaccount.com");
		FirebaseApp.DefaultInstance.SetEditorP12Password("notasecret");

		InitializeFirebase ();
	}

	void Update () {
		
	}

	public void InitializeFirebase(){
		DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

		FirebaseDatabase.DefaultInstance.GetReference ("AppData").GetValueAsync().ContinueWith(task =>{
			if(task.IsFaulted){
				Debug.Log("Task failed");
			}else if(task.IsCompleted){
				DataSnapshot snapshot = task.Result;
				JsonValue = snapshot.GetRawJsonValue ();
				print(JsonValue);
				SaveAppData(JsonValue);
				//_AppData = JsonUtility.FromJson<AppData>(JsonValue);

			}
		});
	}




	public void SaveAppData(string JsonValue){
		var Programmes = JsonConvert.DeserializeObject<Dictionary<string, object>> (JsonValue);
		for (int i = 0; i < Programmes.Count; i++) {
			Programme _Programme = new Programme ();
			_Programme.Name = Programmes.ElementAt (i).Key.ToString ();

			var ProgrammeDates = JsonConvert.DeserializeObject<Dictionary<string, object>> (Programmes.ElementAt(i).Value.ToString());
			for (int j = 0; j < ProgrammeDates.Count; j++) {
				ProgDate _ProgrammeDate = new ProgDate ();
				_ProgrammeDate.Date = ProgrammeDates.ElementAt (j).Key.ToString ();
				var ProgrammeTimes = JsonConvert.DeserializeObject<Dictionary<string, object>> (ProgrammeDates.ElementAt(j).Value.ToString());
				for (int k = 0; k < ProgrammeTimes.Count; k++) {
					ProgTime _ProgrammeTime = new ProgTime ();
					_ProgrammeTime.Time = ProgrammeTimes.ElementAt (k).Key.ToString ();
					var SongList = JsonConvert.DeserializeObject<Dictionary<string, object>> (ProgrammeTimes.ElementAt(k).Value.ToString());
					for (int l = 0; l< SongList.Count; l++) {
						Song _Song = new Song ();
						var songData = JsonConvert.DeserializeObject<Dictionary<string,string>> (SongList.ElementAt(l).Value.ToString()); 

						_Song.Title = songData.Where (a=>a.Key.Contains("Title")).First().Value.ToString();
						_Song.Album = songData.Where (a=>a.Key.Contains("Album")).First().Value.ToString();
						_Song.Artist = songData.Where (a=>a.Key.Contains("Artist")).First().Value.ToString();
						_Song.ImgURL = songData.Where (a=>a.Key.Contains("URL")).First().Value.ToString();
						_ProgrammeTime.Songlist.Add (_Song);
					}
					CreateSongs (ListSong, SongTemplate_prefab);
					_ProgrammeDate.Timelist.Add(_ProgrammeTime);
				}
				_Programme.Datelist.Add (_ProgrammeDate);
			}
			//CreateSongs (ListDate);
			_AppData.ProgrammeList.Add (_Programme);
		}

	}


	public void CreateSongs(List<Song> ListSg, GameObject template){

		foreach (Song sg in ListSg) {
			GameObject _song = Instantiate (template);
			//_song.transform.SetParent (template.transform);
			_song.GetComponent<SongValues> ().TitleText.text = sg.Title;
			_song.GetComponent<SongValues> ().AlbumText.text = sg.Album;
			_song.GetComponent<SongValues> ().ArtistText.text = sg.Artist;
			_song.GetComponent<SongValues> ().URLText.text = sg.ImgURL;
			//_song.GetComponent<SongValues> ().AssignValues ();

		}

	}


//	public GameObject _song;
//	public void CreateSongs(List<ProgDate> ListDate){
//		foreach (ProgDate PD in ListDate) {
//			foreach(ProgTime PT in PD.Timelist){
//				foreach (Song sg in PT.Songlist) {
//					_song = Instantiate (SongTemplate_prefab);
//					_song.GetComponent<SongValues> ().TitleText.text = sg.Title;
//					_song.GetComponent<SongValues> ().AlbumText.text = sg.Album;
//					_song.GetComponent<SongValues> ().ArtistText.text = sg.Artist;
//					_song.GetComponent<SongValues> ().URLText.text = sg.ImgURL;
//					_song.GetComponent<SongValues> ().AssignValues ();
//				}
//			}
//		}
//	}



	[System.Serializable]
	public class AppData {
		public List<Programme> ProgrammeList = new List<Programme>();


	}

	[System.Serializable]
	public class Programme{
		public string Name;
		public List<ProgDate> Datelist = new List<ProgDate> ();
	}


	[System.Serializable]
	public class ProgDate{
		public string Date;
		public List<ProgTime> Timelist = new List<ProgTime> ();
	}

	[System.Serializable]
	public class ProgTime{
		public string Time;
		public List<Song> Songlist = new List<Song> ();
	}

	[System.Serializable]
	public class Song{
		public string Title,Artist,Album,ImgURL;
	}

}
