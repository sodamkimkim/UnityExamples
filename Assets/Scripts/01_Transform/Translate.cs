// OOP(Object-Oriented Programming)
// 객체지향프로그래밍
// Name-Space(네임스페이스)
using System.Collections;
using System.Collections.Generic;
//using UnityEngine;

// 상속(Inheritance)
public class Translate : UnityEngine.MonoBehaviour
{
    // 클래스 멤버 변수
    // (Class Member Variables)
    // 멤버 접근 범위 지정자
    // (Member Access Modifiers)
    // public, private, protected
    private int value = 10;

    // 클래스 객체(Class-Object)
    private UnityEngine.Transform tr = null;

    // 캡슐화(Encapsulation)

    // Function, Method
    public void Func()
    {
        UnityEngine.Debug.Log(
            "value: " + value);
    }

    // Unity Script Life-Cycle
    // 1 Frame
    // FPS(Frame Per Seconds)
    private void Start()
    {
        UnityEngine.Debug.Log("Start");

        // Template
        tr = GetComponent<
            UnityEngine.Transform>();
        if (tr == null)
        {
            UnityEngine.Debug.LogError(
                "tr is null!");
        }

        //tr.position =
        //    tr.position +
        //    (UnityEngine.Vector3.right * 2f);
    }

    private void Update()
    {
        //tr.Translate
        tr.position =
            tr.position +
            (UnityEngine.Vector3.right * 2f * UnityEngine.Time.deltaTime);
    }
}
