using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    [SerializeField] int health = 1;
    [SerializeField] GameObject deathVFX;
    [SerializeField] float explosionDuration = 1f;
    [SerializeField] AudioClip classic_hurt;
    [SerializeField] [Range(0, 1)] float enemyHurtVolume = 0.75f;
    [SerializeField] [Range(0, 1)] float shootSoundVolume = 0.25f;

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

        AudioSource.PlayClipAtPoint(classic_hurt, Camera.main.transform.position, enemyHurtVolume);

        //destroyed after 1 sec
        Destroy(explosion, explosionDuration);
    }
    public void Hit()
    {
        Destroy(gameObject);
    }
}
