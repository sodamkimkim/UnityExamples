using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeverageCider : Beverage
{
    private void Start()
    {
        beverageName = "ªÁ¿Ã¥Ÿ";
        info = " ≈ı∏Ì«— º≥≈¡π∞";
        price = 800;
    }

    public override void Drink()
    {
        Debug.Log("ªÁ¿Ã¥Ÿ ≤‹≤©≤‹≤©≤‹≤⁄");
    }
}
