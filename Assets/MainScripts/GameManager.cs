using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] allRaceCandidates;
    public List<GameObject> currentRacers = new List<GameObject>();
    public List<GameObject> pastRacers = new List<GameObject>();

    public Vector3 racerOneStartPos;
    public Vector3 racerTwoStartPos;

    public float gameTimeDuration = 60f;
    private float gameTimeRemaining;

    //public PlayerMovement playerMovement;
    //public PlayerScoreKeeper playerScore;
    public OpponentMovement opponentMovement;
    public OpponentScoreKeeper opponentScore;

    public bool gameOver = false;
    private  Color newColor;
    //private GameObject player;

    //playerSpeed = GetComponent<PlayerMovement>();



    private void Start()
    {
        //SetUpRace();
        
        

        gameTimeRemaining = gameTimeDuration;
        //player = GameObject.Find("Player");
        // playerMovement = player.GetComponent<PlayerMovement>();

        //playerScore = playerMovement.gameObject.GetComponent<PlayerScoreKeeper>();
    }

    void SetUpRace()
    {
        SpawnRacer(GetNewRacer());
        SpawnRacer(GetNewRacer());
    }

    void SpawnRacer(GameObject thisRacer)
    {
        bool isFirst = (currentRacers.Count == 1) ? true : false;

        Vector3 pos = (isFirst)? racerOneStartPos : racerTwoStartPos;

        GameObject racer = Instantiate(thisRacer, pos, Quaternion.identity);

        var move = racer.GetComponent<Movement>();

        move.speed = 600;
        move.rightKey = isFirst ? KeyCode.D : KeyCode.RightArrow;
        move.leftKey = isFirst ? KeyCode.A : KeyCode.LeftArrow;
    }

    GameObject GetNewRacer()
    {
        if (pastRacers.Count == allRaceCandidates.Length)
        {
            Debug.Log("All Racers have raced already");
            return null;
        }

        GameObject racer = null;
        int x = Random.Range(0, allRaceCandidates.Length - 1);

        for (int i = 0; i < allRaceCandidates.Length-1; i++)
        {
            if (i == x)
            {
                if (!pastRacers.Contains(allRaceCandidates[i]))
                {

                    racer = allRaceCandidates[i];
                    Debug.Log(racer.name);
                    currentRacers.Add(racer);
                    pastRacers.Add(racer);

                    //allRaceCandidates.Remove(racer);
                    break;

                }
                else
                {
                    GetNewRacer();
                }

            }
        }
        return racer;
    }

    private void Update()
    {
        if (gameTimeRemaining > 0)
        {
            gameTimeRemaining -= Time.deltaTime;
        }
        else
        {
            if (!gameOver)
            {
                //GameOver();
                gameOver = true;

            }

        }

        if (gameOver)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                //SceneManager.LoadScene(0);
                foreach(GameObject racer in currentRacers)
                {
                    Destroy(racer);
                }

                currentRacers.Clear();
                SetUpRace();

            }
        }
        
    }

    //public void GameOver()
    //{
    //    playerMovement.playerSpeed = 0;
    //    opponentMovement.opponentSpeed = 0;

    //    if (playerScore.score > opponentScore.score)
    //    {
    //        Debug.Log("Player Wins");
    //        Destroy(opponentMovement.gameObject);
    //    } else if (opponentScore.score> playerScore.score)
    //    {
    //        Debug.Log("AI Wins");
    //        Destroy(playerMovement.gameObject);
    //    }
    //    else
    //    {
    //        Debug.Log("It's a Draw!");
    //    }



    //}



}
