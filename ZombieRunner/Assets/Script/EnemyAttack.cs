using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public PlayerHealth target;
    [SerializeField] float damage = 10f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    public void AttackHit()
    {
        if (target != null)
        {
            target.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}
