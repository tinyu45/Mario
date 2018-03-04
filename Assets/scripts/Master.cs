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



	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Obscale") {
			transform.parent.Rotate (0, 180, 0);
		} else {
			if (col.gameObject.tag == "BadFlower" || col.gameObject.tag == "Monster") {//
				this.GetComponent<BoxCollider2D> ().isTrigger = true;
			}
		}
	}


	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.tag == "BadFlower" || col.gameObject.tag == "Monster") {
			this.GetComponent<BoxCollider2D> ().isTrigger = false;
		}
	}
}

