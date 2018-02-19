using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;

public class AuthScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
