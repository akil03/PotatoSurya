using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateItem : MonoBehaviour {

	public DatabaseManager.ProgDate programDate;
	public Text Dateinfo;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Assign(){
		Dateinfo.text = programDate.Date;
	}

}
