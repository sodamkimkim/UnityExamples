using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterball : MonoBehaviour
{
    private WaterballSmoke waterballSmoke = null;

    private void Awake()
    {
        waterballSmoke = GetComponentInChildren<WaterballSmoke>();
        waterballSmoke.SetCollisionCallback(CallDestroy);
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * -50f * Time.deltaTime);
    }
    public void CallDestroy()
    {
        Destroy(gameObject);
    }
}
