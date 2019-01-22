using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement1 : MonoBehaviour {
	public Rigidbody2D rb2d;
	public float ballForce;
	public bool newRound = true;
	private Vector3 startingPos;
	private float startTime = 0;
	public GameObject deploy, UP,DOWN;

	// Use this for initialization
	void Start () {
		if(gameController.p2Wins)
			rb2d.AddForce (new Vector2 (ballForce,ballForce));
		else
			rb2d.AddForce (new Vector2 (-ballForce,-ballForce));
		startingPos.x = 0;
		startingPos.y = -0.3f;
		startingPos.z = 0;
	}

	// Update is called once per frame
	void Update () {
		gameObject.SetActive (!PanelController.GameisPaused);
		if (Input.GetMouseButtonDown (0))
			Time.timeScale = 1f;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.name == "upperWall") {
			gameController.points1++;
			startTime = Time.time;
			Time.timeScale = 0.0f;
			gameController.p2Wins = false;
			Instantiate (gameObject, startingPos,Quaternion.identity);
			Destroy (gameObject,0.0f);
		} else if (collision.gameObject.name == "lowerWall") {
			gameController.points2++;
			startTime = Time.time;
			Time.timeScale = 0.0f;
			gameController.p2Wins = true;
			Instantiate (gameObject, startingPos,Quaternion.identity);
			Destroy (gameObject,0.0f);

		}
		if (!(collision.gameObject.name == "SubCollider"))
			LineRendererAI.ballGoesUp = true;

	}
}
