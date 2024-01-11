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

        // # ������ �����ε�
        // ���ڿ��� ������ �����ε��� ���ؼ� ��ġ��, string��� ���� �޸� �����Ҵ� �ǰ�, ������ �÷��͵� �����ϰ� �Ǳ� ������
        // ��ȿ���� �߻��ؼ� �̷��� ����� ����ϴ� ���� �������� �ʴ´� -> stringBuilder���
        Debug.Log("Hello" + ", " + "World" + "!");

        // # StringBuilder�� ������ �޸� �����Ҵ� ���� �ʰ� �Ѱ��� ����� append�ϴ� ���.
        // �� ����ϰ� clear, ���� clear�ϴ� ������� ����ϸ� ��.
        StringBuilder sb = new StringBuilder();
        sb.Append("Hello");
        sb.Append(", ");
        sb.Append("World");
        sb.Append("!");
        Debug.Log(sb.ToString());
        sb.Clear();
        Debug.Log(sb.ToString());

        // # string -> int ����ȯ
        string num = "123";
        int i = int.Parse(num);

    }
} // end of class StringExample
