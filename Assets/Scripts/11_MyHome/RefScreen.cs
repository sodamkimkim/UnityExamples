using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefScreen : MonoBehaviour
{
    private MeshRenderer mr = null;
    private float t = 0f;

    private void Awake()
    {
        mr = GetComponent<MeshRenderer>();
        mr.materials[0].color = Color.black;
        Debug.Log("mr: " + mr);

    }

    public void On()
    {
        mr.enabled = true;
        ChangeColor();
    }

    public void Off()
    {
        //mr.enabled = false;
        mr.materials[0].color = Color.black;
    }

    private void ChangeColor()
    {
        Debug.Log(gameObject.name + " ChangeColor()");
        //mr.materials[0].color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

            mr.materials[0].color = Random.ColorHSV(0f, 1f, 1f, 1f*t, 0.5f, 1f);
       
   

    }

} // end of class

