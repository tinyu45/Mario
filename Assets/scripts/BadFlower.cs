using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadFlower : MonoBehaviour {
	float timer=0;
	// Use this for initialization
	void Start () {
//		print (transform.localPosition.y);
	}

	// Update is called once per frame
	void Update () {
		if (timer < 6) {
			timer += Time.deltaTime;
			if (timer<= 3) {
				//transform.Translate (new Vector3 (0, 0.2f, 0) * Time.deltaTime);
				transform.Translate(new Vector3(0, 0.5f, 0)*Time.deltaTime);
				if (transform.localPosition.y >1) {
					transform.localPosition= new Vector3 (transform.localPosition.x, 1, 0);
				}
			} else {
				transform.Translate(new Vector3(0, -0.5f, 0)*Time.deltaTime);
				if (transform.localPosition.y < -0.3f) {
					transform.localPosition = new Vector3 (transform.localPosition.x, -0.3f, 0);
				}
			}
		} else {
			timer = 0;
		} 
	}
}
