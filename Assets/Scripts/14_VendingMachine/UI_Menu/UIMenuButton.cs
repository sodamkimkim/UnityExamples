using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;
using UnityEngine.UI;

// 1. 버튼 내용 설정
// 2. 버튼을 눌렀을 때 동작 구현
public class UIMenuButton : MonoBehaviour
{
    // delegate는 외부접근 해야해서 public 
    public delegate bool OnClickDelegate(int _btnIdx, out VendingMachine.SButton _btnInfo);
    // 람다 안쓸 때 필요한 delegate함수타입 변수
    private OnClickDelegate onClickCallback = null;

    private TextMeshProUGUI info = null;
    private StringBuilder sb = new StringBuilder();
    private RectTransform rtr = null;

    private Button btn = null;
    // 구조체는 널 초기화 안된다.
    //private VendingMachine.SButton btnInfo;
    private int btnIdx = -1 ;

    private void Awake()
    {
        info = GetComponentInChildren<TextMeshProUGUI>();
        rtr = GetComponent<RectTransform>();
        btn = GetComponent<Button>();
    }
    public void Init(int _btnIdx, VendingMachine.SButton _btnInfo, OnClickDelegate _onClickCallback)
    {
        btnIdx = _btnIdx;
        UpdateInfo(_btnInfo);
        onClickCallback = _onClickCallback;
        btn.onClick.AddListener(OnClickCallback);
        //// 이렇게 쓰면 이벤트 리스너 중복도 안된다. => 버그 방지
        //btn.onClick.AddListener(() => {
        //    _onClickCallback?.Invoke();
        //});
    }
    public void UpdateInfo(VendingMachine.EBeverageType _type, int _price, int _stock)
    {
        //VendingMachine.SButton tmpBtnInfo = new VendingMachine.SButton();
        //tmpBtnInfo.type = _type;
        //tmpBtnInfo.price = _price;
        //tmpBtnInfo.stock = _stock;
        UpdateInfo(new VendingMachine.SButton(_type, _price, _stock));
    }

    public void OnClickCallback()
    {
        VendingMachine.SButton newBtnInfo = new VendingMachine.SButton();
        if ((bool)onClickCallback?.Invoke(btnIdx, out newBtnInfo ))
        {
            // 구매가 됨
            UpdateInfo(newBtnInfo);
        }
        
    }
    /*
     이 스크립트 가 붙는 프리팹은 버튼이라는 ui요소이다.
    ui요소는 원본데이터를 가지고 있는 클래스에 정보를 요청만 해야지 
    vending mc에 접근해서 값을 바꾼다던가 복사본(btninfo = _btninfo)을 만들어서 사용하는 등의 방식을 쓰면
    꼬이는 경우가 많다.
     */
    public void UpdateInfo(VendingMachine.SButton _btnInfo)
    {
        // out 을 쓰면 _btnInfo의 값을 변경해 줘야 함.
        // 여기서는 값을 바꾸진 않기 때문에 ref
        //btnInfo = _btnInfo;

        sb.Clear();

        sb.Append(TypeToName(_btnInfo.type));
        sb.Append("\n"); // 줄바꿈 문자 넣어주던가
        sb.AppendLine(_btnInfo.price.ToString()); // appendline으로 쓰던가
        sb.AppendLine(_btnInfo.stock.ToString());

        info.text = sb.ToString();
        // 델리게이트에 함수 넣었으면 바로 btn.onClick.AddListener(_onClickCallback)형태로 들어갈 텐데, 
        // 함수로 넣은게 아니고 deleate로 전달받기만 했기 때문에 함수형태로 여기서 만들어 줘야 한다.
        // 람다식으로 즉시실행 함수 만들어서 invoke로 콜백호출



        // 람다식 안쓰면 이렇게 해야 한다.
        // 이렇게 쓰면 버튼에 리스너를 변경할 때 지우고 다른걸 달아주는 식으로해야 한다.
        //onClickCallback = _onClickCallback;
        //btn.onClick.AddListener(OnClickCallback);

    }

    private string TypeToName(VendingMachine.EBeverageType _type)
    {
        switch (_type)
        {
            case VendingMachine.EBeverageType.Cider:
                return "사이다";
            case VendingMachine.EBeverageType.Coke:
                return "콜라";
            case VendingMachine.EBeverageType.StrawberryMilk:
                return "딸기우유";
        }
        return "모름";
    }
    public void SetSize(Vector2 _size)
    {
        rtr.sizeDelta = _size;
    }
    public void SetSize(float _width, float _height)
    {
        //rtr.sizeDelta = new Vector2(_width, _height);
        SetSize(new Vector2(_width, _height));
    }
    public void SetLocalPosition(Vector3 _localPos)
    {
        rtr.localPosition = _localPos;
    }
    public void SetLocalPosition(float _x, float _y, float _z = 0f)
    {
        SetLocalPosition(new Vector3(_x, _y, _z));
    }
}
