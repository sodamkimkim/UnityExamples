using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderController : MonoBehaviour
{
    // bool, Boolean = true, false
    [SerializeField] private bool useAuto = false;

    private float moveSpeed = 10f;

    private readonly float XMIN = -5f;
    private const float XMAX = 5f;

    private float t = 0f;

    private void InputProcess()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(
                Vector3.left * moveSpeed * Time.deltaTime);

            if (transform.position.x < XMIN)
            {
                //transform.position.x = XMIN;
                Vector3 newPos = transform.position;
                newPos.x = XMIN;
                transform.position = newPos;
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(
                Vector3.right * moveSpeed * Time.deltaTime);

            if (transform.position.x > XMAX)
            {
                Vector3 newPos = transform.position;
                newPos.x = XMAX;
                transform.position = newPos;
            }
        }
    }

    private void AutoMovingProcess()
    {
        t += Time.deltaTime;
        if (t > 1f) t = 0f;

        //Vector3.Lerp
        // Lerp: Linear-Interpolation(선형보간)
        float lerpX = Mathf.Lerp(XMIN, XMAX, t);
        Vector3 newPos = transform.position;
        newPos.x = lerpX;
        transform.position = newPos;
    }

    private void Update()
    {
        // if (useAuto == false)
        if (!useAuto) InputProcess();
        else AutoMovingProcess();
    }

    // Callback Function
    private void OnCollisionEnter(Collision _collision)
    {
        //Debug.Log("Collision Enter: " +
        //          _collision.gameObject.name);
    }

    private void OnCollisionStay(Collision _collision)
    {
        //Debug.Log("Collosion Stay: " +
        //          _collision.gameObject.name);
    }

    private void OnCollisionExit(Collision _collision)
    {
        //Debug.Log("Collision Exit: " +
        //          _collision.gameObject.name);
    }
}
