using UnityEngine;
using System.Collections;

public class Mario : MonoBehaviour
{
	private Transform mainCT; //主相机
	private bool follow=false;

	private float jumpForce=150;  //跳跃力


	void Start ()
	{
		mainCT = Camera.main.transform;
	}


	void Update ()
	{
		Animator ani = GetComponent<Animator> ();
		if (Input.GetKey (KeyCode.LeftArrow)) {
			ani.SetBool ("move", true);
			if (transform.rotation == Quaternion.identity) {
				transform.Rotate (new Vector3 (0, 180, 0));
			}
		}
			
		if (Input.GetKey (KeyCode.RightArrow)) {
			ani.SetBool ("move", true);
			if (transform.rotation != Quaternion.identity) {
				transform.rotation = Quaternion.identity;
			}
		}

		/**跳跃***/
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			GetComponent<Rigidbody2D> ().AddForce (new Vector2(0, jumpForce));
			ani.SetBool ("move", false);
			ani.SetBool ("jump", true);
		}
			
		if (Input.GetKey (KeyCode.UpArrow)) {
			

		}

		if (Input.GetKeyUp (KeyCode.UpArrow)) {
			ani.SetBool ("jump", false);
		}


		/***蹲下***/
		if (Input.GetKey (KeyCode.DownArrow)) {
			ani.SetBool ("down", true);
		}

		if (Input.GetKeyUp (KeyCode.DownArrow)) {
			ani.SetBool ("down", false);
		}




		//左键 或 右键抬起
		if (Input.GetKeyUp (KeyCode.LeftArrow) || Input.GetKeyUp (KeyCode.RightArrow)) {
			ani.SetBool ("move", false);
		}

		if (ani.GetBool ("move")) {
			transform.Translate(new Vector3 (2, 0, 0) * Time.deltaTime);
		}

		if (transform.position.x >= 0 && !follow) {
			follow = true;
		}

		CamerFllow ();
	}



	//主相机跟随
	void CamerFllow(){
		if(follow){
			mainCT.position = new Vector3 (transform.position.x, mainCT.position.y, -10);
		}
	}
}

