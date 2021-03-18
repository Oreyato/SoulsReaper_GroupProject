using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{

    public GameObject Player;

    public Transform goal;

    public Transform fleeZone;
 
    void Awake() 
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }

    void OnTriggerEnter()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = fleeZone.position;
    }
}
