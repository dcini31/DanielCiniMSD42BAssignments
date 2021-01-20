using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 15f;
    [SerializeField] int health = 50;
    [SerializeField] GameObject deathVFX;
    [SerializeField] float explosionDuration = 1f;
    [SerializeField] AudioClip oof;
    [SerializeField] AudioClip hitmarker;
    [SerializeField] [Range(0, 1)] float playerHurtVolume = 0.75f;
    [SerializeField] [Range(0, 1)] float shootSoundVolume = 0.15f;

    float xMin, xMax;
    float padding = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        setUpMoveBounderies();
    }

    // Update is called once per frame
    void Update()
    {
        Move();       
    }

    public int GetHealth()
    {
        return health;
    }
    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        //accesses the damage from other object and reduces health accordingly
        DamageDealer dmg = otherObject.gameObject.GetComponent<DamageDealer>();

        //if there is no dmgDealer in otherObject, the method ends
        if (!dmg)
        {
            return;
        }
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

        AudioSource.PlayClipAtPoint(oof, Camera.main.transform.position, playerHurtVolume);

        //destroyed after 1 sec
        Destroy(explosion, explosionDuration);
        //accesses Level Object and calls the Method GameOver()
        FindObjectOfType<Level>().GameOver();
    }

    private void setUpMoveBounderies()
    {
        //setup of bounderies of movement according to camera
        Camera gameCamera = Camera.main;

        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0.09f, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(0.95f, 0, 0)).x - padding;
    }

    private void Move()
    {
        //deltaX is the change of the x-axis of the player 
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;

        //newXPos= current position on x + differece moved in x-axis
        var newXPos = transform.position.x + deltaX;

        newXPos = Mathf.Clamp(newXPos, xMin, xMax);

        //moves the Player on the x-axis
        this.transform.position = new Vector2(newXPos, transform.position.y);
    }
}


