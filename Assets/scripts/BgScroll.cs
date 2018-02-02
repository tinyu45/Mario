using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScroll : MonoBehaviour {

	Material mt;

	// Use this for initialization
	void Start () {
		mt = GetComponent<MeshRenderer> ().material;
	}
	
	// Update is called once per frame
	void Update () {
		mt.mainTextureOffset +=new Vector2 (0.1f,0)*Time.deltaTime;
	}
}
