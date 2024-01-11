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

        // 인터페이스의 함수를 재정의할 때는 override안붙인다.ㄱ
        int IComparable<Human>.CompareTo(Human _obj)
        {
            Human human = _obj as Human; // c sharp에서 권장하는 형변환 방법. Human으로 변환이 안되는 상황이면 null이 뜬다.
                                         // 명시적 형 변환은 어떤 자료형이 들어오던 간에 무조건 변환하는거라 문제가 생길 소지가 많다.
                                         // 근데 이 방법으로 쓰면 애초에 들어오는게 Human자료형인가 부터 판단하기 때문에 안전하게 쓸 수 있다.

            // return 1 -1(오름차순) or -1 1(내림차순) 바꿈에 따라 오름차순 / 내림차순 정렬
            if (this.age > human.age) return -1;
            else if (this.age < human.age) return 1;

            return 0;
        }

    } // end of class Human
    // 비교 전용 클래스
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
        // static함수는 객체 생성안해도 함수 호출 할 수 있다.
        Array.Sort<int>(iArr);

        //foreach (int i in iArr)
        //    Debug.Log(i);

        // 비교 함수를 넣어주면, Human 내에 CompareTo정의 안되어있어도 이 방법으로 정렬한다.
        Array.Sort<Human>(humans, new HeightCompare());
        foreach (Human human in humans)
            Debug.Log(human.age + "/" + human.name + "/" + human.height);
    }
}
