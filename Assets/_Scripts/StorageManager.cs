using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Storage;
using Newtonsoft.Json;

public class StorageManager : MonoBehaviour {

	public AppRequest _AppRequest;
	public string emailText;
	public Text messageText;
	public Text locationText;

	void Start () {
		_AppRequest = new AppRequest ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SubmitData(){
		DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

		reference.Child (emailText).Child (LCGoogleLoginBridge.GSIEmail())
			.SetRawJsonValueAsync (JsonConvert.SerializeObject (_AppRequest));
		reference.Child (messageText.text).Child (_AppRequest.message)
			.SetRawJsonValueAsync (JsonConvert.SerializeObject (_AppRequest));
		reference.Child (locationText.text).Child (_AppRequest.location)
			.SetRawJsonValueAsync (JsonConvert.SerializeObject (_AppRequest));


		StorageReference storage = FirebaseStorage.DefaultInstance.RootReference;
		Firebase.Storage.StorageReference img_ref = storage.Child("UserImages/user.jpg");

		ImageGet.instance.imgTex.GetRawTextureData ();

		img_ref.PutBytesAsync(ImageGet.instance.imgTex.GetRawTextureData ())
			.ContinueWith ((System.Threading.Tasks.Task<StorageMetadata> task) => {
				if (task.IsFaulted || task.IsCanceled) {
					Debug.Log(task.Exception.ToString());
				} else {
					Firebase.Storage.StorageMetadata metadata = task.Result;
					string download_url = metadata.DownloadUrl.ToString();
					Debug.Log("Finished uploading...");
					Debug.Log("download url = " + download_url);
				}
			});
	}


	[System.Serializable]
	public class AppRequest{
		public string email, message, location;
	}

}
