using UnityEngine;
using System.Collections;

public class Mario : MonoBehaviour
{
	/***游戏结束***/
	float OverHeight = -10; 
	int life;
	public static int score;


	/***
	 * 主相机相关***
	 * ***/
	private Transform mainCT; //主相机
	float mc_Min_X=0;
	float mc_Max_x=248;
	private bool follow=false; //是否跟随
	float offset_y;  //偏移量



	/***
	 * 跳跃相关
	 * ***/
	private float jumpForce=220;  //跳跃力
	int jcount;
	float jtimer;


	void Start ()
	{
		mainCT = Camera.main.transform;
		jcount = 0;
		jtimer = 0;
		life = 3;
		score = 0;
	}


	void Update ()
	{
		Animator ani = GetComponent<Animator> ();
		if (Input.GetKey (KeyCode.LeftArrow)) {
			if (!ani.GetBool ("jump")) {
				ani.SetBool ("move", true);
			}
			if (transform.rotation == Quaternion.identity) {
				transform.Rotate (new Vector3 (0, 180, 0));
			}
		}
			
		if (Input.GetKey (KeyCode.RightArrow)) {
			if (!ani.GetBool ("jump")) {
				ani.SetBool ("move", true);
			}
			if (transform.rotation != Quaternion.identity) {
				transform.rotation = Quaternion.identity;
			}
		}




		/**跳跃***/
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (jcount <3) { //最多跳三次 
				GetComponent<Rigidbody2D> ().AddForce (new Vector2(0, jumpForce));
				jcount++;
			}
		}

		if (jcount != 0) {
			jtimer += Time.deltaTime;
		} 
			
		if (Input.GetKey (KeyCode.Space)) {
			ani.SetBool ("jump", true);
		}


		if (Input.GetKeyUp (KeyCode.Space)) {
			ani.SetBool ("jump", false);
			if (jtimer > 3f) {
				jcount = 0;
				jtimer = 0;
			}
		}




		/***蹲下***/
		if (Input.GetKey (KeyCode.DownArrow)) {
			ani.SetBool ("down", true);
			//GetComponent<BoxCollider2D>().
		}

		if (Input.GetKeyUp (KeyCode.DownArrow)) {
			ani.SetBool ("down", false);
		}




		//左键 或 右键抬起
		if (Input.GetKeyUp (KeyCode.LeftArrow) || Input.GetKeyUp (KeyCode.RightArrow)) {
			ani.SetBool ("move", false);
		}

		if (ani.GetBool ("move")) {
			transform.Translate(new Vector3 (3, 0, 0) * Time.deltaTime);  //Mario Move
		}

		if (transform.position.x >= 0 && !follow) {
			follow = true;
		}
		CamerFllow ();



		/***判断游戏结束***/
		if (transform.position.y < OverHeight) {
			print ("GAME OVER");
		}

	}



	/*****/
	public void OnCollisionEnter2D(Collision2D col){
		//print (col.gameObject.name);  //BadFlower / Monster
		switch(col.gameObject.tag){
		case "BadFlower":
			this.life--;  //食人花
			break;


		case "Monster":
			if (score > 3) {
				score -= 3;
			} else {
				this.life -= 1;
			}
			break;

		case "MonsterTop":
			//print (col.transform.parent.name);
			Destroy (col.transform.parent.gameObject);
			break;


		default:break;
		}
	}









	//主相机跟随
	void CamerFllow(){
		if(follow){
			if (transform.position.y > mainCT.position.y + 3.3f) {
				offset_y += 1.2f * Time.deltaTime;
				mainCT.position = new Vector3 (transform.position.x, mainCT.position.y + offset_y, -10);
			} else {
				if (transform.position.y < mainCT.position.y - 1.3f) {
					offset_y -= 1.2f * Time.deltaTime;
					mainCT.position = new Vector3 (transform.position.x, mainCT.position.y +offset_y, -10);
				} else {
					offset_y = 0;
					mainCT.position = new Vector3 (transform.position.x,mainCT.position.y, -10);
				}
			}

		}
	}


}

