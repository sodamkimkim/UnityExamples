using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Vehicle
{
    protected bool isRead = false;

    // �ڽ��� �����ǳ� Ȯ�� �������� virtual �̰� �� ������ ������ �� �ڽİ�
    public virtual void EngineStart()
    {
        isRead = true;
        Debug.Log("Engine Start");
    }
    
    // �̰� ������ �ڽ��� override�ؾ� �ϴ°�
    public abstract void Driving();
}
