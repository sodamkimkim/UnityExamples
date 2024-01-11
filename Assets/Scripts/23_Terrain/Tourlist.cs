using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tourlist : MonoBehaviour
{
    [SerializeField]
    private GameObject fxPangPrefab = null;

    [SerializeField]
    private GameObject fxFireBoost = null;

    private CharacterController cc = null;
    private Camera cam = null;
    private float moveSpeed = 1000f;
    private float rotSpeed = 50f;
    private Vector3 camRot = Vector3.zero;

    private void Awake()
    {
        cc = GetComponent<CharacterController>();
        cam = GetComponentInChildren<Camera>();
        camRot = cam.transform.rotation.eulerAngles;
    }

    private void Update()
    {
        MovingProcess();
        LookProcess();
        if (Input.GetMouseButtonDown(0))
            SpawnFxPang();
    }
    private void MovingProcess()
    {
        float axisH = Input.GetAxis("Horizontal");
        float axisV = Input.GetAxis("Vertical");
        GameObject bostGo = null;
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = 5000f;
            Vector3 pos = transform.position;
            pos.y = transform.position.y - transform.localScale.y + 1f;

            bostGo = Instantiate(fxFireBoost, pos, Quaternion.Euler(0f, 0f, 0f));
            bostGo.transform.SetParent(transform);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = 1000f;
            Destroy(bostGo);
        }

        Vector3 camF = cam.transform.forward;
        camF.y = 0f;
        camF.Normalize();
        Vector3 dirF = camF * axisV;

        Vector3 camR = cam.transform.right;
        camR.y = 0f;
        camR.Normalize();
        Vector3 dirR = camR * axisH;

        Vector3 dir = dirF + dirR;
        dir.Normalize();

        // �߷� �����ϰ� �����δ�.
        //cc.Move
        // �߷� ����ϰ� �����δ�. rigidbody���� ��Ȳ������ simpleMove ���� �ȴ�.
        cc.SimpleMove(dir * moveSpeed * Time.deltaTime);
        //cc.Move(dir * moveSpeed * Time.deltaTime);
    }
    private void LookProcess()
    {
        // cam const ���� ��
        const float camRotX = 12.072f;
        const float camRotY = 174.66f;
        const float camRotZ = -3.186f;
        camRot.z = camRotZ;

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        camRot.x += -mouseY * rotSpeed * Time.deltaTime;
        camRot.y += mouseX * rotSpeed * Time.deltaTime;

        // Space������ camRot default�� �ʱ�ȭ
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space");
            camRot.x = camRotX;
            camRot.y = camRotY;
            cam.transform.rotation = Quaternion.Euler(camRot);
        }

        // ī�޶�� ���� ������ ����
        // x�� ȸ�� ����
        if (Mathf.Abs(camRotX - camRot.x) <= 30f)
        {
            cam.transform.rotation = Quaternion.Euler(camRot);
        }
        else
        {
            if (camRot.x < 0)
            {
                camRot.x = camRotX - 30f;
                cam.transform.rotation = Quaternion.Euler(camRot);

            }
            else
            {
                camRot.x = camRotX + 30f;
                cam.transform.rotation = Quaternion.Euler(camRot);
            }
        }
        // y�� ȸ�� ����
        if (Mathf.Abs(camRotY - camRot.y) <= 30f)
        {
            cam.transform.rotation = Quaternion.Euler(camRot);
        }
        else
        {
            if (camRotY > camRot.y )
            {
                camRot.y = camRotY - 30f;
                cam.transform.rotation = Quaternion.Euler(camRot);
            }
            else
            {
                camRot.y = camRotY + 30f;
                cam.transform.rotation = Quaternion.Euler(camRot);

            }
        }
    }
    private void SpawnFxPang()
    {
        Instantiate(fxPangPrefab, cam.transform.position + (cam.transform.forward * 3f), Quaternion.identity);
    }
}
