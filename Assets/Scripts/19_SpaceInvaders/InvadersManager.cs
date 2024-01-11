using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//2. 적 생성
// - 가로 11개, 세로 5개, 
//- 좌측 하단부터 시작
// - 생성 시퀀스

// 3. 적 이동
//- 한 프레임에 한 개씩 이동
// 화면의 좌우 끝에 도달하면 아래로 이동.
// 타워 위치까지 내려오면 게임 오버 
// 적 수가 줄어들면 속도 증가
public class InvadersManager : MonoBehaviour
{
    [SerializeField]
    private GameObject invaderPrefab = null;

    private const float hOffset = 3f;
    private const float vOffset = 2f;

    private const int InvaderHCnt = 11;
    private const int InvaderVCnt = 5;
    private const int InvaderTotalCnt = InvaderHCnt * InvaderVCnt;

    private const float InvadersWidth = hOffset * InvaderHCnt;
    private const float InvadersHeight = vOffset * InvaderVCnt;

    private const float InvadersMoveRangeX = InvadersWidth * 0.5f * 1.2f;


    private List<GameObject> invaderList = new List<GameObject>();

    private void Start()
    {
        BuildInvaders();
    }

    // Invaders TotalCnt만큼 생성 및 정렬해주는 함수
    private void BuildInvaders()
    {
        DestroyInvaders();
        // <1 invader당 시간계산하기>
        float oneFrameRenderingTime = 1 / 60f;  // 1초당 60프레임 랜더링이니까 => 1프레임당 걸리는 시간 계산
        float invaderTempIdx = 60 / InvaderTotalCnt;  // 60을 Invader TotalCnt로 나눈 값 계산. 생성은 TotalCnt변수를 이용하지만, 이동하는 거는 list길이로 해줘야 함.
        float oneInvaderSpawnDuration = oneFrameRenderingTime * invaderTempIdx + 0.005f;
        // coroutine으로 invader하나씩 생성해주기
        StartCoroutine(SpawnInvaderCoroutine(oneInvaderSpawnDuration));
        Invoke("MoveInvaders", 3f);
    }
    private IEnumerator SpawnInvaderCoroutine(float _coolTime)
    {
        // 시작 포지션 설정
        float startPosX = (InvadersWidth * 0.5f * -1f) + hOffset * 0.5f;
        float startPosY = transform.position.y;
        // 포문돌리면서 Invader생성하고 start-position기준으로 정렬
        for (int i = 0; i < InvaderTotalCnt; i++)
        {
            SpawnInvader(
                new Vector3(
                    startPosX + (hOffset * (i % InvaderHCnt)),
                    startPosY + (vOffset * (i / InvaderHCnt)),
                    0));
            yield return new WaitForSeconds(_coolTime);
        }
    }
    // 개별 Invader생성해주는 함수
    private void SpawnInvader(Vector3 _pos)
    {
        GameObject go = Instantiate(invaderPrefab, _pos, Quaternion.identity);
        go.transform.SetParent(transform);
        go.transform.localPosition = _pos;

        invaderList.Add(go);

    }

    // Invaders 전부 Destroy 해주는 함수
    private void DestroyInvaders()
    {
        if (invaderList == null) return;
        foreach (GameObject InvaderGo in invaderList)
            Destroy(InvaderGo);

        invaderList.Clear();
    }
    private void MoveInvaders()
    {
        StartCoroutine(MoveInvaderCoroutine(0.05f));
    }

    private IEnumerator MoveInvaderCoroutine(float _coolTime)
    {
        while (true)
        {
            int tempIdx = 0;
            foreach (GameObject invaderGo in invaderList)
            {
                Debug.Log(tempIdx);
                // InvadersMoveRangeX보다 x포지션이 크면 Y축 밑으로 한칸 이동
                // x축 -이동
               
                if (invaderGo.transform.localPosition.x >= InvadersMoveRangeX)
                {
                    invaderGo.transform.localPosition -= new Vector3(0f, vOffset, 0f);
                    invaderGo.transform.localPosition -= new Vector3(hOffset , 0f, 0f);
                    yield return new WaitForSeconds(_coolTime);
                }
                else
                {
                    invaderGo.transform.localPosition += new Vector3(hOffset, 0f, 0f);
                    yield return new WaitForSeconds(_coolTime);
                }
                ++tempIdx;
            }
            yield return new WaitForSeconds(_coolTime);
        }
    }

}
