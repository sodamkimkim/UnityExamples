using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeControl : MonoBehaviour
{

    private HomeAppliances homeAppliances = null;
    private void Update()
    {
        if (homeAppliances == null)
        {
            Debug.Log("homeAppliances == null");
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            homeAppliances.PowerOn();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            homeAppliances.PowerOff();
        }
        else if (Input.GetMouseButtonDown(2))
        {
            homeAppliances.Use();
        }
    }

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.CompareTag("HomeAppliances"))
        {
            homeAppliances = _other.gameObject.GetComponent<HomeAppliances>();
            Debug.Log(_other.gameObject + "in HomeControl");
            homeAppliances.PowerOn();
        }
    }
    private void OnTriggerExit(Collider _other)
    {
        if (_other.CompareTag("HomeAppliances"))
        {
            homeAppliances.PowerOff();
            homeAppliances = null;
    
        }
    }
}
