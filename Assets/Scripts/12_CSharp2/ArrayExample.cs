using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayExample : MonoBehaviour
{
    [SerializeField]
    private int[] arr = { 1, 2, 3 };
    [SerializeField]
    private int[] newArr = new int[5];
    [SerializeField]
    private int[] nullArr = null;

    private void Start()
    {
        Debug.Log("arr Length: " + arr.Length);
        Debug.Log("arr[0] : " + arr[0]);
        ChangeArrayValue(arr);
        Debug.Log("Change arr[0] : " + arr[0]);

        // # ���� ���� �� <-> ���� ����(clone)
        int[] copyArr = arr;
        object tempNum = arr.Clone();
        Debug.Log("??????????????"+tempNum + arr.Clone());

        // # Range based for statement
        foreach(int i in arr)
        {
            Debug.Log(i);
        }
    }
    // �迭�� reference type
    // ���� ����
    private void ChangeArrayValue(int[] _arr)
    {
        _arr[0] = 100;
    }
}
