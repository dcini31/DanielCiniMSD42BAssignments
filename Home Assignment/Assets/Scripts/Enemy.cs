﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float health = 1;
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject LaserPrefab;
    [SerializeField] float LaserSpeed = 0.3f;
    [SerializeField] GameObject deathVFX;
    [SerializeField] float explosionDuration = 1f;
    
    //reduces health when enemy collides with gameObject
    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        //accesses the damage from other object and reduces health accordingly
        DamageDealer dmg = otherObject.gameObject.GetComponent<DamageDealer>();
        Hit(dmg);
    }

    //when called sends the damage class details
    private void Hit(DamageDealer dmg)
    {
        health -= dmg.GetDamage();

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        //instantiates explosion effect
        GameObject explosion = Instantiate(deathVFX, transform.position, Quaternion.identity);
        //destroyed after 1 sec
        Destroy(explosion, explosionDuration);
    }

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

        if(shotCounter <= 0f)
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
    }
}
