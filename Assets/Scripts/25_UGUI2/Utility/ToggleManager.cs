using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleManager : MonoBehaviour
{
    public void OnValueChange(bool _isOn)
    {
        Debug.Log("OnValueChanged" + _isOn);
    }
} // end of class

