using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Session : MonoBehaviour
{
    int score = 0;
    private void Awake()
    {
        SetUpSingleton();
    }

    //checks that only 1 Session runs
    private void SetUpSingleton()
    {
        int numOfSessions = FindObjectsOfType<Session>().Length;

        if (numOfSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return score;
    }

    //adds score outside script inside AddToScore
    public void AddToScore(int scoreValue)
    {
        score += scoreValue;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
