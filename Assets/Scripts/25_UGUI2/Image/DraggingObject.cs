using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// #  Singleton pattern
// 1. 유일하게 생성되는 객체
// 2. 어디서든 접근이 가능해야 함.
public class DraggingObject
{
    // drag중인 gameobject를 넣어줄 변수
    public GameObject draggingObj = null;

    // static은 객체를 안만들어도 변수에 접근 가능하다.
    static private DraggingObject instance = null;

    // singleton 객체 getter
    static public DraggingObject Instance
    {
        get
        {
            if (instance == null)
                instance = new DraggingObject();
            return instance;
        }
    }
    // 생성자 private처리
    private DraggingObject()
    {
    }

} // end of class
