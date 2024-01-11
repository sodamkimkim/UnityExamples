using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent (typeof(Rigidbody))]
public class Jump : MonoBehaviour
{
    private Rigidbody rb = null;
    private bool onGround = false;
    private float jumpForce = 5f;
    private void Start()
    {
        gameObject.AddComponent<BoxCollider>();
        rb = gameObject.AddComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
    }
    private void Update()
    {
        if(onGround == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
;    }
    private void OnCollisionEnter(Collision _collision)
    {
        if(_collision.gameObject.CompareTag("Floor"))
        {
            onGround = true;
        }
    }
    private void OnCollisionExit(Collision _collision)
    {
        if(_collision.gameObject.CompareTag("Floor"))
        {
            onGround = false;
        }
    }

}
