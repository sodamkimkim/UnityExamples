using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private UIMenuManager menuMng = null;

    private void Start()
    {
        HideMenu();
    }
    public void ShowMenu(
        VendingMachine.SButton[] _btnInfos, UIMenuButton.OnClickDelegate _onClickCallback, int _btnColCnt)
    {
        menuMng.Init(_btnInfos, _onClickCallback, _btnColCnt);
        menuMng.gameObject.SetActive(true);
    }
    public void HideMenu()
    {
        menuMng.gameObject.SetActive(false);
    }
} // end of class
