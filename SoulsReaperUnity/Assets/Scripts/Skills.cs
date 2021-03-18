using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]

public class Skills
{
    public int Type = 2;
    public string Name {get; set;}
    public float Cost {get; set;}
    public float Multiplier {get; set;}
    public int Limit {get; set;}

    public bool Unlocked {get; set;}
    public int Id {get; set;}
}