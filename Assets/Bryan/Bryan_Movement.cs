using System.Collections;
using System.Collections.Generic;
using UnityEngine;





    public class Bryan_Movement : Movement
    {
        private bool isGrounded;

        float xMove;
        public float jumpSpeed;
        private bool jumpFlag;
       
        private float inputMovement;

        protected override void Start()
        {

            base.Start();
        }

        // Update is called once per frame
       protected override void Update()
        {
           /* if (Input.GetKey(rightKey))
            {
                inputMovement = 1;
            }
            else if (Input.GetKey(leftKey))
            {
                inputMovement = -1;
            }
            else
            {
                inputMovement = 0;
            }
           */



             xMove = Input.GetAxis("Horizontal")
             * speed * Time.deltaTime;
             
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpFlag = true;
                Invoke("KilljumpFlag", 0.05f);
            }
        }

       protected override void FixedUpdate()
        {
            Vector2 movement = new Vector2(xMove, 0);
            rb.AddForce(movement, ForceMode2D.Force);


            if (jumpFlag)
            {
                Vector2 jump = new Vector2(0, jumpSpeed *
                    Time.deltaTime);
                rb.AddForce(jump, ForceMode2D.Impulse);

            }
        }

        public void KilljumpFlag()
        {
            jumpFlag = false;
        }

        /* private void OnTriggerEnter2D(Collider2D collision)
         {
             if(collision.tag == "Ground")
             {
                 isGrounded = true;
             }
         }
        */

        /* private void OnTriggerExit2D(Collider2D collision)
         {
             if (collision.tag == "Ground")
             {
                 isGrounded = false;
             }
         }
        */


    }
