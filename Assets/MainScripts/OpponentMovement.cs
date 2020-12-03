using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentMovement : MonoBehaviour
{
    public float opponentSpeed;
    public float speedModifier;
    private OpponentScoreKeeper scoreKeeper;
    // Start is called before the first frame update
    void Start()
    {
        scoreKeeper = GetComponent<OpponentScoreKeeper>();

        Debug.Log("Speed Modifier: " + speedModifier);

        
    }

    // Update is called once per frame
    void Update()
    {
        float adjustedSpeed = opponentSpeed * speedModifier;
        transform.position += (Vector3.right * adjustedSpeed * Time.deltaTime) ;

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Start" || collision.tag == "End")
        {
            speedModifier = Random.Range(0.5f, 2);
            opponentSpeed *= -1.0f;    

            scoreKeeper.IncrementScore();        
        }
    }
}
