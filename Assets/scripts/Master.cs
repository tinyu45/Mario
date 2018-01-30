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
		transform.parent.Translate (new Vector3(-1,0,0)*Time.deltaTime);
	}



	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag=="Obscale") {
			transform.parent.Rotate (0, 180, 0);
		}
	}
}

