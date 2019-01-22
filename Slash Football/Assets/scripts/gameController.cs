using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameController : MonoBehaviour {
	public static int points1;
	public static int points2;
	public Text p1Score, p2Score;

	public static bool p2Wins = true;
	// Use this for initialization
	void Start () {
		points1 = 0;
		points2 = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (points1);
		p1Score.text = "" + points1;
		p2Score.text = "" + points2;
	}
		
}
