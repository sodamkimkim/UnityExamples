using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class StringExample : MonoBehaviour
{
    [SerializeField]
    private string str = null;
    [SerializeField]
    private string newStr = new string("String");
    [SerializeField]
    private string hello = "Hello";

    private void Start()
    {
        //newStr[2] = 'R';
        //hello[2] = 'L';
        char[] newStrToArr = newStr.ToCharArray();
        newStrToArr[2] = 'R';
        Debug.Log("newStrToArr length : " + newStrToArr.Length);
        foreach (char c in newStrToArr)
            Debug.Log("newStrToArr : " + c);

        ////
        char[] newHello = hello.ToCharArray();
        Debug.Log("newHello length : " + newHello.Length);
        foreach (char c in newHello)
            Debug.Log("newHello : " + c);

        string[] strList = str.Split(',');
        foreach (string s in strList)
            Debug.Log(s);

        // # 연산자 오버로딩
        // 문자열을 연산자 오버로딩을 통해서 합치면, string요소 각각 메모리 동적할당 되고, 가비지 컬렉터도 동작하게 되기 때문에
        // 비효율이 발생해서 이러한 방법을 사용하는 것을 권장하지 않는다 -> stringBuilder사용
        Debug.Log("Hello" + ", " + "World" + "!");

        // # StringBuilder는 여러개 메모리 동적할당 하지 않고 한개만 만들고 append하는 방식.
        // 다 사용하고 clear, 쓰고 clear하는 방식으로 사용하면 됨.
        StringBuilder sb = new StringBuilder();
        sb.Append("Hello");
        sb.Append(", ");
        sb.Append("World");
        sb.Append("!");
        Debug.Log(sb.ToString());
        sb.Clear();
        Debug.Log(sb.ToString());

        // # string -> int 형변환
        string num = "123";
        int i = int.Parse(num);

    }
} // end of class StringExample
