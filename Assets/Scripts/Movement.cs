using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public ScoreKeeper scoreKeeper;

    public KeyCode leftKey;
    public KeyCode rightKey;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        scoreKeeper = GetComponent<ScoreKeeper>();
        
    }


    protected virtual void Update()
    {
        
    }

    protected virtual void FixedUpdate()
    {

    }
}
