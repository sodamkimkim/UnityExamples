using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructExample : MonoBehaviour
{
    // # struct
    [System.Serializable] // 구조체 inspector에 뜰 수 있도록 만듦.
    public struct SStruct
    {
        // # 구조체는 직접 초기화가 안된다.
        //public int sInt = 0;
        // # Function Call Overhead : 함수 호출 비용
        //public int sIntt { get { return sIntt; } }
        //public int sInt { get; set; } // 권장 x
        public int sInt;
        public float sFloat;
        public bool sBool;


        // # 구조체의 생성자는 클래스의 생성자와 달리
        // default 생성자를 오버로딩 할 수 없고,
        // 생성자를 만들 때 모든 필드를 매개변수화 해야 한다.
        public SStruct(int _sInt, float _sFloat, bool _sBool)
        {
            sInt = _sInt;
            sFloat = _sFloat;
            sBool = _sBool;

        }

        // 접근지정자 default 는 private이다.
        public void SFunc()
        {
            Debug.Log("Struct Function! : " + sInt);
        }
    } // end of struct SStruct

    // # class
    [System.Serializable]
    public class CClass
    {
        [SerializeField]
        private int cInt = 0;
        public int CInt
        {
            get { return cInt; }
            set { cInt = value; }
        }
        public CClass()
        {
            cInt = 10;
        }
        // # 클래스 기본생성자 오버로딩
        //private으로 만들면 객체 생성자체가 안된다.
        public void CFunc()
        {
            Debug.Log("Class Function!" + cInt);
        }
    } // end of CClass

    // class나 struct는 MonoBehavior을 상속받아야 inspector에서 쓸 수 있다.
    [SerializeField]
    private SStruct sStruct = new SStruct();
    //private SStruct sStruct = new SStruct {sInt = 10, sBool = true, sFloat = 10f };
    [SerializeField]
    private CClass cClass = new CClass();
    //private CClass cClass = null;
    [SerializeField]
    private MeshRenderer mr = null;

    private void Start()
    {
        // # Struct는 call by value & stack에 저장
        // 구조체는 기본 생성자는 자동으로 만들어 지기 때문에 기본생성자 오버로딩 불가능.
        // 클래스는 기본적으로 기본 생성자가 만들어지지만, 어떠한 형태의 생성자를 1개라도 만들었다면(생성자 오버로딩 발생했다면) 기본생성자가 자동생성되지 않는다.
        SStruct s = new SStruct();
        s.sInt = 100;
        ChangeValue(s);
        //ChangeValue(ref s);
        s.SFunc();
        // Vector3는 구조체다
        //MeshRenderer는 클레스


        // # class 는 call by reference & heap에 저장
        CClass c = new CClass();
        c.CInt = 200;
        ChangeValue(c);
        c.CFunc();

        int value = 0;
        //ChangeValue(ref value);
        ChangeValue(out value);
        Debug.Log("value : " + value);

    }
    //private void ChangeValue(ref SStruct _s)
    private void ChangeValue(SStruct _s)
    {
        _s.sInt = 500;
    }
    private void ChangeValue(CClass _c)
    {
        _c.CInt = 600;
    }
    // # call by value -> call by reference
    // # ref # out
    //private void ChangeValue(ref int _value)
    //{
    //    _value = 1000;
    //}

    // # ref - out 차이점
    // ㄴ out은 함수 내부에서 매개변수 값이 바뀐다는 것을 보장한다.
    private void ChangeValue(out int _value)
    {
        _value = 2000;
    }

    // # call by value - 매개변수 타입 struct이기 때문에 값을 던지고 _pos바꿔봤자 외부에서는 바뀌지 않는다.
    // Vector3는 구조체. Transform.position를 바로 바꾸지 말고 클래스 Transform에 접근해서 안에서 position바꾸자
    private void ChangePosition(Vector3 _pos)
    {
        _pos.x = 100f;
    }

    // # call by reference - 매개변수 타입 클래스이기 때문에 주소로 참조되어 tr의 position값이 바뀐다.
    private void ChangePosition(Transform _tr)
    {
        _tr.position = new Vector3(100f, 0f, 0f);
    }


}
