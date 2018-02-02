using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Over : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	/***按钮 PlayAgain 点击 ***/
	public void OnPlayAgainClick(){
		SceneManager.LoadScene ("Main");
	}


	/****按钮 quit点击***/
	public void OnQuitClick(){
		Application.Quit ();
	}

}
