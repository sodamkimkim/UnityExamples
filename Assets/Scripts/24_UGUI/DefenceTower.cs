using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceTower : MonoBehaviour
{
    [SerializeField]
    private Transform bodyTopTr = null;
    [SerializeField]
    private GameObject missilePrefab = null;
    [SerializeField]
    private Transform missileSpawnPointTr = null;
    [SerializeField]
    private GameObject fireflowerPrefab = null;
    [SerializeField]
    private MissileCooltime missileCooltime = null;

    private Target target = null;
    private float rotSpeed = 5f;

    // Ÿ�� ��Ÿ�� ���°� ����� ����
    private float cooltime = 0.5f;
    public Transform GetTransform()
    {
        return transform;
    }

    public void SetTarget(Target _target)
    {
        target = _target;
        LookAtTarget();
        StartLaunchMissile();
    }

    public void LookAtTarget()
    {
        if (target == null) return;
        StopCoroutine("LookAtTargetCoroutine");
        StartCoroutine("LookAtTargetCoroutine");
    }
    private IEnumerator LookAtTargetCoroutine()
    {
        //Quaternion startRot = bodyTopTr.rotation;

        // ���⺤�� ���ϱ� :  �����ġ - �� ��ġ -> ����ȭ
        Vector3 dir = (target.transform.position - transform.position).normalized;
        Quaternion endRot = Quaternion.LookRotation(dir, Vector3.up); // ���⺤��, ȸ�� ���� �� ����


        while (true)
        {
            Quaternion newRot = Quaternion.Lerp(bodyTopTr.rotation, endRot, Time.deltaTime * rotSpeed);
            bodyTopTr.rotation = newRot;

            if (Quaternion.Angle(bodyTopTr.rotation, endRot) < 1f)
                break;
            yield return null;
        }
        bodyTopTr.rotation = endRot;
    }
    private void StartLaunchMissile()
    {
        missileCooltime.SetMissileCooltimeCallback(LaunchMissile);
        StartCoroutine(LaunchMissileCoroutine());
    }
    private IEnumerator LaunchMissileCoroutine()
    {
        while (true)
        {
            missileCooltime.SetIsCooltimeStart();
            yield return new WaitForSeconds(cooltime);
        }
    }
    private void LaunchMissile()
    {
        // Vector3.forward�� �����ָ� ���� �������� �����ִ� �� �̹Ƿ� ����!! missileSpawnPoint�� ���� ���͸� �̿��ؾ� �Ѵ�.
        GameObject go = Instantiate(fireflowerPrefab, missileSpawnPointTr.position  +(missileSpawnPointTr.forward*0.5f), missileSpawnPointTr.rotation);
        go.transform.SetParent(missileSpawnPointTr.transform);
        Instantiate(missilePrefab, missileSpawnPointTr.position, missileSpawnPointTr.rotation);
    }
} // end of class
