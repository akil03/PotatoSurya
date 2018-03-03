using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeItem : MonoBehaviour {

	public DatabaseManager.ProgTime programTime;
	public Text TimeText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Assign(){
		TimeText.text = programTime.Time;
	}

	public void SetTime(int t){
		if (t == 0)
			SongManager.instance.isAM = true;
		else
			SongManager.instance.isAM = false;
	}
}
