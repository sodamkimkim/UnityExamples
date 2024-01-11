using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class t_HomeAppliances : MonoBehaviour
{
    private bool isPowerOn = false;
    public bool IsPowerOn { get { return isPowerOn;  } }

    public virtual void PowerOn()
    {
        isPowerOn = true;
    }
    public virtual void PowerOff()
    {
        isPowerOn = false;
    }
    public abstract void Use();
} // end of class
