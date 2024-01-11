//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Cat
//{
//    private string name;
//    private int age;
//    private float weight;

//    // # 생성자(Constructor)
//     public Cat()
//    {
//        Debug.Log("Cat Constructor");
//        name = "Unknown";
//        age = 1;
//        weight = 1;
//    }
//    // # 생성자 오버로딩
//    public Cat(string _name, int _age, float _weight)
//    {
//        name = _name;
//        age = _age;
//        weight = _weight;
//    }
//    // # 소멸자(Destructor)
//    ~Cat()
//    {
//        Debug.Log("Cat Destructor");
//        // 동적할당 해제
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

//    // # 함수 오버로딩
//    // - 반환 타입은 같아야 한다.
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
//    // - Default Parameter는 끝부터 넣어야 한다.
//    // - 다른 오버로딩 메서드(int _num)이랑 충돌하면 default없는게 호출된다.
//    // 이 메서드는 int만 넣어도 돌아감 ㄱ
//    public void PrintSomething(int _num, float _val = 3.14f)
//    {
//        Debug.Log("Somethine: " + _num + " / " + _val);
//    }
//} // end of class CSharp
