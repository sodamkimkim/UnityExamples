using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooltime : MonoBehaviour
{
    public delegate void FinishDelegate();
    private FinishDelegate finishCallback = null;

    [SerializeField]
    private float duration = 1f;

    private Image uiImage = null;
    private bool isReady = true;

    private void Awake()
    {
        uiImage = GetComponent<Image>();
    }
    private void Update()
    {
        if (isReady == true && Input.GetKeyDown(KeyCode.C))
        {
            StartCoroutine(CooltimeCoroutine());
        }
    }
    private IEnumerator CooltimeCoroutine()
    {
        isReady = false;
        float amount = 0f;
        while (amount < 1f)
        {
            uiImage.fillAmount = amount;

            amount += Time.deltaTime / duration;
            Debug.Log("amount: " + amount + " : " + Time.deltaTime);
            yield return null;
        }
        uiImage.fillAmount = 1f;
        isReady = true;

        // 쿨 타임 후 수행할 콜백함수 받았으면 수행.
        finishCallback?.Invoke();
    }
} // end of class
