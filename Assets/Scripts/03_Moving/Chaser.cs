using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    private GameObject playerGO = null;

    [SerializeField, Range(5f, 10f)]
    private float movingSpeed = 8f;

    private void Start()
    {
        playerGO =
            GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (playerGO == null) return;

        if (Vector3.Distance(
            playerGO.transform.position,
            transform.position) > 10f) return;

        // 1. ���� ���ϱ�
        Vector3 dir =
            // �÷��̾� ��ġ
            playerGO.transform.position -
            // ������ ��ġ
            transform.position;
        
        // 2. ���� ����ȭ
        dir.Normalize();

        // 3. �������� �̵�
        transform.position =
            transform.position +
            (dir * movingSpeed * Time.deltaTime);
    }
}
