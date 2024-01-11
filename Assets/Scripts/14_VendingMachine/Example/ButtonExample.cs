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
        // ��ư �̺�Ʈ �����ʿ� �ݹ��Լ� �޾���
        btnExample.onClick.AddListener(OnClickEvent);
    }
    private void Start()
    {
        // ������� �ݹ� ȣ��
        callback = PrintHello;
        if (callback != null)
            callback();

        // ���ݹ��
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
