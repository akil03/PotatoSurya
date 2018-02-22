using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Unity.Editor;

public class DatabaseManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://potatosuryamusic-1519224169380.firebaseio.com/");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
