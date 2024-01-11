using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HourTransform : MonoBehaviour
{
    float cosAlpha = 0f;
    float sinAlpha = 0f;

    Vector2 vX = new Vector2(1, 0);
    Vector2 vY = new Vector2(0, 1);

    public string GetCurrentHour()
    {
        string currentHour = DateTime.Now.ToString("HH");
        return currentHour;
    }
    private string GetCurrentMin()
    {
        string currentMin = DateTime.Now.ToString("mm");
        return currentMin;
    }
    void Start()
    {

        sinAlpha = Mathf.Sin(90 * Mathf.Deg2Rad); // 90µµ
        cosAlpha = Mathf.Cos(90 * Mathf.Deg2Rad); // 90µµ
        GetCurrentHour();
        GetCurrentMin();
    }

    void Update()
    {
        string strCurrentHour = GetCurrentHour();
        int currentHour = Int32.Parse(strCurrentHour);
        string strCurrentMin = GetCurrentMin();
        int currentMin = Int32.Parse(strCurrentMin);

        if (currentHour >= 12)
        {
            currentHour = currentHour - 12;
        }
        float cosBeta = Mathf.Cos(-(currentHour * 30+currentMin*0.5f) * Mathf.Deg2Rad);
        float sinBeta = Mathf.Sin(-(currentHour * 30 + currentMin * 0.5f) * Mathf.Deg2Rad);

        transform.position = (vX * (cosAlpha * cosBeta - sinAlpha * sinBeta) * 15) + (vY * (sinAlpha * cosBeta + cosAlpha * sinBeta) * 15);
    }
}
