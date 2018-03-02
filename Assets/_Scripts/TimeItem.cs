using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeItem : MonoBehaviour {

	public DatabaseManager.ProgTime programTime;
	public Text Timeinfo;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Assign(){
		Timeinfo.text = programTime.Time;
	}
}
