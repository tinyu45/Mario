using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Mario : MonoBehaviour
{
	//游戏UI相关
	public Text time;
	public Text scotext;
	public Text lifebox;
	float timego;//计时器
	bool canMove;


	/***游戏结束***/
	float OverHeight = -10; 
	int life;
	bool meetFlower;
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
	Animator ani;

	void Start ()
	{
		mainCT = Camera.main.transform;
		jcount = 0;
		jtimer = 0;
		life = 5;
		score = 0;
		timego = 0;
		meetFlower = false;
		canMove = true;
		UpdateUI ();
		ani = GetComponent<Animator> ();
	}


	void Update ()
	{
		if (canMove) {
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
					AudioManger.Instance.PlaySound ("Sounds/jump");
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
				GetComponent<Rigidbody2D> ().gravityScale = 0;  //去除碰撞器 关闭重力
				GetComponent<BoxCollider2D> ().enabled=false;
			}

			if (Input.GetKeyUp (KeyCode.DownArrow)) {
				ani.SetBool ("down", false);
				GetComponent<Rigidbody2D> ().gravityScale = 1;  //去除碰撞器 关闭重力
				GetComponent<BoxCollider2D> ().enabled=true;
			}




			//左键 或 右键抬起
			if (Input.GetKeyUp (KeyCode.LeftArrow) || Input.GetKeyUp (KeyCode.RightArrow)) {
				ani.SetBool ("move", false);
			}

			if (ani.GetBool ("move")) {
				transform.Translate(new Vector3 (4, 0, 0) * Time.deltaTime);  //Mario Move
			}

			if (transform.position.x >= 0 && !follow) {
				follow = true;
			}

		}

		CamerFllow ();

		UpdateUI ();

		/***判断游戏结束***/
		if (transform.position.y < OverHeight || this.life<=0) {
			print ("GAME OVER");
			SceneManager.LoadScene("Over");
		}

	}



	/*****/
	public void OnCollisionEnter2D(Collision2D col){
		//print (col.gameObject.name);  //BadFlower / Monster
		switch(col.gameObject.tag){

		case "Untagged":
			meetFlower=false;
			break;

		case "BadFlower":
			if (!meetFlower) {
				meetFlower = true;
				this.life--; 
				//食人花
			}
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

		case "Coin": //金币
			score++;
			Destroy (col.gameObject);
			break;

		case "END": //终点塔
			canMove = false;
			ani.SetBool ("move", false);
			ani.SetBool ("jump", false);
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


	//更新UI
	void UpdateUI(){
		timego += Time.deltaTime;
		string str = string.Format ("{0:00}:{1:00}",(int)(timego/60),(int)(timego%60));
		time.text = str;
		scotext.text="Score："+score;
		lifebox.text="Life："+life;
	}


}

