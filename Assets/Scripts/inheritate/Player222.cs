using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player222 : MonoBehaviour
{
    private Vehicle vehicle = null;
    private void Start()
    {
        //vehicle = new Boat();
        //vehicle.EngineStart();
        //vehicle.Driving();
    }

    public void RideTo(Vehicle _vehicle)
    {
        vehicle = _vehicle;
    }
    private void Update()
    {
        if (vehicle == null) return;
        if (Input.GetKeyDown(KeyCode.Alpha1))
            vehicle.EngineStart();
        if (Input.GetKeyDown(KeyCode.Alpha2))
            vehicle.Driving();
    }
}
