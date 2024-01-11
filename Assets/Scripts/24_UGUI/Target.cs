using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public delegate void DestroyCallback();
    private DestroyCallback destroyCallback = null;
    private HpBarHolder hpBarHolder = null;
    private DefenceTower defenceTower = null;
    private readonly int maxHp = 10;

    // Target�� damaged������ effect
    [SerializeField]
    private GameObject damagedPSPrefab = null;

    // Target�� �ı��� �� effect
    [SerializeField]
    private GameObject explosionPSPrefab = null;

    private int hp = 0;


    public void Init(Vector3 _pos, DestroyCallback _destroyCallback, HpBarHolder _hpBarHolder, DefenceTower _defenceTower)
    {
        transform.position = _pos;
        destroyCallback = _destroyCallback;
        hpBarHolder = _hpBarHolder;
        hpBarHolder.gameObject.SetActive(true);
        hpBarHolder.SetPosition(_pos);
        defenceTower = _defenceTower;
        transform.LookAt(_defenceTower.GetTransform(), Vector3.up); // ������ �ٶ� ����, ȸ�� ���� �� ����.
        hp = maxHp;
        hpBarHolder.UpdateHpBar(maxHp, hp);

    }
    public void Damage(int _power)
    {
        hp -= _power;
        Instantiate(damagedPSPrefab, transform.position + Vector3.up * 2, Quaternion.Euler(0f, 0f, 0f));
        if (hp < 0)
        {
            hp = 0;
            // �ı� ����Ʈ 
            //Destroy(gameObject); ������ �ı� x ��Ȱ���ϱ�!
            Instantiate(explosionPSPrefab, transform.position + Vector3.up * 2, Quaternion.Euler(0f, 0f, 0f));
            destroyCallback?.Invoke();
        }
        hpBarHolder.UpdateHpBar(maxHp, hp);
    }
} // end of class 
