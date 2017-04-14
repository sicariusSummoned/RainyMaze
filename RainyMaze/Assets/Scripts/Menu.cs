using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    [SerializeField]
    GameObject menuObject;

    Text gameTimeText;
    Text highScoreTimeText;

    float gameTime;

    int minutes;
    int seconds;

    float highScore;

	// Use this for initialization
	void Start () {

        gameTimeText = menuObject.transform.GetChild(0).GetComponent<Text>();
        highScoreTimeText = menuObject.transform.GetChild(1).GetComponent<Text>();

        gameTime = PlayerPrefs.GetFloat("playerScore"); 
        highScore = PlayerPrefs.GetFloat("highScore");

        seconds = Mathf.FloorToInt(gameTime);

        minutes = seconds / 60;

        seconds = seconds % 60;



        gameTimeText.text = "TIME:" + minutes + ":" + seconds;


        seconds = Mathf.FloorToInt(highScore);

        minutes = seconds / 60;
        seconds = seconds % 60;

        highScoreTimeText.text = "BEST:" + minutes + ":" + seconds;



	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
