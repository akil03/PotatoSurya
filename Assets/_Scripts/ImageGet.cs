using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ImageAndVideoPicker;

public class ImageGet : MonoBehaviour {

	public Texture2D imgTex;

	public static ImageGet instance;

	void Awake(){
		instance = this;
	}
	void OnEnable()
	{
		PickerEventListener.onImageSelect += ImageSelect;
		PickerEventListener.onImageLoad += ImageLoad;
		PickerEventListener.onError += Error;
		PickerEventListener.onCancel += Cancel;
	}

	void OnDisable()
	{
		PickerEventListener.onImageSelect -= ImageSelect;
		PickerEventListener.onImageLoad -= ImageLoad;
		PickerEventListener.onError -= Error;
		PickerEventListener.onCancel -= Cancel;
	}

	void ImageSelect(string imgPath, ImageAndVideoPicker.ImageOrientation imgOrientation)
	{
		Debug.Log ("Image Location : "+imgPath);

	}


	void ImageLoad(string imgPath, Texture2D tex, ImageAndVideoPicker.ImageOrientation imgOrientation)
	{
		Debug.Log ("Image Location : "+imgPath);
		imgTex = tex;

	}

	void Error(string errorMsg)
	{
		Debug.Log ("Error : "+errorMsg);

	}

	void Cancel()
	{
		Debug.Log ("Cancel by user");

	}

	public void SelectPicture(){
		#if UNITY_ANDROID
		AndroidPicker.BrowseImage(true);
		#elif UNITY_IPHONE
		IOSPicker.BrowseImage(true); // true for pick and crop
		#endif
	}
}
