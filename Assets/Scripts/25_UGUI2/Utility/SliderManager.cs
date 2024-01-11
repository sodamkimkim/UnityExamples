using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderManager : MonoBehaviour
{
    public void OnValueChanged(float _value)
    {
        Debug.Log("Slider: " + _value);
    }
} // end of class
