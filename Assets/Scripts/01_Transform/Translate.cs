// OOP(Object-Oriented Programming)
// ��ü�������α׷���
// Name-Space(���ӽ����̽�)
using System.Collections;
using System.Collections.Generic;
//using UnityEngine;

// ���(Inheritance)
public class Translate : UnityEngine.MonoBehaviour
{
    // Ŭ���� ��� ����
    // (Class Member Variables)
    // ��� ���� ���� ������
    // (Member Access Modifiers)
    // public, private, protected
    private int value = 10;

    // Ŭ���� ��ü(Class-Object)
    private UnityEngine.Transform tr = null;

    // ĸ��ȭ(Encapsulation)

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
