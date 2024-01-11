using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//2. �� ����
// - ���� 11��, ���� 5��, 
//- ���� �ϴܺ��� ����
// - ���� ������

// 3. �� �̵�
//- �� �����ӿ� �� ���� �̵�
// ȭ���� �¿� ���� �����ϸ� �Ʒ��� �̵�.
// Ÿ�� ��ġ���� �������� ���� ���� 
// �� ���� �پ��� �ӵ� ����
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

    // Invaders TotalCnt��ŭ ���� �� �������ִ� �Լ�
    private void BuildInvaders()
    {
        DestroyInvaders();
        // <1 invader�� �ð�����ϱ�>
        float oneFrameRenderingTime = 1 / 60f;  // 1�ʴ� 60������ �������̴ϱ� => 1�����Ӵ� �ɸ��� �ð� ���
        float invaderTempIdx = 60 / InvaderTotalCnt;  // 60�� Invader TotalCnt�� ���� �� ���. ������ TotalCnt������ �̿�������, �̵��ϴ� �Ŵ� list���̷� ����� ��.
        float oneInvaderSpawnDuration = oneFrameRenderingTime * invaderTempIdx + 0.005f;
        // coroutine���� invader�ϳ��� �������ֱ�
        StartCoroutine(SpawnInvaderCoroutine(oneInvaderSpawnDuration));
        Invoke("MoveInvaders", 3f);
    }
    private IEnumerator SpawnInvaderCoroutine(float _coolTime)
    {
        // ���� ������ ����
        float startPosX = (InvadersWidth * 0.5f * -1f) + hOffset * 0.5f;
        float startPosY = transform.position.y;
        // ���������鼭 Invader�����ϰ� start-position�������� ����
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
    // ���� Invader�������ִ� �Լ�
    private void SpawnInvader(Vector3 _pos)
    {
        GameObject go = Instantiate(invaderPrefab, _pos, Quaternion.identity);
        go.transform.SetParent(transform);
        go.transform.localPosition = _pos;

        invaderList.Add(go);

    }

    // Invaders ���� Destroy ���ִ� �Լ�
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
                // InvadersMoveRangeX���� x�������� ũ�� Y�� ������ ��ĭ �̵�
                // x�� -�̵�
               
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
