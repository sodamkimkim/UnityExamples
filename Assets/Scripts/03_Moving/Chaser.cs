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

        // 1. 방향 구하기
        Vector3 dir =
            // 플레이어 위치
            playerGO.transform.position -
            // 추적자 위치
            transform.position;
        
        // 2. 방향 정규화
        dir.Normalize();

        // 3. 방향으로 이동
        transform.position =
            transform.position +
            (dir * movingSpeed * Time.deltaTime);
    }
}
