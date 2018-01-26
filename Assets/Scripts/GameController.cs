using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
	public GameObject Player;

	public Text scoreCounter;
	public Text restartText;
	public Text gameOverText;

	private bool gameOverFlag;
	private bool restartFlag;

	private int score;

	void Start (){
		gameOverFlag = false;
		restartFlag = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScore ();
	}

	void Update (){
		if (Player == null)
			gameOverFlag = true;
		
		if (restartFlag){
			if (Input.GetKeyDown (KeyCode.R))
				Application.LoadLevel (Application.loadedLevel);
		}
		if (gameOverFlag){
			restartText.text = "Restart with R";
			restartFlag = true;
		}
	}

	public void AddScore (int newScoreValue){
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore (){
		scoreCounter.text = "Score: " + score;
	}

	public void GameOver (){
		gameOverText.text = "Game Over!";
		gameOverFlag = true;
	}
}