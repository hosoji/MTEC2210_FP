using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rodrigo_Movement : Movement
{


    protected override void Start()
    {
        base.Start();

    }

    protected override void Update()
    {

        float xMovement = Input.GetAxis("Horizontal");
        //float yMovement = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(xMovement, 0, 0);

        transform.position += speed * movement * Time.deltaTime;
    }

    protected override void FixedUpdate()
    {


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Start" || collision.tag == "End")
        {

            scoreKeeper.IncrementScore();
            //scoreKeeper.pointGainable = false;
            //scoreKeeper.pointGainable = true;
        }
    }

}