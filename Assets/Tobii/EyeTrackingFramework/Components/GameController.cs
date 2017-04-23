using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public Text liveText;
    public Text gameOver;
    public int live;
	public GameObject attention1;
	public Text attention2;
	public GameObject attention3;
	public GameObject attention4;
	public GameObject attention5;
	public Scrollbar liveBar;

	float lastAttention = 0;
    GameObject attentionGainer;
	bool hasGaze = false;

    // Use this for initialization
    void Start()
    {
        live = 100;
        UpdateScore();

    }

	public void lostGaze(){
		hasGaze = false;
	}

    public void restartGame()
    {
        live = 100;
        UpdateScore();
        gameOver.text = "";
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void lostLive()
    {
		live = live - 10;
		if (live <= 0) {
			gameOver.text = "Game Over";
		}
		UpdateScore ();
    }

	public void exitGame(){
		Application.Quit ();
	}

    public void startAttention()
    {
		hasGaze = true;
		if(lastAttention +1.0f < Time.time){
			stopOtherAttentionGainer ();
			lastAttention = Time.time;
			int a = Random.Range (0,5);
			switch (a) {
			case 0:
				attention1.SetActive (true);
				break;
			case 1:
				attention2.text="Achtung!";
				break;
			case 2:
				attention3.SetActive (true);
				break;
			case 3:
				attention4.SetActive (true);
				break;
			case 4:
				attention5.SetActive (true);
				break;
			}
		}
    }

	void stopOtherAttentionGainer(){
		attention4.SetActive (false);
		attention5.SetActive (false);
		attention1.SetActive (false);
		attention2.text = "";
		attention3.SetActive (false);
	}

    public void stopAttention()
    {
		stopOtherAttentionGainer ();
    }

    void UpdateScore()
    {
		liveText.text = "Leben: " + live;
		liveBar.size = (live / 100f);
    }
}
