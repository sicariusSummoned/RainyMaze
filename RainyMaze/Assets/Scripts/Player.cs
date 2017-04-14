using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {
    private bool win;
    

    float moveSpeed;

    Vector3 velocity;
    Vector3 acceleration;

    Rigidbody body;

    float tuning = 0.85f;

    float horizontalAxis;
    float verticalAxis;

    public bool Win
    {
        get { return win; }
        set { win = value; }
    }

    public Vector3 Velocity
    {
        get { return velocity; }
        set { velocity = value; }
    }

	// Use this for initialization
	void Start () {
        win = false;
        moveSpeed = 50;
        body = GetComponent<Rigidbody>();
        
	}
	
	// Update is called once per frame
	void Update () {

        verticalAxis = CrossPlatformInputManager.GetAxis("Vertical");
        horizontalAxis = CrossPlatformInputManager.GetAxis("Horizontal");

        Debug.Log(verticalAxis);
        Debug.Log(horizontalAxis);

        



        acceleration = new Vector3 (0,0,0);

        if (Input.GetKey(KeyCode.LeftArrow)||(horizontalAxis<0 && verticalAxis < tuning && verticalAxis > -tuning ))
        {
            //transform.Translate(Vector3.left * Time.deltaTime*moveSpeed,Space.World);
            //Debug.Log("Left pressed");
            acceleration.x += -5;
        } else
            if (Input.GetKey(KeyCode.RightArrow)||(horizontalAxis>0 && verticalAxis < tuning && verticalAxis > -tuning))
        {
            //transform.Translate(Vector3.right * Time.deltaTime * moveSpeed, Space.World);
            //Debug.Log("Right pressed");
            acceleration.x += 5;
        }

        if (Input.GetKey(KeyCode.UpArrow)||(verticalAxis > 0 && horizontalAxis < tuning && horizontalAxis > -tuning))
        {
            //transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
            //Debug.Log("Up pressed");
            acceleration.z += 5;
        }
        else

           if (Input.GetKey(KeyCode.DownArrow)||(verticalAxis < 0 && horizontalAxis < tuning && horizontalAxis > -tuning))
        {
            //transform.Translate(Vector3.back * Time.deltaTime * moveSpeed, Space.World);
            //Debug.Log("Down pressed");
            acceleration.z += -5;

        }


        velocity += acceleration;

        if (velocity.magnitude >= 15)
        {
            velocity.Normalize();
            velocity *= 15;
        }

        velocity *= 0.65f;

        body.AddForce(velocity);




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
