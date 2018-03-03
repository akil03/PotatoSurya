using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {

	public List<TimeItem> TimeInfo;

	public static TimeManager instance;
	// Use this for initialization
	void Awake(){
		instance = this;
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
