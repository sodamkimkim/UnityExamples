using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
    //private Player222 player = null;
    //private Button btnCar = null;
    //private Button btnBoat = null;
    //private Button btnBike = null;

    // enum�� Len �־������ �ڵ����� ��� ���� ����� �� �ִ�.
    public enum EType { Car, Boat, Bike, Len };
    public delegate void OnClickWithType(EType _type);

    private Button[] btns = null;
    private void Awake()
    {
        btns = GetComponentsInChildren<Button>();
    }
    public void SetOnClickCallback(EType _type, /*UnityEngine.Events.UnityAction _callback*/
        OnClickWithType _callback)
    {
        // delegate���
        btns[(int)_type].onClick.AddListener(
            () =>
        {
            _callback?.Invoke(_type);
        });
        //btnBoat.onClick.AddListener(OnClickBoat);
        // ���ٽ� ���
        //btnCar.onClick.AddListener(()=>OnClickCar());
        //btnBoat.onClick.AddListener(() => OnClickBoat());

    }

}