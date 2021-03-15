using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Terror
{
    public int Type = 3;
    public string Name {get; set;}
    public float Cost {get; set;}
    public float Multiplier {get; set;}
    public int Limit {get; set;} //how many times can we buy this?
//    public bool Unlocked {get; set;}
    public int Id {get; set;}
}
