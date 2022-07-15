using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Checking ScoreManager
    private static ScoreManager instance = null;
    public static ScoreManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ScoreManager>();
                if (instance == null)
                {
                    Debug.LogError("Score Manager Can't Be Found !");
                }
            }
            return instance;
        }
    }

    public Text scoreValueText;
    private int currentScore;

    private void Start()
    {
        // init score
        currentScore = 0;
    }

    public void AddScore(int score)
    {
        // increment score
        currentScore += score;
        scoreValueText.text = currentScore.ToString();
    }
}
