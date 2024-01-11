using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// abstract class�� �ܵ����� ��ü �ν��Ͻ�ȭ ����
public abstract class HomeAppliances : MonoBehaviour
{
    private bool isPowerOn = false;
    public virtual void PowerOn()
    {
        isPowerOn = true;
    }
    public virtual void PowerOff()
    {
        isPowerOn = false;
    }
    public abstract void Use();
}
