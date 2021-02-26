using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    //updates text in ui
    Text scoreText;
    Session session;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        session = FindObjectOfType<Session>();
    }

    // Update is called once per frame
    private void Update()
    {
        scoreText.text = session.GetScore().ToString();

        if (session.GetScore() >= 20)
        {
            //accesses Level Object and calls the Method GameOver()
            FindObjectOfType<Level>().Win();
        }
    }
}