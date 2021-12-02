using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pathfinder : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform goal;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (goal == null)
            goal.position = GameObject.Find("Mine").transform.position;

        agent.destination = goal.position;
    }

    private void FixedUpdate()
    {
        agent.destination = goal.position;
    }
}
