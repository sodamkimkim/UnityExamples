using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenuButtonHolder : MonoBehaviour
{
    [SerializeField]
    private GameObject menuBtnPrefab = null;

    private readonly float hOffset = 80f;
    private readonly float vOffset = 80f;

    private int btnTotalCnt = 10;
    private int btnColCnt = 4;

    private List<GameObject> btnList = new List<GameObject>();
    //private void Update()
    //{
    //    // 우리는 지금 월드좌표가 아니라 부모기준 상대위치이기 때문에 간격만 계산하면된다. 월드위치라면 부모위치  + 변화량 해줘야 하는 거임
    //    if (Input.GetKeyDown(KeyCode.B))
    //    {
    //        // TODO
    //        // test

    //    }
    //}

    #region Test Functions
    //public void CreateMenuButton(
    //   VendingMachine.EBeverageType _type, int _price, int _stock, UIMenuButton.OnClickDelegate _onClickCallback, Vector3 _pos)
    //{
    //    // 예외처리
    //    if (menuBtnPrefab == null) { Debug.Log("menuBtnPrefab을 넣어주세요"); return; }

    //    GameObject go = Instantiate(menuBtnPrefab);
    //    //부모가 될 트렌스폼을 넣어서 canvas아래에 ui가 들어가게끔 해 줘야 한다.
    //    // go.transform.parent = transform;
    //    go.transform.SetParent(transform);
    //    // 만들어지는 버튼은 부모를 기준으로 상대좌표로 지정해줘야함
    //    go.GetComponent<RectTransform>().localPosition = _pos;

    //    go.GetComponent<UIMenuButton>().UpdateInfo(_type, _price, _stock, _onClickCallback );
    //}
    //private void BuildTestButtons()
    //{

    //    //if (btnTotalCnt % btnColCnt > 0)
    //    //    lineCnt += 1;
    //    int lineCnt = btnTotalCnt / btnColCnt;
    //    lineCnt += btnTotalCnt % btnColCnt > 0 ? 1 : 0;

    //    Vector3 startPos = new Vector3(-((hOffset * (btnColCnt - 1)) * 0.5f), ((vOffset - 1) * lineCnt) * 0.5f, 0f);
    //    for (int i = 0; i < btnTotalCnt; ++i)
    //    {
    //        Vector3 pos = startPos + new Vector3(hOffset * (i % btnColCnt), -vOffset * (i / btnColCnt), 0f);
    //        CreateMenuButton(VendingMachine.EBeverageType.Cider, 1000, 5, null,pos);
    //    }
    //}
    #endregion

    public void BuildButtons(VendingMachine.SButton[] _btnInfos,
        UIMenuButton.OnClickDelegate _onClickCallback,
        int _btnColCnt, Vector2 _backPanelSize)
    {
        btnTotalCnt = _btnInfos.Length;
        btnColCnt = _btnColCnt;
        if (btnTotalCnt <= 0) btnTotalCnt = 1;
        if (btnColCnt <= 0) btnColCnt = 1;
        if (btnTotalCnt < btnColCnt)
            btnColCnt = btnTotalCnt;

        // 가로 간격 구하기
        float backPanelWidth = _backPanelSize.x;
        float backPanelHeight = _backPanelSize.y;
        float horizontalOffset = backPanelWidth / btnColCnt;
        float horizontalOffsetHalf = horizontalOffset * 0.5f;

        int lineCnt = btnTotalCnt / btnColCnt;
        lineCnt += (btnTotalCnt % btnColCnt) > 0 ? 1 : 0;

        float verticalOffset = backPanelHeight / lineCnt;
        float verticalOffsetHalf = verticalOffset * 0.5f;

        float btnWidth = horizontalOffset * 0.9f;
        float btnHeight = verticalOffset * 0.9f;

        float startPosX = (backPanelWidth * 0.5f * -1f) + horizontalOffsetHalf;
        float startPosY = (backPanelHeight * 0.5f) - verticalOffsetHalf;

        DestroyButtons();
        for (int i = 0; i < btnTotalCnt; ++i)
        {
            GameObject btnGo = Instantiate(menuBtnPrefab);
            btnGo.transform.SetParent(transform);
            UIMenuButton btn = btnGo.GetComponent<UIMenuButton>();
            //btnGo.GetComponent<RectTransform>().localPosition = new Vector3(startPosX + (horizontalOffset * (i % btnColCnt)), startPosY + (verticalOffset * (i / btnColCnt)), 0f);
            btn.SetLocalPosition(
                startPosX + (horizontalOffset * (i % btnColCnt)),
                startPosY - (verticalOffset * (i / btnColCnt)));
            btn.SetSize(btnWidth, btnHeight);

            // 게으른 초기화(Lazy Initialization)
            btn.Init(i, _btnInfos[i], _onClickCallback);
            //btn.UpdateInfo(_btnInfos[i]);

            // 리스트에 게임오브젝트 추가
            btnList.Add(btnGo);
        }
    }
    private void DestroyButtons()
    {
        if (btnList == null) return;
        foreach(GameObject btnGo in btnList)
            Destroy(btnGo); // node내부 GameObject 정리
        
            btnList.Clear(); // node memory 정리

    }

} // end of class
