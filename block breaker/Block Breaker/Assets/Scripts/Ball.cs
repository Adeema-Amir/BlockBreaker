using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Paddle paddle;
    private bool hasStarted = false;
    //needed for unity 5 coding
    private Rigidbody2D paddleToBallVector;
    private Vector3 ballStartPosition;
    // Use this for initialization
    void Start()
    {
        //Account for scripting LvlMng, Paddle, Ball
        paddle = GameObject.FindObjectOfType<Paddle>();

        //Getting rigid body info
        paddleToBallVector = GetComponent<Rigidbody2D>();
        ballStartPosition = this.transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            // Lock the ball relative to the paddle
            this.transform.position = paddle.transform.position + ballStartPosition;
        }
        //Wait for left mouse  click to launch the ball
        if (Input.GetMouseButtonDown(0))
        {
            print("Mouse clicked, launch ball");
            hasStarted = true;
            //Since we are now using rigid body, we can call the velocity for Vector2
            this.paddleToBallVector.velocity = new Vector2(2f, 10f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 breakEndlessLoops = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));

        if (hasStarted)
        {
            GetComponent<AudioSource>().Play();
            this.GetComponent<Rigidbody2D>().velocity += breakEndlessLoops;
        }
    }
}