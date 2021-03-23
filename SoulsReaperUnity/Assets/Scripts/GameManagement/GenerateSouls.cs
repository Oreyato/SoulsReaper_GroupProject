using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateSouls : MonoBehaviour
{
    public GameObject Soul;
    public int xPos;
    public int yPos;
    public int soulCount;

    void Start()
    {
        StartCoroutine(SoulDrop());
    }

    IEnumerator SoulDrop()
    {
        while(soulCount < 10)
        {
            xPos = Random.Range(46, -46);
            yPos = Random.Range(48, -48);

            Instantiate(Soul, new Vector3(xPos, 2, yPos), Quaternion.identity);

            yield return new WaitForSeconds(1f);
            soulCount += 1;

            if(soulCount < 1)
            {
                StartCoroutine(SoulDrop());
            }
        }
    }



}