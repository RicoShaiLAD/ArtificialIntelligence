using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

    public class AIAgent : MonoBehaviour
    {
        public NavMeshAgent agent;

        private Vector3 point = Vector3.zero;

	    void Update ()
        {
            if (point.magnitude > 0)
            {
            agent.SetDestination(point);
            }
	    }
    }
