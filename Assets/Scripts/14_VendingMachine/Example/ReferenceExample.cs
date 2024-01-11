using UnityEngine;

public class ReferenceExample : MonoBehaviour
{
    //public class SStruct
    public struct SStruct
    {
        public int i;
        public SStruct(int _i) { i = _i; }
    }
    private void Start()
    {
        SStruct[] structs =
        {
            new SStruct(1),
            new SStruct(2),
            new SStruct(3)
        };
        ChangeWithArray(structs);
        Debug.Log("structs[0]: "+ structs[0].i); //100
        Debug.Log("structs[1]: " + structs[1].i);//200
        Debug.Log("structs[2]: " + structs[2].i); // 3
    }
    // 1. ����ü�� �迭�� �־� ������ ������.
    // 2. �迭��Ҹ� ���� ����?  ������ ������ �ϴ°�? o
    private void ChangeWithArray(SStruct[] _structs)
    {
        _structs[0].i = 100;
        ChangeWithRef(ref _structs[1]);
        ChangeWithNew(_structs[2]);
    }
    private void ChangeWithRef(ref SStruct _struct)
    {
        _struct.i = 200;
    }
    // 3. ����ü�ϳ��� ���� ���� ���縦 �ϴ� ���? -> x
    // ���޹޴� ���� ���������� ���ο� ����ü�� ����� ����.deep����(������) vs ��������(�ּ� ����) => ���⼱ deep���� �Ͼ
    // ������� ������ϰ� �ٷ� �� �ٲ����� �����ε�..
    private void ChangeWithNew(SStruct _struct)
    {
        SStruct newStruct = _struct;
        newStruct.i = 300;
    }
    // sol)
    // struct -> class
    // �⺭���� �̿���ϰ� �ٷ� ref struct ���
}
