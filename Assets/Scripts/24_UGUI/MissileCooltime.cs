using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissileCooltime : MonoBehaviour
{
    public delegate void LaunchMisileDelegate();
    private LaunchMisileDelegate cooltimeFinishCallback = null;

    // cooltime 시간 정하기
    private float duration = 1.5f;

    private Image uiImage = null;
    // isReady == false이면 cooltime중이니까 콜백함수 수행 x(ex, 아직 미사일 장전 중이다.)
    private bool isReady = true;
    private bool isCooltimeStart = false;
    
    private void Awake()
    {
        uiImage = GetComponent<Image>();
    }
    public void SetIsCooltimeStart()
    {
        isCooltimeStart = true;
    }
    private void Update()
    {
        if (isReady == true && isCooltimeStart == true)
        {
            StartCoroutine(CooltimeCoroutine());
        }
    }
    public void SetMissileCooltimeCallback(LaunchMisileDelegate _callback)
    {
        cooltimeFinishCallback = _callback;
    }
    private IEnumerator CooltimeCoroutine()
    {
        isReady = false;
        float amount = 0f;
        while (amount < 1f)
        {
            uiImage.fillAmount = amount;
            amount += Time.deltaTime / duration;
            yield return null;
        }
        uiImage.fillAmount = 1f;
        isReady = true;

        cooltimeFinishCallback?.Invoke();
    }

} // end of class
