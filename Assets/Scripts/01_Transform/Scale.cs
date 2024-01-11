using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    private void Update()
    {
        //transform.localScale =
        //    Vector3.one *
        //    (Mathf.Abs(Mathf.Sin(Time.time)));

        // Degree
        // Radian
        float x = Mathf.Cos(20f);
        float y = Mathf.Sin(20f);

        transform.position =
            new Vector3(x, y, 0f);
    }
}
