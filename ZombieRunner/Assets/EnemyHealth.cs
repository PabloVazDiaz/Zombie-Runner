using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] float hitPoints = 100f;

    public void Damage(float damageAmount)
    {
        hitPoints -= damageAmount;
        if(hitPoints<=0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
