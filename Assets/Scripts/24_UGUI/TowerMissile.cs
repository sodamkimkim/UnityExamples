using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMissile : MonoBehaviour
{
    private float moveSpeed = 10f;
    private int power = 3;

    public int GetPower()
    {
        return power;
    }
    private void Start()
    {
        Destroy(gameObject, 3f);
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider _other)
    {
        if(_other.CompareTag("Target"))
        {
            Target target = _other.GetComponent<Target>();
            target.Damage(power);
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        // 터지는 이펙트 넣어주기
    }
} // end of class
