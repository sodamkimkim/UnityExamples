using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerLamp : MonoBehaviour
{
    private MeshRenderer mr = null;
    private void Awake()
    {
        mr = GetComponentInChildren<MeshRenderer>();
    }
    public void On()
    {
        mr.material.color = new Color(1f, 0f,0f);//red
    }
    public void Off()
    {
        mr.material.color = Color.white;
    }
}
