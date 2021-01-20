using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    //updates text in ui
    Text scoreText;
    GameSession gameSession;

    // Start is called before the first frame update
    void Start()
    {       
        scoreText = GetComponent<Text>();
        gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = gameSession.GetScore().ToString();

        if (gameSession.GetScore() >= 100)
        {         
            //accesses Level Object and calls the Method GameOver()
            FindObjectOfType<Level>().Win();
        }
    }
}
