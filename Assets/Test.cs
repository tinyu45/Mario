using System.Collections;
using System.Collections.Generic;
using UnityEngine;







public class Test : MonoBehaviour {
	public enum WEEK{
		Monday=1,
		Tuesday,
		Wendesday=6,
		Thursday,
		Friday,
		Satuaday,
		Sunday
	}
	// Use this for initialization
	void Start () {
		string str=string.Format("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}",(int)WEEK.Monday, (int)WEEK.Tuesday,(int)WEEK.Wendesday, (int)WEEK.Thursday,(int)WEEK.Friday, (int)WEEK.Satuaday, (int)WEEK.Sunday );
		print (str);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
