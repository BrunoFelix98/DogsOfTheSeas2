using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    //State change variables
    public ChaseState chaseState;

    //Chasing variables
    public float attackRange; //Range in which the bot can attack the player
    public float speed;
    public float damping;
    public float angle;

    public float timer;

    public int number;
    public int hittingChance;

    public Quaternion lookRot;

    public Vector3 dir;

    public bool canAttackPlayer;

    public Transform parent;
    public Transform target;

    public override State RunCurrentState()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        if (Vector3.Distance(parent.position, target.position) <= attackRange)
        {
            dir = (target.transform.position - parent.position).normalized;
            lookRot = Quaternion.LookRotation(dir);

            //Apply the rotation
            if (Mathf.Sign(lookRot.y) == 1 && Mathf.Sign(lookRot.x) == -1)
            {
                //is top right
                lookRot = Quaternion.Euler(new Vector3(- angle, lookRot.eulerAngles.y - 180f, lookRot.eulerAngles.z + angle));
            }
            else if (Mathf.Sign(lookRot.y) == -1 && Mathf.Sign(lookRot.x) == -1)
            {
                //is top left
                lookRot = Quaternion.Euler(new Vector3(-angle, lookRot.eulerAngles.y + 180f, lookRot.eulerAngles.z - angle));
            }
            else if (Mathf.Sign(lookRot.y) == 1 && Mathf.Sign(lookRot.x) == 1)
            {
                //is bottom right
                lookRot = Quaternion.Euler(new Vector3(angle, lookRot.eulerAngles.y - 180f, lookRot.eulerAngles.z + angle));
            }
            else if (Mathf.Sign(lookRot.y) == -1 && Mathf.Sign(lookRot.x) == 1)
            {
                //is bottom left
                lookRot = Quaternion.Euler(new Vector3(+ angle, lookRot.eulerAngles.y - 180f, lookRot.eulerAngles.z - angle));
            }

            parent.rotation = Quaternion.Slerp(parent.rotation, lookRot, Time.deltaTime * damping);
            canAttackPlayer = true;
            AttackPlayer();
        }
        else
        {
            canAttackPlayer = false;
        }

        if (!canAttackPlayer)
        {
            return chaseState;
        }
        else
        {
            return this;
        }
    }

    void AttackPlayer()
    {
        if (Vector3.Distance(parent.position, target.position) <= attackRange)
        {
            //shoot cannonball
            if (timer >= 0)
            {
                //reloading
                timer--;
            }
            else
            {
                //shooting

                if (target.GetComponentInParent<PlayerBoat>() != null)
                {
                    number = Random.Range(0, 100);
                    if (number < hittingChance)
                    {
                        //ToDo Firing animation
                        target.GetComponentInParent<PlayerBoat>().playerShipHitpoints = target.GetComponentInParent<PlayerBoat>().playerShipHitpoints - 10;
                        //print("Hit with a number of: " + number);
                    }
                    else
                    {
                        //ToDo Missing shot animation
                        //print("Missed with a number of: " + number);
                    }
                }
                timer = 100;
            }
        }
    }
}