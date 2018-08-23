using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SteeringBehaviours
{

    public class AIDirector : MonoBehaviour
    {
        public AIAgent agent;

        private void Update()
        {
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(camRay, out hit, 1000f))
            {
                agent.SetTarget(hit.point);
            }
        }
    }
}