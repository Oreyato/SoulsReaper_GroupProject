using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{

    public GameObject Player;

    public Transform goal;

    public Transform fleeZone;

    public bool IsDeathZone = false;
 
    void Awake() 
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            agent.destination = fleeZone.position;
            SfxManager.sfxInstance.ScreamEnemy.PlayOneShot(SfxManager.sfxInstance.ScreamEnemySnd);
        }

        if (collider.gameObject.tag == "DestroyAI")
        {
            Destroy(gameObject);
        }
    }
}
