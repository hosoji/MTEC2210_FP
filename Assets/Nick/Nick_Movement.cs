using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class Nick_Movement : Movement
    {
        float xMove;
        private float inputMovement;
        

        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();


        }

        // Update is called once per frame
        protected override void Update()
        {
            
            if (Input.GetKey(rightKey))
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
                

               
                float xValue = inputMovement * speed * Time.deltaTime;

        }



        protected override void FixedUpdate()
        {
            Vector2 movement = new Vector2(xMove, 0);
            rb.AddForce(movement, ForceMode2D.Force);
        }
    }

