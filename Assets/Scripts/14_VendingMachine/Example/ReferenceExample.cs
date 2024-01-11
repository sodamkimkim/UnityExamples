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
    // 1. 구조체를 배열로 넣어 던지면 참조다.
    // 2. 배열요소를 던질 때는?  참조로 던져야 하는가? o
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
    // 3. 구조체하나를 만든 다음 복사를 하는 경우? -> x
    // 전달받는 것이 참조이지만 새로운 구조체를 만들면 복사.deep복사(값복사) vs 얕은복사(주소 참조) => 여기선 deep복사 일어남
    // 멤버변수 저장안하고 바로 값 바꿨으면 참조인데..
    private void ChangeWithNew(SStruct _struct)
    {
        SStruct newStruct = _struct;
        newStruct.i = 300;
    }
    // sol)
    // struct -> class
    // 멤벼변수 이용안하고 바로 ref struct 사용
}
