using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ref : HomeAppliances
{
    private RefScreen[] refScreens = null;
    private void Awake()
    {
        refScreens = GetComponentsInChildren<RefScreen>();

    }
    public override void PowerOn()
    {
        base.PowerOn();
        Debug.Log("Ref_ Power On()");

        foreach (RefScreen refScreen in refScreens)
        {
            refScreen.On();
            
            Debug.Log(refScreen +": On");
        }

    }
    public override void PowerOff()
    {
        base.PowerOff();
        Debug.Log("Ref_ Power Off()");
        Debug.Log("Ref_ Power Off()");

        foreach (RefScreen refScreen in refScreens)
        {
            refScreen.Off();
        }

    }
    public override void Use()
    {
        Debug.Log("Ref Use()");
    }
}
