using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;


public class DatabaseManager : MonoBehaviour {

	string JsonValue;


	// Use this for initialization
	void Start () {
		
		FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://potatosuryamusic-1519224169380.firebaseio.com/");
		FirebaseApp.DefaultInstance.SetEditorP12FileName("potatosuryamusicapp-e6866a9d36d0.p12");
		FirebaseApp.DefaultInstance.SetEditorServiceAccountEmail("unityeditortest@potatosuryamusic-1519224169380.iam.gserviceaccount.com");
		FirebaseApp.DefaultInstance.SetEditorP12Password("notasecret");

		InitializeFirebase ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void InitializeFirebase(){
		DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

		FirebaseDatabase.DefaultInstance.GetReference ("RetrieveSide").GetValueAsync().ContinueWith(task =>{
			if(task.IsFaulted){
				Debug.Log("Task failed");
			}else if(task.IsCompleted){
				DataSnapshot snapshot = task.Result;
				JsonValue = snapshot.GetRawJsonValue ();
				print(JsonValue);
				RetrieveSide retreiveValue = JsonUtility.FromJson<RetrieveSide>(JsonValue);

			}
		});
	}

	public void SaveDateData(string Jsonvalue){
		//JsonUtility.ToJson<RetrieveSide> (JsonValue);
	}


	[System.Serializable]
	public class RetrieveSide {
		public string Prog_name;
		public List<Prog_Date> Datelist = new List<Prog_Date> ();

//		public static RetrieveSide CreateFromJSON(string jsonString){
//			return JsonUtility.FromJson<RetrieveSide> (jsonString);
//		}
	}

	[System.Serializable]
	public class Prog_Date{
		public List<Prog_Time> Timelist = new List<Prog_Time> ();
	}

	[System.Serializable]
	public class Prog_Time{
		public List<Songs> Songlist = new List<Songs> ();
	}

	[System.Serializable]
	public class Songs{
		public string songName;
	}

}
