using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : State
{
    //State change variables
    public ChaseState chaseState;

    public bool canSeePlayer;

    //Patrolling variables
    public float speed;
    private float waitTime;
    public float startWaitTime;
    public float Angle = 30.0f;
    public float sightRange; //Range in which the bot can see the player

    public GameObject[] wayPnts;
    public List<GameObject> waypoints = new List<GameObject>();

    public Transform parent;
    public Transform target;

    private int randomWaypoint;

    void Start()
    {
        waitTime = startWaitTime;

        wayPnts = GameObject.FindGameObjectsWithTag("Waypoint");

        for (int i = 0; i < wayPnts.Length; i++)
        {
            float distance = 10.1f;

            if (Vector3.Distance(parent.transform.position, wayPnts[i].transform.position) < distance)
            {
                waypoints.Add(wayPnts[i]);
            }
        }

        randomWaypoint = Random.Range(0, waypoints.Count);
    }

    public override State RunCurrentState()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        if (Vector3.Distance(parent.position, waypoints[randomWaypoint].transform.position) <= 1.0f)
        {
            //Reached destination

            if (waitTime <= 0)
            {
                //Time to move again
                randomWaypoint = Random.Range(0, waypoints.Count);
                waitTime = startWaitTime;
            }
            else
            {
                //Wait on the spot in that waypoint
                waitTime -= Time.deltaTime;
            }
        }
        else
        {
            parent.GetComponent<NavMeshAgent>().SetDestination(waypoints[randomWaypoint].transform.position);

            ShipRotation();
        }

        if (Vector3.Distance(parent.position, target.position) <= sightRange)
        {
            canSeePlayer = true;
        }
        else
        {
            canSeePlayer = false;
        }

        if (canSeePlayer)
        {
            return chaseState;
        }
        else
        {
            return this;
        }
    }

    void ShipRotation()
    {
        parent.LookAt(waypoints[randomWaypoint].transform.position);
        parent.rotation = Quaternion.LookRotation(parent.forward, waypoints[randomWaypoint].transform.up);
    }
}
