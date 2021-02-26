using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    [SerializeField] int health = 1;
    [SerializeField] AudioClip gooal;
    [SerializeField] [Range(0, 1)] float gooalVolume = 0.75f;
    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        //accesses the damage from other object and reduces health accordingly
        DD dmg = otherObject.gameObject.GetComponent<DD>();

        //if there is no DmgDealer in otherObject, the method ends
        if (!dmg)
        {
            return;
        }
        Hit(dmg);
    }

    //when called sends the damage class details
    private void Hit(DD dmg)
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
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
