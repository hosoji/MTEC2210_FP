using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shanice_PlayerMovement : Movement
    {
        
        public float playerSpeed;
        private Shanice_PlayerScoreKeeper scoreKeeper;

        private float inputMovement;

        protected override void Start()
        {
            base.Start();

            scoreKeeper = GetComponent<Shanice_PlayerScoreKeeper>();
        }

        // Update is called once per frame
        protected override void Update()
        {
            //base.Update();

            if (Input.GetKey(rightKey)) {
                inputMovement = 1;
            } else if (Input.GetKey(leftKey)) {
                inputMovement = -1;
            } else {
                inputMovement = 0;
            }

            float xValue = inputMovement * playerSpeed * Time.deltaTime;
            Vector3 xMovement = new Vector3(xValue, 0, 0);
            transform.position += xMovement;
        }

        protected override void FixedUpdate()
        {

        }

        /*private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Start" || collision.tag == "End")
            {
                //speedModifier = Random.Range(0.5f, 2);
                playerSpeed *= -1.0f;    

                scoreKeeper.IncrementScore();        
            }
        }*/
    }