using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Items
{
    public int Type = 1;
    public string Name {get; set;}
    public float Cost {get; set;}
    public int Limit {get; set;}

    public bool Unlocked {get; set;}
    public bool Placed {get; set;}
    public int Id {get; set;}
}