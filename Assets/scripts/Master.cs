using UnityEngine;
using System.Collections;

public class Master : Enemy
{

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Translate (new Vector3(-1,0,0)*Time.deltaTime);
	}


	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag=="Obscale") {
			transform.Rotate (0, 180, 0);
		}
	}
}

