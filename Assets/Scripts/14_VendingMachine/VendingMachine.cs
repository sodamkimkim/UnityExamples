using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachine : MonoBehaviour
{
    //[SerializeField]
    //private GameObject[] beveragePrefabs = null;
    public enum EBeverageType { Cider, Coke, StrawberryMilk }
    [System.Serializable]
    public struct SButton
    {
        public EBeverageType type;
        public int price;
        public int stock;

        public SButton(EBeverageType _type, int _price, int _stock)
        {
            type = _type;
            price = _price;
            stock = _stock;
        }
    }
    //[SerializeField]
    //private EBeverageType[] beverages = null;

    //[SerializeField]
    //private int[] beverageCnts = null;
    [SerializeField]
    private SButton[] buttons = null;
    [SerializeField]
    private int btnColCnt = 1;

    private GameObject[] beveragePrefabs = null;
    private UIManager uiMng = null;

    private void Awake()
    {
        // ���� �� ����
        // ���� ������� �迭�ε��� �Ű����� ������ �̳ѵ� �׷��� �����ϴ°� ���ϴ�.

        // 1. Find tag
        // 2. Inspector
        // 3. GetComponentInChildren
        beveragePrefabs = Resources.LoadAll<GameObject>("Prefabs\\Beverages");
        //beveragePrefab = Resources.Load<GameObject>("Prefabs\\Beverages\\P_Beverage_Coke");
        GameObject uiMngGo = GameObject.FindGameObjectWithTag("UIManager");
        if (uiMngGo != null)
            uiMng = uiMngGo.GetComponent<UIManager>();
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    if (BuyBeverageWithButtonIndex(0))
        //        SpawnBeverage(buttons[0].type);
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    if (BuyBeverageWithButtonIndex(1))
        //        SpawnBeverage(buttons[1].type);
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha3))
        //{
        //    if (BuyBeverageWithButtonIndex(2))
        //        SpawnBeverage(buttons[2].type);
        //}
        #region �޴���ư
        // ��ư���� �־ ui�Ŵ��� ȣ��
        //if (Input.GetKeyDown(KeyCode.M))
        //    uiMng.ShowMenu(buttons, BuyBeverage, btnColCnt); // �ݹ�� ���� �Լ� ��
        //if (Input.GetKeyDown(KeyCode.N))
        //    uiMng.HideMenu();
        #endregion
    }
    // ����������ִ� �޼���
    private void SpawnBeverage(EBeverageType _type)
    {
        // c#������ enum�� Ŭ�����̱� ������ int�� ����ȯ ����� �Ѵ�.
        // c������ �׳� int �� int�� �����µ�..
        GameObject go = Instantiate(beveragePrefabs[(int)_type]);
        go.transform.position = transform.position + GetRandomPositionWithRadius(2.5f);

    }
    // ������ �޾Ƽ� ���������� �������ִ� �Լ�
    private Vector3 GetRandomPositionWithRadius(float _r)
    {
        float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
        return new Vector3(Mathf.Cos(angle), 0f, Mathf.Sin(angle)) * _r;
    }
    // Ÿ�Թ޾Ƽ� ��� üũ
    public int CheckStock(EBeverageType _type)
    {
        // ******** ����
        // 1. ��� üũ
        // Ÿ���� ���Ǳ⿡ �ִ��� ���� üũ�ؾ���.
        // �ִٰ� ã������ ����� ��ȯ.

        // 2. ���� �����ϰ��� ���� ī��Ʈ -1

        return 0;
    }
    // ��ư�ε��� �޾Ƽ� ��� üũ
    public int CheckStock(int _btnIdx)
    {
        return buttons[_btnIdx].stock;
    }
    // ��ư �ε��� �޾Ƽ� ���� ���� (��� --)�ϴ� �޼���
    private bool BuyBeverageWithButtonIndex(int _btnIdx)
    {
        if (CheckStock(_btnIdx) == 0) return false;
        --buttons[_btnIdx].stock;

        return true;
    }
    public bool BuyBeverage(int _btnIdx, out SButton _newBtnInfo)
    {
        if (buttons == null || buttons.Length == 0 || buttons.Length <= _btnIdx)
        {
            _newBtnInfo = buttons[_btnIdx];
            return false;
        }

        if (BuyBeverageWithButtonIndex(_btnIdx))
        {
            SpawnBeverage(buttons[_btnIdx].type);
            _newBtnInfo = buttons[_btnIdx];
            return true;
        };
        _newBtnInfo = buttons[_btnIdx];
        return false;
    }
    // �÷��̾�� ��ȣ�ۿ�
    public void ShowMenu()
    {
        uiMng.ShowMenu(
            buttons, BuyBeverage, btnColCnt);
    }
    // �÷��̾�� ��ȣ�ۿ�
    public void HideMenu()
    {
        uiMng.HideMenu();
    }
} // end of class
