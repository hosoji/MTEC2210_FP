using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArashMovement : Movement
{
    public float playerSpeed;
    float xMove;
    ArashScoreKeeper scoreKeeper;
    /*    Rigidbody2D rigidBody;
    public GameManager gameMode;*/


    float inputMovement;

    protected override void Start()
    {
        base.Start();
        scoreKeeper = GetComponent<ArashScoreKeeper>();
        //rigidBody = GetComponent<Rigidbody2D>();
    }

    protected override void Update()
    {
        base.Update();
        if (Input.GetKey(rightKey))
            inputMovement = 1;
        else if (Input.GetKey(leftKey))
            inputMovement = -1;
        else
            inputMovement = 0;

            xMove = inputMovement * playerSpeed * Time.deltaTime;

    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        Vector2 movement = new Vector2(xMove, 0);
        rb.AddForce(movement, ForceMode2D.Force);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "Start" && scoreKeeper.score % 2 != 0)
            || (collision.tag == "End" && scoreKeeper.score % 2 == 0))
            scoreKeeper.IncrementScore();
    }

}
