using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour
{
    private void Awake()
    {
        // # object 이름바꾸기
        gameObject.name = "MyCapsule";
        // # collider제어
        GetComponent<CapsuleCollider>().isTrigger = true;

        // # component 활성화 비활성화 - enabled =  true / false;
        GetComponent<CapsuleCollider>().enabled = false;

        // # gameObject의 active상태 확인 및 활성화/ 비활성화 - SetActive(true / false)
        // 비활성화 시키면 존재는 하지만 메모리 참조할 수 없다.
        gameObject.SetActive(false);
        Debug.Log("Capsule Active: " + gameObject.activeSelf);
        
    }
}
