using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ArrayListExample : MonoBehaviour
{
    private ArrayList arrList = null;
    public class StringCompare : IComparer
    {
        public int Compare(object _lhs, object _rhs)
        {
            return _lhs.ToString().CompareTo(_rhs.ToString());
        }
    }
    private void Start()
    {
        // ArrayList�� Boxing, UnBoxing�� �ʿ����̴�. �� ������ ����� ũ�� �߻��ϱ� ������ �����õ ���Ѵ�.
        arrList = new ArrayList()
        {
            1,
            3.14f,
            "kim",
            'A',
            123.45f
        };
        // var���� � �ڷ����̵� ����.
        //foreach (var value in arrList)
        //    Debug.Log(value + " : " + value.GetType());

        //double d = (double)arrList[1];
        //arrList.Add("asdf");
        //arrList.Add(123);

        if (arrList.Contains(123))
            Debug.Log("Contain to 123");

        // Sort -> ArrayList�� ���� �������� �ڷ����� �� �ٸ��� ������ Sort�ϱ� ���ؼ� � �������� �����ؾ��� �� �𸥴�.
        // IComparable / ICaparer �����ؼ� �����ϴ� ��� ������ ��� �Ѵ�.
        //arrList.Sort(new StringCompare());
        arrList.Sort();
        foreach (var value in arrList)
            Debug.Log(value);

    }

} // end of class ArrayListExample