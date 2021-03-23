using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spawn : MonoBehaviour
{
    public GameObject nagent;
    public GameObject goalObject;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnAgent", 1);
    }

    void SpawnAgent()
    {
       GameObject na = (GameObject) Instantiate(nagent, this.transform.position, Quaternion.identity);
       na.GetComponent<AIMovement>().goal = goalObject.transform;
        
        Invoke("SpawnAgent", Random.Range(1,10));
    }

}
