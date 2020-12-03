using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    public TextMeshPro scoreText;
    public int score;

    public virtual void IncrementScore()
    {
        score++;
        scoreText.text = score.ToString("00");
    }
}
