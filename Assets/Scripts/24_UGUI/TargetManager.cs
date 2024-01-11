using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{

    [SerializeField]
    private GameObject targetPrefab = null;

    [SerializeField]
    private HpBarHolder hpBarHolder = null;

    private float targetSpawnRange = 10f;
    private Target target = null;

    [SerializeField]
    private DefenceTower defenceTower = null;


    public Target GetTarget()
    {
        return target;
    }

    public void SpawnTarget(Target.DestroyCallback _destroyCallback)
    {
        // # Object Pooling
        // �� obj �����Ҵ� �� �س���, �ı��ϸ� ���°� �ƴ϶� ��ġ�� �̵��� ���� ��Ȱ�� �ϴ� ���
        if (target == null)
        {
            GameObject go = Instantiate(targetPrefab);
            target = go.GetComponent<Target>();
        }
        target.Init(GetRandomPosition(targetSpawnRange), _destroyCallback, hpBarHolder, defenceTower);
    }
    private Vector3 GetRandomPosition(float _range)
    {
        Vector3 targetPos = new Vector3(Random.Range(-_range, _range), 0f, Random.Range(-_range, _range));
        Vector3 dtPos = defenceTower.transform.position;
        if (Mathf.Abs(targetPos.x - dtPos.x) < 3f && Mathf.Abs(targetPos.z - targetPos.z) < 3f)
            return GetRandomPosition(targetSpawnRange);
        else
            return targetPos;
    }

} // end of class
