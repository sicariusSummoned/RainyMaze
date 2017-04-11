using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private bool win;
    [SerializeField]
    float moveSpeed;

    public bool Win
    {
        get { return win; }
        set { win = value; }
    }

	// Use this for initialization
	void Start () {
        win = false;
        moveSpeed = 10.0f;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime*moveSpeed,Space.World);
            Debug.Log("Left pressed");
        }
        else
            if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
            Debug.Log("Up pressed");

        }
        else
            if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed, Space.World);
            Debug.Log("Right pressed");

        }
        else
            if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back * Time.deltaTime * moveSpeed, Space.World);
            Debug.Log("Down pressed");


        }




    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            win = true;
            Debug.Log("Collided with Goal");
        }
    }



}
