using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menuController : MonoBehaviour {

	// Use this for initialization
	private bool stopped = false;
	public static bool isMultiplayer = false;
	public Toggle toggle = null;
	void Start () {
		
	}
	void update(){
		
	}
	public void loadEasy(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex+1);
		//Debug.Log (menuController.isMultiplayer);
	}
	public void loadMedium(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex+2);
	}
	public void loadHard(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 3);
	}
	public void loadMenu(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex *0);
		isMultiplayer = false;

	}
	public void stop(){
		if (!stopped) {
			Time.timeScale = 0.0f;
			stopped = true;
		} else {
			Time.timeScale = 1.0f;
			stopped = false;
		}
			
	}
	public void setMultiplayer()
	{
		isMultiplayer = !isMultiplayer;
	}
}
