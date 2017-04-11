using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {


    bool gameOver;

    Text gameTimeText;
    Text fps;

    float gameTime;
    float highScore;
    Vector3 startPosition;

    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject userInterface;

    Transform userInterfaceChild;

	// Use this for initialization
	void Start () {
        gameOver = false;
        gameTime = 0;

        gameTimeText = userInterface.GetComponent<Text>();
        userInterfaceChild = userInterface.transform.GetChild(0);
        fps = userInterfaceChild.GetComponent<Text>();

        //set reset point
        startPosition = player.transform.position;

        //highscore
        if (PlayerPrefs.HasKey("highScore"))
        {
            highScore = PlayerPrefs.GetFloat("highScore");
        }else
        {
            highScore = 0;
        }




	}
	
	// Update is called once per frame
	void Update () {
        //Increment gameTime
        gameTime += Time.deltaTime;
        gameTimeText.text = "TIME:" + gameTime;
        fps.text = "FPS" + (int)(1.0f / Time.smoothDeltaTime);
	}

    void ResetPlayer()
    {
        player.transform.position = new Vector3(startPosition.x,startPosition.y,startPosition.z);
    }

    void GameOver()
    {
        //Save data. Move to game over scene.
        PlayerPrefs.SetFloat("playerScore", gameTime);
        if (gameTime < highScore)
        {
            PlayerPrefs.SetFloat("highScore", highScore);
        }

        SceneManager.LoadScene("MenuScene");
    }
}
