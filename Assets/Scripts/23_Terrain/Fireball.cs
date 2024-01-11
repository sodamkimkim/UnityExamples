using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    // smoke°¡ Trigger°¨Áö

    private Smoke smoke = null;
    private void Awake()
    {
        smoke = GetComponentInChildren<Smoke>();
        smoke.SetCollisionCallback(CallDestroy);
    }
    private void Update()
    {
        transform.Translate(Vector3.down * 50f * Time.deltaTime);
    }
    public void CallDestroy()
    {
        Destroy(this.gameObject);
    }
}
