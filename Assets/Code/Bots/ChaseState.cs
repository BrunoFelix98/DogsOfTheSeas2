using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : State
{
    //State change variables
    public AttackState attackState;
    public PatrolState patrolState;

    public bool isInAttackRange;

    //Chasing variables
    public float sightRange; //Range in which the bot can see the player
    public float attackRange; //Range in which the bot can attack the player
    public float speed;

    public bool canSeePlayer;

    public Transform parent;
    public Transform target;

    public override State RunCurrentState()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        if (Vector3.Distance(parent.position, target.position) <= sightRange)
        {
            canSeePlayer = true;
        }
        else
        {
            canSeePlayer = false;
        }

        parent.GetComponent<NavMeshAgent>().SetDestination(target.position);
        parent.LookAt(target.position);
        parent.rotation = Quaternion.LookRotation(target.forward, target.up);

        if(Vector3.Distance(parent.position, target.position) <= attackRange)
        {
            isInAttackRange = true;
        }
        else
        {
            isInAttackRange = false;
        }

        if (isInAttackRange)
        {
            return attackState;
        }
        else if (!canSeePlayer)
        {
            return patrolState;
        }
        else
        {
            return this;
        }
    }
}