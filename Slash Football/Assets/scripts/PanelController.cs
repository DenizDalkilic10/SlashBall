using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelController : MonoBehaviour{

	public static bool GameisPaused = false;
	public GameObject gameOverMenu;
	public Text result;
	public Text score;
	private int scoreLimit = 5;
	void Update(){
		if (gameController.points1 == scoreLimit || gameController.points2 == scoreLimit)
			gameOver ();
	}
	public void resume(){
		gameOverMenu.SetActive (false);
		Time.timeScale = 1f;
		GameisPaused = false;

	}
	public void pause(){
		Time.timeScale = 0f;
		GameisPaused = true;
	}
	public void gameOver(){
		gameOverMenu.SetActive (true);
		if (gameController.points1 == scoreLimit) {
			result.text = "Player Blue Wins";
			result.color = Color.black;
			score.color = Color.black;
		} else {
			result.text = "Player Red Wins";
			result.color = Color.black;
			score.color = Color.black;
		}
		score.text = gameController.points1 + " - " + gameController.points2;
		Time.timeScale = 0f;
		GameisPaused = true;
		gameController.points1 = 0;
		gameController.points2 = 0;
	}
	public void restart(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		GameisPaused = false;
		Time.timeScale = 1f;

	}
	public void loadMenu(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex*0);
		GameisPaused = false;
		Time.timeScale = 1f;

	}
	public void quit(){
		Application.Quit();
	}
}
