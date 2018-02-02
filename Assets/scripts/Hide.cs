using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Mario") {
			GetComponent<BoxCollider2D> ().isTrigger = true;
		}
	}



	public void OnTriggerExit2D(Collider2D col){
		GetComponent<BoxCollider2D> ().isTrigger = false;
	}
}
