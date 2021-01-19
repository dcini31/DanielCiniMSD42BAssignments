using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    //updates text in UI
    Text health;
    Player player;
    Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Text>();
        player = FindObjectOfType<Player>();

        healthBar = FindObjectOfType<Slider>();
        healthBar.maxValue = player.GetHealth();
    }

    // Update is called once per frame
    void Update()
    {
        health.text = player.GetHealth().ToString();

        healthBar.value = player.GetHealth();
    }
}
