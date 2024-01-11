using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeverageStraberryMilk : Beverage
{
    private void Start()
    {
        beverageName = "µş±â¿ìÀ¯";
        info = "µş±âÇâ ¿ìÀ¯";
        price = 1000;

    }
    public override void Drink()
    {
        Debug.Log("µş±â ¿ìÀ¯ ¸ÀÀÖ³×");
    }
}
