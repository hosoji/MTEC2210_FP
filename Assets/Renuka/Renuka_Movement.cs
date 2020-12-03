using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Renuka_Movement : Movement
{
    //public float playerSpeed;
    //float xMove;



    private float inputMovement;

    protected override void Start()
    {
        base.Start();

        //rb = GetComponent<Rigidbody2D>();
    }

    protected override void Update()
    {
        //float xMovement = Input.GetAxis("Horizontal");
        //float yMovement = Input.GetAxis("Vertical");

        if (Input.GetKey(rightKey))
        {
            inputMovement = 1;

        } else if (Input.GetKey(leftKey))
        {
            inputMovement = -1;
        } else
        {
            inputMovement = 0;
        }

        float xMove = inputMovement * speed * Time.deltaTime; 

        Vector2 movement = new Vector2(xMove, 0);
        rb.velocity = movement;

        //Vector3 movement = new Vector3(xMove, 0, 0);

        //transform.position += playerSpeed * movement * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Start" && scoreKeeper.score % 2 > 0)
        {
            scoreKeeper.IncrementScore();
            //scoreKeeper.gainPoint = true;
        }

        if (collision.tag == "End" && scoreKeeper.score % 2 == 0)
        {
            scoreKeeper.IncrementScore();
            //scoreKeeper.gainPoint = false;
        }
    }
}
