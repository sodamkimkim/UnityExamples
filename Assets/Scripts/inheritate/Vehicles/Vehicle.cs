using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Vehicle
{
    protected bool isRead = false;

    // 자식이 재정의나 확장 안했으면 virtual 이거 씀 했으면 재정의 된 자식거
    public virtual void EngineStart()
    {
        isRead = true;
        Debug.Log("Engine Start");
    }
    
    // 이건 무조건 자식이 override해야 하는거
    public abstract void Driving();
}
