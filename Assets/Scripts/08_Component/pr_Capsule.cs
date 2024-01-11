using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pr_Capsule : MonoBehaviour
{
    private void Awake()
    {
        gameObject.name = "MyCapsule";
        GetComponent<CapsuleCollider>().isTrigger = true;
        GetComponent<CapsuleCollider>().enabled = false;
        gameObject.SetActive(true);
        Debug.Log(gameObject.activeSelf);
    }
}
