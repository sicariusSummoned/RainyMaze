using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public  class ReturnButton : MonoBehaviour {

    public AudioClip chimeSound;
    private AudioSource source;

    public void Go()
    {
        SceneManager.LoadScene("GameScene");
        Debug.Log("Button Clicked");
    }

    public void Start()
    {
        source = GetComponent<AudioSource>();
        //Play sound
        source.PlayOneShot(chimeSound, 0.7f);
    }
}
