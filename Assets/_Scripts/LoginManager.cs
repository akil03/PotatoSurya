using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;


public class LoginManager : MonoBehaviour {
	FirebaseAuth auth;
	FirebaseUser user;
	public Text infoText1;

	public static LoginManager instance;

	void Awake () {
		instance = this;
		InitializeFirebase ();
		ManualInit ();
	
	}
	
	public void ManualInit(){

		if (!Application.isEditor) {
			LCGoogleLoginBridge.ChangeLoggingLevel (true);

			LCGoogleLoginBridge.InitWithClientID ("926983986077-ksdfj7dfaarpca31dfane3ag439kar3l.apps.googleusercontent.com");
			infoText1.text = "Manually Initialized".ToString ();
		} else {

			FirebaseCreate ("test", "test");
		}
	}


	public void SignInNormal(){
		Action<bool> logInCallBack = (Action<bool>)((loggedIn)=> {
			if(loggedIn){
				//PrintMessage("Google Login Success> " + LCGoogleLoginBridge.GSIUserName()); 
				infoText1.text = "logged in true".ToString();

				FirebaseCreate(LCGoogleLoginBridge.GSIEmail(),"123456");

			}

			else{
				infoText1.text = "logged in false".ToString();
			}	
		});

		LCGoogleLoginBridge.LoginUser (logInCallBack, false);
	}

	public void FirebaseCreate(string email, string password){
		infoText1.text = "firebase created".ToString();
		auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
			if (task.IsCanceled) {
				Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
				infoText1.text = "CreateUserWithEmailAndPasswordAsync was canceled.".ToString();
				return;
			}
			if (task.IsFaulted) {
				Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
				infoText1.text = "CreateUserWithEmailAndPasswordAsync encountered an error:".ToString();
				FirebaseSignIn(email,password);
				infoText1.text = "Logged into Firebase".ToString();

				return;
			}
			infoText1.text = "inside firebase".ToString();
			// Firebase user has been created.
			UIManager.instance.OpenPage(1);

			user = task.Result;
			Debug.LogFormat("Firebase user created successfully: {0} ({1})",
				user.DisplayName, user.UserId);
			infoText1.text = "Firebase user created successfully: {0} ({1})".ToString();
		});

	}

	public void FirebaseSignIn(string email, string password){
		auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
			if (task.IsCanceled) {
				Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
				infoText1.text = "SignInWithEmailAndPasswordAsync was canceled.".ToString();
				return;
			}
			if (task.IsFaulted) {
				Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
				infoText1.text = "SignInWithEmailAndPasswordAsync encountered an error: ".ToString();
				return;
			}

			UIManager.instance.OpenPage(1);
			user = task.Result;
			Debug.LogFormat("User signed in successfully: {0} ({1})",
				user.DisplayName, user.UserId);
			infoText1.text = "User signed in successfully: {0} ({1})".ToString();
		});

	}

	void InitializeFirebase() {
		auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
		//auth.StateChanged += AuthStateChanged;
		//AuthStateChanged(this, null);
	}

	void AuthStateChanged(object sender, System.EventArgs eventArgs) {
		if (auth.CurrentUser != user) {
			bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;
			if (!signedIn && user != null) {
				//DebugLog("Signed out " + user.UserId);
			}
			user = auth.CurrentUser;
			if (signedIn) {
				//DebugLog("Signed in " + user.UserId);
			//	displayName = user.DisplayName ?? "";
			//	emailAddress = user.Email ?? "";
			//	photoUrl = user.PhotoUrl ?? "";
			}
		}
	}
}
