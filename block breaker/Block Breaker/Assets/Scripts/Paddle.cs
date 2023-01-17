using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public bool autoPlay = false;

    private Ball ball;

    void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
    }

	// Update is called once per frame
	void Update ()
    {
        if (!autoPlay)
        {
            MoveWithMouse();
        }
        else
        {
            Autoplay();
        }
    }

    void Autoplay()
    {
        Vector3 mousePosInBlocks = ball.transform.position;
        Vector3 paddlePos = new Vector3(1.95f, this.transform.position.y, 0f);
        paddlePos.x = Mathf.Clamp(mousePosInBlocks.x, 2.19f, 13.8f);
        transform.position = paddlePos;
    }

    void MoveWithMouse()
    {
        float mousePosInBlocks = (Input.mousePosition.x / Screen.width * 16);
        Vector3 paddlePos = new Vector3(1.95f, this.transform.position.y, 0f);
        paddlePos.x = Mathf.Clamp(mousePosInBlocks, 2.19f, 13.8f);
        transform.position = paddlePos;
    }
}
