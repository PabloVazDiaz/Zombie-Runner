using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] float hitPoints = 100f;

    public void Damage(float damageAmount)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damageAmount;
        if(hitPoints<=0)
        {
            Die();
        }
    }

    private void Die()
    {
        GetComponent<Animator>().SetTrigger("Die");
        GetComponent<EnemyAI>().enabled = false;
        this.enabled = false;
        //Destroy(gameObject);
    }
}
