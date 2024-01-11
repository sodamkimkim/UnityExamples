using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    private float movingSpeed = 10f;
    private void Moving()
    {
        transform.Translate(Vector3.up * movingSpeed * Time.deltaTime);
    }
    private void Update()
    {
        Moving();
    }
}
