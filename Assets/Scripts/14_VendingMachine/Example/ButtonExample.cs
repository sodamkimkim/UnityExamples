using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonExample : MonoBehaviour
{
    [SerializeField]
    private Button btnExample = null;
    public delegate void DelegateExample();
    private DelegateExample callback = null;
    private void Awake()
    {
        // 버튼 이벤트 리스너에 콜백함수 달아줌
        btnExample.onClick.AddListener(OnClickEvent);
    }
    private void Start()
    {
        // 옛날방식 콜백 호출
        callback = PrintHello;
        if (callback != null)
            callback();

        // 지금방식
        callback = PrintWorld;
        callback?.Invoke();
    }
    public void OnClickEvent()
    {
        Debug.Log("Button Click Event!");
    }
    private void PrintHello()
    {
        Debug.Log("Hello");
    }
    private void PrintWorld()
    {
        Debug.Log("World");
    }

}
