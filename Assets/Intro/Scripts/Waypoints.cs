using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Waypoints : MonoBehaviour
{
    //Decloration
    public enum State
    {
        Patrol = 0,
        Seek = 1
    }
    public NavMeshAgent agent;
    public State currentState = State.Patrol;
    public Transform target;
    public float seekRadious = 5f;

    public Transform waypointParent;
    public float moveSpeed;
    public float stoppingDistance = 1f; // the variable name is always something that you make up (in this case "stoppingDistance")

    // Creates a collection of Transforms
    private Transform[] waypoints;
    private int currentIndex = 1;


    /*
     * [] - Brackets
     * () - Parenthesis
     * {} - Braces (or Curly Braces)
     */

    // CTRL + M + O = Fold Code
    // CTRL + M + P = Unfold Code
    // Use this for initialization

    void Patrol()
    {
        Transform point = waypoints[currentIndex];
        float distance = Vector3.Distance(transform.position, point.position);
        if (distance < stoppingDistance)
        {
            // currentIndex = currentIndex + 1
            currentIndex++;
            if (currentIndex >= waypoints.Length)
            {
                currentIndex = 1;
            }
        }

        agent.SetDestination(point.position);
        //transform.position = Vector3.MoveTowards(transform.position, point.position, moveSpeed);

        float distToTarget = Vector3.Distance(transform.position, target.position);
        if(distToTarget < seekRadious)
        {
            currentState = State.Seek;
        }
    }

    void Seek()
    {
        agent.SetDestination(target.position);
        //transform.position = Vector3.MoveTowards(transform.position, point.position, moveSpeed);

        float distToTarget = Vector3.Distance(transform.position, target.position);
        if (distToTarget > seekRadious)
        {
            currentState = State.Patrol;
        }
    }

    void Start()
    {
        //Getting children of waypointParent
        waypoints = waypointParent.GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case State.Patrol:
                //Patrol statement
                Patrol();
                break;
            case State.Seek:
               //Seek statement
                 Seek();
                break;
            default:
                break;
        }
         //agent.SetDestination(target.position);
         //Switch current state
         //If we are in patrol
         //Call Patrol()
         //If we are in seek
         //Call Seek ()
    }
}