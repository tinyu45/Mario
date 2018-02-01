using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour {
	public GameObject flag;
	bool success;
	void Start () {
		success = false;
	}


	void Update () {
		if (success) {
			if (flag.transform.localPosition.y > -2f) {
				flag.transform.localPosition -= new Vector3 (0, 1f, 0) * Time.deltaTime;
			} else {
				GetComponent<BoxCollider2D> ().enabled = false;
			}
		}
	}



	public void OnCollisionEnter2D(Collision2D col){
		success = true;
	}
}
