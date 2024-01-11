using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    [SerializeField]
    private GameObject missilePrefab = null;
    private float movingSpeed = 10f;

    // 1. �̻��� ����
    // - �� ���� �� �߸� �߻� ����
    // - ������ �°ų�, ȭ�� ������ ������ �̻��� ������
    private void LaunchMissile()
    {
        GameObject go = Instantiate(missilePrefab, transform.position, Quaternion.identity);

    }
    private void Moving(float _axis)
    {
        transform.Translate(Vector3.right * _axis * movingSpeed * Time.deltaTime);
    }
    private void Update()
    {
        Moving(Input.GetAxis("Horizontal"));
        if (Input.GetKeyDown(KeyCode.Space))
            LaunchMissile();
    }
}
