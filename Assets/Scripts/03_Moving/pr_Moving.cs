using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pr_Moving : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverTextGo = null;
    private bool isGameOver = false;
    private float movingSpeed = 10f;
    private Rigidbody rb = null;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (isGameOver) return;
    }
    private void MovingWithVelocity()
    {
        float axisV = Input.GetAxis("Vertical");
        float axisH = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(axisH * movingSpeed, 0f, axisV * movingSpeed);
    }
    private void OnTriggerEnter(Collider _other)
    {
        if(_other.gameObject.tag == "Bomb" || _other.CompareTag("Chaser"))
        {
            isGameOver = true;
            gameOverTextGo.SetActive(true);
        }
    }

}
