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

    // 타워 쿨타임 도는거 만들어 보기
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

        // 방향벡터 구하기 :  상대위치 - 내 위치 -> 정규화
        Vector3 dir = (target.transform.position - transform.position).normalized;
        Quaternion endRot = Quaternion.LookRotation(dir, Vector3.up); // 방향벡터, 회전 기준 축 지정


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
        // Vector3.forward를 더해주면 월드 기준으로 더해주는 것 이므로 주의!! missileSpawnPoint의 로컬 벡터를 이용해야 한다.
        GameObject go = Instantiate(fireflowerPrefab, missileSpawnPointTr.position  +(missileSpawnPointTr.forward*0.5f), missileSpawnPointTr.rotation);
        go.transform.SetParent(missileSpawnPointTr.transform);
        Instantiate(missilePrefab, missileSpawnPointTr.position, missileSpawnPointTr.rotation);
    }
} // end of class
