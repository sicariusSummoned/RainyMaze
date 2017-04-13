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
    float highScore;

	// Use this for initialization
	void Start () {

        gameTimeText = menuObject.transform.GetChild(0).GetComponent<Text>();
        highScoreTimeText = menuObject.transform.GetChild(1).GetComponent<Text>();

        gameTime = PlayerPrefs.GetFloat("playerScore"); 
        highScore = PlayerPrefs.GetFloat("highScore");


        gameTimeText.text =  "TIME:"+gameTime.ToString();
        highScoreTimeText.text = "BEST:"+highScore.ToString();



	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
