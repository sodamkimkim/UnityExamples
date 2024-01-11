using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField, Range(0f, 360f)]
    private float rotX = 0f;
    [SerializeField, Range(0f, 360f)]
    private float rotY = 0f;
    [Range(0f, 360f)]
    public float rotZ = 0f;

    private void Update()
    {
        transform.rotation =
            Quaternion.Euler(rotX, rotY, rotZ);
    }
}
