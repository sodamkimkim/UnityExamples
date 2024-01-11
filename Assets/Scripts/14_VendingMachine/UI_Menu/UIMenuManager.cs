using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenuManager : MonoBehaviour
{
    // # 인스펙터로 전달받기
    [SerializeField]
    private RectTransform backPanelTr = null;
    // # 자식컴포넌트를 알 때 GetComponentInChildren으로 찾기
    // 찾을 일 있을 때 빈 스크립트라도 넣어놓으면 편하게 찾을 수 있음.
    private UIMenuButtonHolder btnHolder = null;
    private void Awake()
    {
        btnHolder = GetComponentInChildren<UIMenuButtonHolder>();
    }
    public void Init(
        // 배열은 참조이기 때문에 여기는 ref 안해도 된다.
        VendingMachine.SButton[] _btnInfos, UIMenuButton.OnClickDelegate _onClickCallback,int _btnColCnt)
    {
        btnHolder.BuildButtons(
            _btnInfos, _onClickCallback, _btnColCnt, backPanelTr.sizeDelta
            );
    }
}
