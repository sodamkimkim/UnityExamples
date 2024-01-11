using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QualityManager : MonoBehaviour
{
    [SerializeField]
    private Button leftBtn = null;
    [SerializeField]
    private Button rightBtn = null;
    [SerializeField]
    private TextMeshProUGUI qualityTxt = null;

    private string[] lmhStr = { "Low", "Middle", "High" };
    private int index = 1;

    private void Awake()
    {
        qualityTxt.text = lmhStr[index];
        leftBtn.onClick.AddListener(OnLeftBtnClick);
        rightBtn.onClick.AddListener(OnRightBtnClick);
    }
    private void Update()
    {
        qualityTxt.text = lmhStr[index];
    }
    public void OnLeftBtnClick()
    {
        --index;
        if(index < 0)
            index = lmhStr.Length-1;
        
        Debug.Log("index: " + index);
    }
    public void OnRightBtnClick()
    {
        ++index;
        if (index > lmhStr.Length-1)
            index = 0;
        Debug.Log("index: " + index);
    }
} // end of class
