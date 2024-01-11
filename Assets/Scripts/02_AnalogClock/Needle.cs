using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Needle : MonoBehaviour
{
    //[SerializeField, Range(0f, 360f)]
    private float angle = 0f;
    [SerializeField]
    private float radius = 1f;

    private void Update()
    {
        // 1초당 움직일 각도
        float angleOffset = 360f / 60f;
        float sec = Time.time % 60f;
        angle = sec * angleOffset;

        float x = Mathf.Cos(angle * (Mathf.PI / 180f)) * radius;
        float y = Mathf.Sin(angle * Mathf.Deg2Rad) * radius;

        transform.position =
            // 동적할당(Dynamic Allocate)
            new Vector3(x, y, 0.0f);

        //Debug.Log("Time: " + (Time.time % 60f));
    }
}
