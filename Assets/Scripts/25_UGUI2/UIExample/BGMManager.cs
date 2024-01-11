using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class BGMManager : MonoBehaviour
{
    [SerializeField]
    private Slider slider = null;
    [SerializeField]
    private TextMeshProUGUI bgmValueTxt = null;
    private AudioSource audiosrc = null;
    private void Awake()
    {
        audiosrc = GetComponent<AudioSource>();
        audiosrc.mute = false;
        audiosrc.Play();
    }
    public void OnValueChanged(float _value)
    {
        Debug.Log("BgmValue : " + _value);
        float newValue = _value * 100;
        bgmValueTxt.text = ((int)newValue).ToString();
        audiosrc.volume = _value;
    }
} // end of class
