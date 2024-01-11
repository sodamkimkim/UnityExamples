using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BtnClick : MonoBehaviour
{
    [SerializeField]
    private Button btn = null;
    private void Start()
    {
        // ��ư Ŭ�� �Լ� ���� ��� 2. �ݹ��Լ� �޾��ֱ�
        btn.onClick.AddListener(OnClickListener);
        // ��ư Ŭ�� �Լ� ���� ��� 3. ���ٽ� ���
        btn.onClick.AddListener(() => {

            Debug.Log("Lamda Expression");
        });
    }

    // ��ư Ŭ�� �Լ� ���� ��� 1. Button inspector���� ����
    public void ClickEvent(string _msg)
    {
        Debug.Log("Button click!: " + _msg);
    }
    private void OnClickListener()
    {
        Debug.Log("OnClick Listener!");
    }
} // end of class

