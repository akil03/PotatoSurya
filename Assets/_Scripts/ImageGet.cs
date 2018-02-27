using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ImageAndVideoPicker;

public class ImageGet : MonoBehaviour {

	void OnEnable()
	{
		PickerEventListener.onImageSelect += OnImageSelect;
		PickerEventListener.onCancel += OnCancel;
	}

	void OnDisable()
	{
		PickerEventListener.onImageSelect -= OnImageSelect;
		PickerEventListener.onCancel -= OnCancel;
	}

	public void OnImageSelect(string imgPath, ImageAndVideoPicker.ImageOrientation imgOrientation){
		Debug.Log ("Image Location : "+imgPath);
		AndroidPicker.BrowseImage (true,1,1);
	}

	public void OnCancel(){
		Debug.Log ("Cancel by user");
	}


}
