using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadFlower : MonoBehaviour {
	float timer=0;
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if (timer < 6) {
			timer += Time.deltaTime;
			if (timer<= 3) {
				//transform.Translate (new Vector3 (0, 0.2f, 0) * Time.deltaTime);
				transform.Translate(new Vector3(0, 0.5f, 0)*Time.deltaTime);
				if (transform.position.y > -2.6f) {
					transform.position = new Vector3 (transform.position.x, -2.6f, 0);
				}
			} else {
				transform.Translate(new Vector3(0, -0.5f, 0)*Time.deltaTime);
				if (transform.position.y < -4) {
					transform.position = new Vector3 (transform.position.x, -4f, 0);
				}
			}
		} else {
			timer = 0;
		} 
	}
}
