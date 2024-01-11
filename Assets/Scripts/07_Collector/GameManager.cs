using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject coinPrefab = null;
    [SerializeField]
    private GameObject bombPrefab = null;

    private void Start()
    {
        /*
          # 코루틴 (Co-Routine)
          - 정해진 시간마다 코인, 폭탄 랜덤위치에 만들기 위함.
          - Thread로 Task-Manager만든 것. 

         */
        StartCoroutine(SpawnCoroutine());

    }
    private Vector3 GetRndPos()
    {
        return new Vector3(Random.Range(-20f, 20f), 0f, Random.Range(-20f, 20f));
    }
    private IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            Instantiate(coinPrefab, GetRndPos(), Quaternion.identity);
            Instantiate(bombPrefab, GetRndPos(), Quaternion.identity);

            // # WaitForSeconds
            // Suspends the coroutine execution for the given amount of seconds using scaled time.
            yield return new WaitForSeconds(1f);
        }
    }
}
