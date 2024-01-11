using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenuManager : MonoBehaviour
{
    // # �ν����ͷ� ���޹ޱ�
    [SerializeField]
    private RectTransform backPanelTr = null;
    // # �ڽ�������Ʈ�� �� �� GetComponentInChildren���� ã��
    // ã�� �� ���� �� �� ��ũ��Ʈ�� �־������ ���ϰ� ã�� �� ����.
    private UIMenuButtonHolder btnHolder = null;
    private void Awake()
    {
        btnHolder = GetComponentInChildren<UIMenuButtonHolder>();
    }
    public void Init(
        // �迭�� �����̱� ������ ����� ref ���ص� �ȴ�.
        VendingMachine.SButton[] _btnInfos, UIMenuButton.OnClickDelegate _onClickCallback,int _btnColCnt)
    {
        btnHolder.BuildButtons(
            _btnInfos, _onClickCallback, _btnColCnt, backPanelTr.sizeDelta
            );
    }
}
