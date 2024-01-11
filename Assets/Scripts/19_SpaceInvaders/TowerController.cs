using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    [SerializeField]
    private GameObject missilePrefab = null;
    private float movingSpeed = 10f;

    // 1. 미사일 관리
    // - 한 번에 한 발만 발사 가능
    // - 적에게 맞거나, 화면 밖으로 나가면 미사일 없어짐
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
