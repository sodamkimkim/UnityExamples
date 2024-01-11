using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LimitsManager : MonoBehaviour
{
    [SerializeField]
    private Toggle[] limitsToggles = new Toggle[num_toggles];
    private const int num_toggles = 3;

    private void Awake()
    {
        limitsToggles = GetComponentsInChildren<Toggle>();
        limitsToggles[0].isOn = true;
        foreach(Toggle toggle in limitsToggles)
        {
        }
    }
    private void Update()
    {
        TogglesOnlyOneSelect();
    }
    private void TogglesOnlyOneSelect()
    {
        if (limitsToggles[0].isOn == true)
        {
            limitsToggles[1].isOn = false;
            limitsToggles[2].isOn = false;
        }
        else if (limitsToggles[1].isOn == true)
        {
            limitsToggles[0].isOn = false;
            limitsToggles[2].isOn = false;
        }
        else if (limitsToggles[2].isOn == true)
        {
            limitsToggles[0].isOn = false;
            limitsToggles[1].isOn = false;
        }
    }
    public string GetLimitsValue()
    {
        if (limitsToggles[1].isOn)
        {
            //Debug.Log("limittoggle[1] == 5 selected");
            return 5.ToString();
        }
        else if (limitsToggles[2].isOn)
        {
            //Debug.Log("limittoggle[1] == 10 selected");
            return 10.ToString();
        }
        else
        {
            //Debug.Log("limittoggle[0] == All selected");
            limitsToggles[0].isOn = true;
            return "all";
        }
    }

} // end of class
