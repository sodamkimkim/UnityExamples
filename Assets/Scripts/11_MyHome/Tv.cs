using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tv : HomeAppliances
{
    private TvScreen tvScreen = null;
    private PowerLamp powerLamp = null;

    private void Awake()
    {
        tvScreen = GetComponentInChildren<TvScreen>();
        powerLamp = GetComponentInChildren<PowerLamp>();
    }

    public override void PowerOn()
    {
        base.PowerOn();
        tvScreen.On();
        powerLamp.On();
    }
    public override void PowerOff()
    {
        base.PowerOff();
        tvScreen.Off();
        powerLamp.Off();
    }

    public override void Use()
    {
        tvScreen.TogglePause();
    }
}
