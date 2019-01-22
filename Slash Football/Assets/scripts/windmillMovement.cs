using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windmillMovement : MonoBehaviour {
	public bool leftWindmill = true;
	private bool lowerLimit = false;
	private float yAxis = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (leftWindmill && !lowerLimit) {
			gameObject.transform.Translate (gameObject.transform.position.x, yAxis--, gameObject.transform.position.z);
			if (gameObject.transform.position.y < -Screen.height / 3) {
				lowerLimit = true;
			}
		} else if (leftWindmill && lowerLimit) {
			gameObject.transform.Translate (gameObject.transform.position.x, yAxis++, gameObject.transform.position.z);
			if (gameObject.transform.position.y > Screen.height / 3) {
				lowerLimit = false;
			}
		}
		else if (!leftWindmill && !lowerLimit)
		{
			gameObject.transform.Translate (gameObject.transform.position.x, yAxis++, gameObject.transform.position.z);
			if (gameObject.transform.position.y > Screen.height / 3) {
				lowerLimit = false;
			}	
		}
		else if (!leftWindmill && lowerLimit) {
			gameObject.transform.Translate (gameObject.transform.position.x, yAxis--, gameObject.transform.position.z);
			if (gameObject.transform.position.y < -Screen.height / 3) {
				lowerLimit = true;
			}
		}
	}
}
