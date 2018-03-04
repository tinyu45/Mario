using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioTop : MonoBehaviour {

	/**贴图***/
	public Sprite[] txuers; 



	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (transform.parent.position.x, transform.parent.position.y + 0.3f, 0);
	}


	/***碰撞检测***/
	public void OnCollisionEnter2D(Collision2D col){
		switch(col.gameObject.tag){
		case "Magic": //神奇的?号
			GameObject magic = col.gameObject;
			magic.GetComponent<SpriteRenderer> ().sprite = txuers [0]; //换为普通砖块图片
			break;


		case "Brick": //普通砖块
			Destroy(col.gameObject);
			break;


		case "Hide":  //隐藏块
			GameObject Hide = col.gameObject;
			Hide.GetComponent<SpriteRenderer> ().sprite = txuers [1]; //换为硬砖块图片
			break;


		default:break;
		}
	}




	/*****/
	public void OnCollisionExit2D(Collision2D col){
		//print (col.gameObject.name);  //BadFlower / Monster
		switch(col.gameObject.tag){

		case "Magic": //神奇的?号
			col.gameObject.tag = "Brick";
			Mario.score ++;
			break;


		case "Brick": //普通砖块

			break;

		case "Hide": //隐藏块
			col.gameObject.tag="Hard";
			break;
		
		default:break;
		}
	}

}
