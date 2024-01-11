using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructExample : MonoBehaviour
{
    // # struct
    [System.Serializable] // ����ü inspector�� �� �� �ֵ��� ����.
    public struct SStruct
    {
        // # ����ü�� ���� �ʱ�ȭ�� �ȵȴ�.
        //public int sInt = 0;
        // # Function Call Overhead : �Լ� ȣ�� ���
        //public int sIntt { get { return sIntt; } }
        //public int sInt { get; set; } // ���� x
        public int sInt;
        public float sFloat;
        public bool sBool;


        // # ����ü�� �����ڴ� Ŭ������ �����ڿ� �޸�
        // default �����ڸ� �����ε� �� �� ����,
        // �����ڸ� ���� �� ��� �ʵ带 �Ű�����ȭ �ؾ� �Ѵ�.
        public SStruct(int _sInt, float _sFloat, bool _sBool)
        {
            sInt = _sInt;
            sFloat = _sFloat;
            sBool = _sBool;

        }

        // ���������� default �� private�̴�.
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
        // # Ŭ���� �⺻������ �����ε�
        //private���� ����� ��ü ������ü�� �ȵȴ�.
        public void CFunc()
        {
            Debug.Log("Class Function!" + cInt);
        }
    } // end of CClass

    // class�� struct�� MonoBehavior�� ��ӹ޾ƾ� inspector���� �� �� �ִ�.
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
        // # Struct�� call by value & stack�� ����
        // ����ü�� �⺻ �����ڴ� �ڵ����� ����� ���� ������ �⺻������ �����ε� �Ұ���.
        // Ŭ������ �⺻������ �⺻ �����ڰ� �����������, ��� ������ �����ڸ� 1���� ������ٸ�(������ �����ε� �߻��ߴٸ�) �⺻�����ڰ� �ڵ��������� �ʴ´�.
        SStruct s = new SStruct();
        s.sInt = 100;
        ChangeValue(s);
        //ChangeValue(ref s);
        s.SFunc();
        // Vector3�� ����ü��
        //MeshRenderer�� Ŭ����


        // # class �� call by reference & heap�� ����
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

    // # ref - out ������
    // �� out�� �Լ� ���ο��� �Ű����� ���� �ٲ�ٴ� ���� �����Ѵ�.
    private void ChangeValue(out int _value)
    {
        _value = 2000;
    }

    // # call by value - �Ű����� Ÿ�� struct�̱� ������ ���� ������ _pos�ٲ���� �ܺο����� �ٲ��� �ʴ´�.
    // Vector3�� ����ü. Transform.position�� �ٷ� �ٲ��� ���� Ŭ���� Transform�� �����ؼ� �ȿ��� position�ٲ���
    private void ChangePosition(Vector3 _pos)
    {
        _pos.x = 100f;
    }

    // # call by reference - �Ű����� Ÿ�� Ŭ�����̱� ������ �ּҷ� �����Ǿ� tr�� position���� �ٲ��.
    private void ChangePosition(Transform _tr)
    {
        _tr.position = new Vector3(100f, 0f, 0f);
    }


}
