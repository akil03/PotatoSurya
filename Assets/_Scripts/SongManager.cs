using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongManager : MonoBehaviour {

	public List<SongItem> SongText;

	public static SongManager instance;
	// Use this for initialization
	void Awake(){
		instance = this;	
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AssignValuesAM(){
		
	}

	public void AssignValuesPM(){

	}
}
