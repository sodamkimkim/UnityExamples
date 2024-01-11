using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class pr_ComponentTest : MonoBehaviour
{
    private Rigidbody rb = null;
    private Transform[] trs = null;

    private void Awake()
    {
        rb = gameObject.AddComponent<Rigidbody>();
        if(rb == null)
        {
            GetComponent<Rigidbody>();
        }

        trs = GetComponentsInChildren<Transform>();
        for(int i = 0; i<trs.Length; i++)
        {
            Debug.Log(trs[i].name);
        }
        Transform childtr = GetComponentInChildren<Transform>();
        Debug.Log("childtr name : " + childtr.name);

        Capsule capsule = GetComponentInChildren<Capsule>();
      Rigidbody capsuleRb =   capsule.gameObject.AddComponent<Rigidbody>();
        capsuleRb.useGravity = false;

        Destroy(capsule);
        Destroy(capsule.gameObject);

    }
}
