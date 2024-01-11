using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : Vehicle
{
    public override void EngineStart()
    {
        Debug.Log("Pumping");
        base.EngineStart();
    }

    public override void Driving()
    {
        Debug.Log("Driving Boat");
    }

}
