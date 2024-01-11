using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitFx : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 0.1f);
    }
    private void Update()
    {
        // 1초뒤에 파괴되는데, 파괴되기 전까지 계속 증가
        transform.localScale =
            transform.localScale + (Vector3.one * Time.deltaTime);
    }
}
