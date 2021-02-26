using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] int scoreValue = 1;
    [SerializeField] AudioClip gooal;
    [SerializeField] [Range(0, 1)] float gooalVolume = 0.75f;

    private void OnCollisionEnter2D(Collision2D otherObject)
    {
        print(otherObject.gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        //when laser hits shredder it will be destroyed
        Destroy(otherObject.gameObject);
        FindObjectOfType<Session>().AddToScore(scoreValue);
        AudioSource.PlayClipAtPoint(gooal, Camera.main.transform.position, gooalVolume);
    }


}
