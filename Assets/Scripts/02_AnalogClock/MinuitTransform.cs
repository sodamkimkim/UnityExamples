using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MinuitTransform : MonoBehaviour
{


    float cosAlpha = 0f;
    float sinAlpha = 0f;

    Vector2 vX = new Vector2(1, 0);
    Vector2 vY = new Vector2(0, 1);

    public string GetCurrentMinuit()
    {
        string currentMin = DateTime.Now.ToString("mm");
        return currentMin;
    }
    private void Start()
    {

        sinAlpha = Mathf.Sin(90 * Mathf.Deg2Rad); // 90µµ
        cosAlpha = Mathf.Cos(90 * Mathf.Deg2Rad); // 90µµ
        GetCurrentMinuit();
    }

    private void Update()
    {
        string strCurrentMin = GetCurrentMinuit();
        int currentMin = Int32.Parse(strCurrentMin);

        float cosBeta = Mathf.Cos(-currentMin * 6 * Mathf.Deg2Rad);
        float sinBeta = Mathf.Sin(-currentMin * 6 * Mathf.Deg2Rad);
        transform.position = (vX * (cosAlpha * cosBeta - sinAlpha * sinBeta) * 20) + (vY * (sinAlpha * cosBeta + cosAlpha * sinBeta) *20);
    }
}
