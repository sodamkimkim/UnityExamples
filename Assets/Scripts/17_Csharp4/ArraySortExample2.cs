using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ArraySortExample2 : MonoBehaviour
{
    public class Human : IComparable<Human>
    {
        public int age = 0;
        public string name = string.Empty;
        public float height = .0f;
        public Human(int _age, string _name, float _height)
        {
            age = _age;
            name = _name;
            height = _height;
        }

        // �������̽��� �Լ��� �������� ���� override�Ⱥ��δ�.��
        int IComparable<Human>.CompareTo(Human _obj)
        {
            Human human = _obj as Human; // c sharp���� �����ϴ� ����ȯ ���. Human���� ��ȯ�� �ȵǴ� ��Ȳ�̸� null�� ���.
                                         // ����� �� ��ȯ�� � �ڷ����� ������ ���� ������ ��ȯ�ϴ°Ŷ� ������ ���� ������ ����.
                                         // �ٵ� �� ������� ���� ���ʿ� �����°� Human�ڷ����ΰ� ���� �Ǵ��ϱ� ������ �����ϰ� �� �� �ִ�.

            // return 1 -1(��������) or -1 1(��������) �ٲ޿� ���� �������� / �������� ����
            if (this.age > human.age) return -1;
            else if (this.age < human.age) return 1;

            return 0;
        }

    } // end of class Human
    // �� ���� Ŭ����
    public class HeightCompare : IComparer<Human>
    {
        int IComparer<Human>.Compare(Human _lhs, Human _rhs)
        {
            Human lhsHuman = _lhs as Human;
            Human rhsHuman = _rhs as Human;

            if (lhsHuman.height > rhsHuman.height)
                return 1;
            if (lhsHuman.height < rhsHuman.height)
                return -1;
            else
                return 0;
        }
    } // end of class HeightCompare
    private int[] iArr = { 3, 6, 8, 1, 4 };
    private Human[] humans = new Human[]
    {
        new Human(24, "Kim", 173.0f),
        new Human(51, "Lee", 168.5f),
        new Human(38, "Kang", 181.3f)
    };
    private void Start()
    {
        // static�Լ��� ��ü �������ص� �Լ� ȣ�� �� �� �ִ�.
        Array.Sort<int>(iArr);

        //foreach (int i in iArr)
        //    Debug.Log(i);

        // �� �Լ��� �־��ָ�, Human ���� CompareTo���� �ȵǾ��־ �� ������� �����Ѵ�.
        Array.Sort<Human>(humans, new HeightCompare());
        foreach (Human human in humans)
            Debug.Log(human.age + "/" + human.name + "/" + human.height);
    }
}
