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
        // 버튼 클릭 함수 설정 방법 2. 콜백함수 달아주기
        btn.onClick.AddListener(OnClickListener);
        // 버튼 클릭 함수 설정 방법 3. 람다식 사용
        btn.onClick.AddListener(() => {

            Debug.Log("Lamda Expression");
        });
    }

    // 버튼 클릭 함수 설정 방법 1. Button inspector에서 설정
    public void ClickEvent(string _msg)
    {
        Debug.Log("Button click!: " + _msg);
    }
    private void OnClickListener()
    {
        Debug.Log("OnClick Listener!");
    }
} // end of class

