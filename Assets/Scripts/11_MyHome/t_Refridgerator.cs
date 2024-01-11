using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class t_Refridgerator : t_HomeAppliances
{
    private t_ColorPanel[] colorPanels = null;

    private void Awake()
    {
        colorPanels = GetComponentsInChildren<t_ColorPanel>();
        PowerOff();
    }
    public override void PowerOn()
    {
        if (IsPowerOn) return;
        base.PowerOn();
        foreach(t_ColorPanel colorPanel in colorPanels)
        {
            colorPanel.On();
        }

    }
    public override void PowerOff()
    {
        if (!IsPowerOn) return;
        base.PowerOff();
        foreach (t_ColorPanel colorPanel in colorPanels)
            colorPanel.Off();
    }


    public override void Use()
    {
        if (!IsPowerOn) return;
        foreach (t_ColorPanel colorPanel in colorPanels)
            colorPanel.ChangeRandomColor();
    }
}
