using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {
	public Rigidbody2D rb2d;
	public float ballForce;
	public bool newRound = true;
	private bool firstHit = true;
	private Vector3 startingPos;
	private float startTime = 0;
	public GameObject deploy;
	// Use this for initialization
	void Start () {
		
		startingPos.x = -1;
		startingPos.y = 1;
		startingPos.z = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0))
			Time.timeScale = 1f;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.name == "windmill" && firstHit) {
			if(gameController.p2Wins)
				rb2d.AddForce (new Vector2 (ballForce,ballForce));
			else
				rb2d.AddForce (new Vector2 (-ballForce,-ballForce));
			firstHit = false;
		}
		if (collision.gameObject.name == "upperWall") {
			gameController.points1++;
			startTime = Time.time;
			Time.timeScale = 0.0f;
			startingPos.x = -0.5f;
			startingPos.y = 0.5f;
			gameController.p2Wins = false;
			firstHit = true;
			Instantiate (gameObject, startingPos,Quaternion.identity);
			Destroy (gameObject,0.0f);
		} else if (collision.gameObject.name == "lowerWall") {
			gameController.points2++;
			startTime = Time.time;
			Time.timeScale = 0.0f;
			startingPos.x = 0.5f;
			startingPos.y = -0.5f;
			gameController.p2Wins = true;
			firstHit = true;
			Instantiate (gameObject, startingPos,Quaternion.identity);
			Destroy (gameObject,0.0f);

		}
		if (!(collision.gameObject.name == "SubCollider"))
			LineRendererAI.ballGoesUp = true;
		
	}
}
