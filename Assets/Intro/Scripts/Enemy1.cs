using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public Transform waypointParent;
        // creates a collection of transforms
        private Transform[] waypoints;
        private int currentIndex = 1;
        
    	// Use this for initialization
	void Start ()
    {
        //getting children of waypointParent
        waypoints = waypointParent.GetComponentsInChildren<Transform>();
	}

    // Update is called once per frame
    void Update()
    {
        Transform point = waypoints[currentIndex];
        float distance = Vector2.Distance(transform.position, point.position);
        if (distance < .5f)
        {
            currentIndex++;
            if(currentIndex >= waypoints.Length)
            {
                currentIndex = 1;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, point.position, 0.1f);
    }
}
