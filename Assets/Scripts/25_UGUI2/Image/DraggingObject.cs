using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// #  Singleton pattern
// 1. �����ϰ� �����Ǵ� ��ü
// 2. ��𼭵� ������ �����ؾ� ��.
public class DraggingObject
{
    // drag���� gameobject�� �־��� ����
    public GameObject draggingObj = null;

    // static�� ��ü�� �ȸ��� ������ ���� �����ϴ�.
    static private DraggingObject instance = null;

    // singleton ��ü getter
    static public DraggingObject Instance
    {
        get
        {
            if (instance == null)
                instance = new DraggingObject();
            return instance;
        }
    }
    // ������ privateó��
    private DraggingObject()
    {
    }

} // end of class
