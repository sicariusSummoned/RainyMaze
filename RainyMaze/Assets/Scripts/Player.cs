using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

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

        if (Input.GetKey(KeyCode.LeftArrow)||CrossPlatformInputManager.GetAxis("Horizontal") <0)
        {
            transform.Translate(Vector3.left * Time.deltaTime*moveSpeed,Space.World);
            //Debug.Log("Left pressed");
        }
        
            if (Input.GetKey(KeyCode.UpArrow)||CrossPlatformInputManager.GetAxis("Vertical")>0)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
            //Debug.Log("Up pressed");

        }
        
            if (Input.GetKey(KeyCode.RightArrow)||CrossPlatformInputManager.GetAxis("Horizontal")>0)
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed, Space.World);
            //Debug.Log("Right pressed");

        }
        
            if (Input.GetKey(KeyCode.DownArrow)||CrossPlatformInputManager.GetAxis("Vertical")<0)
        {
            transform.Translate(Vector3.back * Time.deltaTime * moveSpeed, Space.World);
            //Debug.Log("Down pressed");


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
