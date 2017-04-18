using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Text liveText;
	public Text gameOver;
	public int live;

	// Use this for initialization
	void Start () {
		live = 100;
		UpdateScore ();
	}

	public void restartGame(){
		live = 100;
		UpdateScore ();
		gameOver.text = "";
	}
	
	public void lostLive(){
		live = live - 10;
		if (live <= 0) {
			gameOver.text = "Game Over";
		}
		UpdateScore ();
	}

	void UpdateScore () {
		liveText.text = "Leben: " + live;
	}
}
