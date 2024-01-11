using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour
{
    private void Awake()
    {
        // # object �̸��ٲٱ�
        gameObject.name = "MyCapsule";
        // # collider����
        GetComponent<CapsuleCollider>().isTrigger = true;

        // # component Ȱ��ȭ ��Ȱ��ȭ - enabled =  true / false;
        GetComponent<CapsuleCollider>().enabled = false;

        // # gameObject�� active���� Ȯ�� �� Ȱ��ȭ/ ��Ȱ��ȭ - SetActive(true / false)
        // ��Ȱ��ȭ ��Ű�� ����� ������ �޸� ������ �� ����.
        gameObject.SetActive(false);
        Debug.Log("Capsule Active: " + gameObject.activeSelf);
        
    }
}
