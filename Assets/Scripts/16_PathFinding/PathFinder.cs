using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathFinder : MonoBehaviour
{
    private NavMeshAgent agent = null;

    private Flag[] pathFlags = null;
    private int curIdx = 0;
    private bool isMoving = false;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void SetPathFlags(Flag[] _pathFlags)
    {
        if (isMoving) return;

        pathFlags = _pathFlags;
        StartCoroutine(MovingCoroutine());
    }

    private IEnumerator MovingCoroutine()
    {
        isMoving = true;

        /*
        - pathFlags.Length까지 돌면서 현재 인덱스 flag찾아감
        */
        while (curIdx != pathFlags.Length)
        {
            agent.SetDestination(
                pathFlags[curIdx].GetPosition());

            /*
           - SetDestination 된 곳까지 가는 동안 PathFinder의 ransform.position는 계속 바뀌니까
           - while 계속 돌리면서 dist 체크
            */
            while (true)
            {
                // 현재 PathFinder의 position
                Vector3 firstPos = transform.position;
                firstPos.y = 0f;
                // 목적지 flag position
                Vector3 secondPos = pathFlags[curIdx].GetPosition();
                secondPos.y = 0f;
                // 현재 flag와 목적지 flag의 distance 계산
                float dist = Vector3.Distance(
                    firstPos, secondPos);
                // if문 true되면 이 while종료. ++curIdx해주고 다음 목적지로 셋팅되는 바깥while문 돈다.
                if (dist < 1f) break;

                yield return null;
            }
            ++curIdx;
            yield return new WaitForSeconds(0.5f);
        }
        // curIdx == pathFlags.Length되면 그만움직인다.
        isMoving = false;
    }
} // end of class PathFinder
