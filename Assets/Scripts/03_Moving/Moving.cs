using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverTextGo = null;
    private bool isGameOver = false;

    private float movingSpeed = 10f;
    private float rotateSpeed = 100f;
    private Rigidbody rb = null;

    private void Awake()
    {
        // 시작하기 전부터 rigidbody 가지고 있도록 Awake에다가 넣어준다.
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (isGameOver) return;

        //MovingWithKey();
        //MovingWithAxis();
        MovingWithVelocity();
        RotateWithKey();
    }

    private void MovingWithKey()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position =
                transform.position +
                // Vector3 월드좌표 기준
                (transform.forward *
                 movingSpeed *
                 Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position =
                transform.position +
                (-transform.forward *
                movingSpeed *
                Time.deltaTime);
        }
    }

    private void MovingWithAxis()
    {
        float axisV = Input.GetAxis("Vertical");
        float axisH = Input.GetAxis("Horizontal");
        float axisJ = Input.GetAxis("Jump");

        //transform.position =
        //    transform.position +
        //    (transform.forward *
        //     axisV *
        //     movingSpeed *
        //     Time.deltaTime);
        transform.Translate(
            Vector3.forward *
            axisV *
            movingSpeed *
            Time.deltaTime);
        transform.Translate(Vector3.right * axisH * movingSpeed * Time.deltaTime);
        transform.Translate(Vector3.up * axisJ * movingSpeed * Time.deltaTime);

    }

    //벽 뚫고 지나가는 문제 - rigidbody, velocity사용. 초당 물리프레임(50fps)이랑 속도 맞춰줌
    private void MovingWithVelocity()
    {
        // velocity쓰려면 무조건 rigidbody있어야 한다.
        float axisV = Input.GetAxis("Vertical");
        float axisH = Input.GetAxis("Horizontal");
        //rb.velocity = new Vector3(axisH * movingSpeed, 0f, axisV * movingSpeed);
        //rb.velocity = transform.forward * axisH * movingSpeed;

        Vector3 dirV = transform.forward * axisV;
        Vector3 dirH = transform.right * axisH;
        Vector3 dir = (dirV + dirH).normalized;
        rb.velocity = dir * movingSpeed;
    }
    private void RotateWithKey()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            Vector3 eulerAngle = transform.rotation.eulerAngles;
            eulerAngle.y -= rotateSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(eulerAngle);

            // 쿼터니언은 +연산 안됨
            //transform.rotation =
            //    transform.rotation +
            //    (Quaternion.Euler(
            //        0f,
            //        rotateSpeed * Time.deltaTime,
            //        0f));
        }

        if (Input.GetKey(KeyCode.E))
        {
            //Vector3 eulerAngle = transform.rotation.eulerAngles;
            //eulerAngle.y += rotateSpeed * Time.deltaTime;
            //transform.rotation = Quaternion.Euler(eulerAngle);

            transform.Rotate(
                Vector3.up,
                rotateSpeed * Time.deltaTime);
        }
    }
    //private void OnTriggerEnter(Collider _other)
    //{
    //    if (_other.CompareTag("Bomb") || _other.CompareTag("Chaser"))
    //    {
    //        isGameOver = true;
    //        gameOverTextGo.SetActive(true);
    //    }
    //}
} // class Moving
