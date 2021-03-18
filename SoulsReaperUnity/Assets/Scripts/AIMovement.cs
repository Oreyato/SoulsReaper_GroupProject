using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    
    public Transform back;

    public GameObject Player;

    public Transform goal;

    public float flee = 10f;
 
    void Awake() 
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    
    
        
    }


}
