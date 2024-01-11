using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractVM : MonoBehaviour
{
    public void OnTriggerEnter(Collider _other)
    {
        if(_other.CompareTag("VendingMachine"))
        {
            Debug.Log("vm in");
            _other.GetComponent<VendingMachine>().ShowMenu();
        }
        if(_other.CompareTag("Beverage"))
        {
            _other.GetComponent<Beverage>().Drink();
            Destroy(_other.gameObject);
        }
    }
    public void OnTriggerExit(Collider _other)
    {
        if(_other.CompareTag("VendingMachine"))
        {
            Debug.Log("vm out");
            _other.GetComponent<VendingMachine>().HideMenu();
        }
    }
}
