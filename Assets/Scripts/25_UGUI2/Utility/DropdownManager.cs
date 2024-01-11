using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropdownManager : MonoBehaviour
{
    public void OnValueChanged(int _idx)
    {
        Debug.Log("Dropdown: " + _idx);
    }
} // end of class
