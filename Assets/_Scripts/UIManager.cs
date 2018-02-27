using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DoozyUI;

public class UIManager : MonoBehaviour {

	public UIElement[] Page;

	public static UIManager instance;

	void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OpenPage(int pageNo){

		ClosePages ();
		Page [pageNo].gameObject.SetActive (true);
		Page [pageNo].Show (false);

	}

	public void ClosePages(){
		foreach (UIElement ue in Page) {
			ue.gameObject.SetActive (false);
		}
	
	}
}
