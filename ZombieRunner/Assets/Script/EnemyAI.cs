using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;


    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (isProvoked)
        {
            EngageTarget();
        }
        else if(distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }
        
    }

    private void EngageTarget()
    {
        animator.SetBool("Move", true);
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        if(distanceToTarget<= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }

    }

    private void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        animator.SetTrigger("Attack");
        print("Attacking");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
