using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    [SerializeField]
    GameObject menuObject;

    [SerializeField]
    GameObject starObject;

    Text gameTimeText;
    Text highScoreTimeText;
    Text tipText;

    float gameTime;

    int minutes;
    int seconds;

    float highScore;

    string[] helpfulTips;

	// Use this for initialization
	void Start () {

        helpfulTips = new string[4];

        helpfulTips[0] = "Don't move too quickly!";
        helpfulTips[1] = "Don't move too slowly!";
        helpfulTips[2] = "Remember to tell all your friends about RainyMaze!";
        helpfulTips[3] = "There is no secret cow level!";

        int randNum = Mathf.FloorToInt(Random.Range(0, 4));



        gameTimeText = menuObject.transform.GetChild(0).GetComponent<Text>();
        highScoreTimeText = menuObject.transform.GetChild(1).GetComponent<Text>();
        tipText = menuObject.transform.GetChild(3).GetComponent<Text>();

        starObject = GameObject.Find("Star");

        gameTime = PlayerPrefs.GetFloat("playerScore"); 
        highScore = PlayerPrefs.GetFloat("highScore");

        seconds = Mathf.FloorToInt(gameTime);

        minutes = seconds / 60;

        seconds = seconds % 60;



        gameTimeText.text = "TIME:" + minutes + ":" + seconds;


        seconds = Mathf.FloorToInt(highScore);

        minutes = seconds / 60;
        seconds = seconds % 60;


        if(gameTime == highScore) {
            highScoreTimeText.text = "NEW BEST:" + minutes + ":" + seconds;
            starObject.SetActive(true);

        }else
        {
            highScoreTimeText.text = "BEST:" + minutes + ":" + seconds;
            starObject.SetActive(false);

        }

        tipText.text = helpfulTips[randNum];


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
