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
        // ArrayList는 Boxing, UnBoxing이 필연적이다. 이 과정이 비용이 크게 발생하기 때문에 사용추천 안한다.
        arrList = new ArrayList()
        {
            1,
            3.14f,
            "kim",
            'A',
            123.45f
        };
        // var에는 어떤 자료형이든 들어간다.
        //foreach (var value in arrList)
        //    Debug.Log(value + " : " + value.GetType());

        //double d = (double)arrList[1];
        //arrList.Add("asdf");
        //arrList.Add(123);

        if (arrList.Contains(123))
            Debug.Log("Contain to 123");

        // Sort -> ArrayList는 내부 데이터의 자료형이 다 다르기 때문에 Sort하기 위해서 어떤 기준으로 정렬해야할 지 모른다.
        // IComparable / ICaparer 정의해서 정렬하는 방법 구현해 줘야 한다.
        //arrList.Sort(new StringCompare());
        arrList.Sort();
        foreach (var value in arrList)
            Debug.Log(value);

    }

} // end of class ArrayListExample