using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// abstract class는 단독으로 객체 인스턴스화 못함
public abstract class HomeAppliances : MonoBehaviour
{
    private bool isPowerOn = false;
    public virtual void PowerOn()
    {
        isPowerOn = true;
    }
    public virtual void PowerOff()
    {
        isPowerOn = false;
    }
    public abstract void Use();
}
