using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyShoot : MonoBehaviour
{   
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject LaserPrefab;
    [SerializeField] float LaserSpeed = 0.3f;
    [SerializeField] AudioClip hitmarker;
    [SerializeField] [Range(0, 1)] float shootSoundVolume = 0.25f;  
    void Start()
    {
        //random number generator for shots
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        //reduces amount of time to shoot per frame
        shotCounter -= Time.deltaTime;

        if (shotCounter <= 0f)
        {
            Fire();
            //reset counter
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
        //spawns enemys laser
        GameObject Laser = Instantiate(LaserPrefab, transform.position, Quaternion.identity) as GameObject;

        Laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -LaserSpeed);

        AudioSource.PlayClipAtPoint(hitmarker, Camera.main.transform.position, shootSoundVolume);
    }
}