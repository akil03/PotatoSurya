using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateManager : MonoBehaviour {

	public Text currentDate;
	// Use this for initialization
	void Start () {
		DisplayDate ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DisplayDate() {
		currentDate.text = System.DateTime.Now.ToString ("M");
		print (currentDate.text);
		//var future : Date = date.AddDays(6);
		//currentDate.text = System.DateTime.Today.AddDays(6);

	}
}
