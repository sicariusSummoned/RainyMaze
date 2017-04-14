using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {


    public AudioClip fallSound;
    private AudioSource source;

    Text gameTimeText;
    Text fps;

    float gameTime;
    float highScore;
    Vector3 startPosition;

    int minutes;
    int seconds;

    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject userInterface;

    Transform userInterfaceChild;

	// Use this for initialization
	void Start () {

        source = player.GetComponent<AudioSource>();

        gameTime = 0;

        gameTimeText = userInterface.GetComponent<Text>();
        userInterfaceChild = userInterface.transform.GetChild(0);
        fps = userInterfaceChild.GetComponent<Text>();

        //set reset point
        startPosition = player.transform.position;

        //highscore
        if (PlayerPrefs.HasKey("highScore"))
        {
            Debug.Log("FOUND HIGHSCORE");
            highScore = PlayerPrefs.GetFloat("highScore");
        }else{

            Debug.Log("MISSING HIGHSCORE");
            highScore = 9999;

        }




	}
	
	// Update is called once per frame
	void Update () {
        //Increment gameTime
        gameTime += Time.deltaTime;

        seconds = Mathf.FloorToInt(gameTime);

        minutes = seconds / 60;

        seconds = seconds % 60;



        gameTimeText.text = "TIME:" + minutes+":"+seconds;
        fps.text = "FPS" + (int)(1.0f / Time.smoothDeltaTime);

        if (player.transform.position.y < -2)
        {
            ResetPlayer();
        }

        if (player.GetComponent<Player>().Win)
        {
            GameOver();
        }
	}

    void ResetPlayer()
    {
        source.PlayOneShot(fallSound);
        player.transform.position = new Vector3(startPosition.x,startPosition.y,startPosition.z);
        player.GetComponent<Player>().Velocity = new Vector3(0, 0, 0);
    }

    void GameOver()
    {
        //Save data. Move to game over scene.
        PlayerPrefs.SetFloat("playerScore", gameTime);
        if (gameTime < highScore)
        {
            PlayerPrefs.SetFloat("highScore", gameTime);
        }

        SceneManager.LoadScene("MenuScene");
    }
}
