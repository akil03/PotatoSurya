using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateManager : MonoBehaviour {

	public List<Text> DateText;
	// Use this for initialization
	void Start () {
		DateText [0].text = System.DateTime.Now.ToString ("M");
		DisplayDate ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DisplayDate() {
		int daycount = 1;
		for(int i=1; i<DateText.Count; i++){
			
			DateText [i].text = System.DateTime.Now.ToString ("M");
			DateText [i].text = System.DateTime.Now.AddDays (daycount).ToString ("M");
			daycount += 1;
			}
				
			//var future : Date = date.AddDays(6);
			//currentDate.text = System.DateTime.Today.AddDays(6);
	}
}
