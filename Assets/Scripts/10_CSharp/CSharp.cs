//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Cat
//{
//    private string name;
//    private int age;
//    private float weight;

//    // # ������(Constructor)
//     public Cat()
//    {
//        Debug.Log("Cat Constructor");
//        name = "Unknown";
//        age = 1;
//        weight = 1;
//    }
//    // # ������ �����ε�
//    public Cat(string _name, int _age, float _weight)
//    {
//        name = _name;
//        age = _age;
//        weight = _weight;
//    }
//    // # �Ҹ���(Destructor)
//    ~Cat()
//    {
//        Debug.Log("Cat Destructor");
//        // �����Ҵ� ����
//    }
//    // # Property (getter setter)
//    public float Weight
//    {
//        get { return weight; }
//        set { weight = value; }
//    }
//    public void SetName(string _name)
//    {
//        name = _name;
//    }
//    public string GetName()
//    {
//        return this.name;
//    }
//    public void SetAge(int _age)
//    {
//        if (_age <= 0) _age = 1;
//        age = _age;
//    }

//    public void Jump()
//    {
//        Debug.Log(name + " Jump!");
//    }
//    public void Punch()
//    {
//        Debug.Log(name + " Punch!");
//    }
//} // end of class Cat

//// OOP
//// CLR (Common Language Runtime)
//// Smart Pointer - Reference Counter
//// Garbage Collection
//public class CSharp : MonoBehaviour
//{
//    private int val = 0;
//    private CSharp csharp = null;
//    private Cat navi = null;

//    private void Start()
//    {
//        navi = new Cat();
//        navi.SetName("navi");
//        Debug.Log(navi.GetName());
//        navi.Jump();
//        navi.Weight = 10;

//        ////
//        PrintSomething();
//        PrintSomething(10);
//        PrintSomething(10, 0.5f);

//    }
//    private void PrintVal()
//    {
//        Debug.Log("val: " + val);
//    }

//    // # �Լ� �����ε�
//    // - ��ȯ Ÿ���� ���ƾ� �Ѵ�.
//    public void PrintSomething()
//    {
//        Debug.Log("Something");
//    }
//    public void PrintSomething(int _num)
//    {
//        Debug.Log("Something: " + _num);
//    }
//    public void PrintSomething(float _val)
//    {
//        Debug.Log("Something: " + _val);
//    }
//    // # Default Parameter
//    // - Default Parameter�� ������ �־�� �Ѵ�.
//    // - �ٸ� �����ε� �޼���(int _num)�̶� �浹�ϸ� default���°� ȣ��ȴ�.
//    // �� �޼���� int�� �־ ���ư� ��
//    public void PrintSomething(int _num, float _val = 3.14f)
//    {
//        Debug.Log("Somethine: " + _num + " / " + _val);
//    }
//} // end of class CSharp
