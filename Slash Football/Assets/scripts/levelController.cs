using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelController : MonoBehaviour {
	//variables
	public static bool isMultiplayer = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void setMultiplayer()
	{
		isMultiplayer = !isMultiplayer;
	}
}
