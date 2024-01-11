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
        - pathFlags.Length���� ���鼭 ���� �ε��� flagã�ư�
        */
        while (curIdx != pathFlags.Length)
        {
            agent.SetDestination(
                pathFlags[curIdx].GetPosition());

            /*
           - SetDestination �� ������ ���� ���� PathFinder�� ransform.position�� ��� �ٲ�ϱ�
           - while ��� �����鼭 dist üũ
            */
            while (true)
            {
                // ���� PathFinder�� position
                Vector3 firstPos = transform.position;
                firstPos.y = 0f;
                // ������ flag position
                Vector3 secondPos = pathFlags[curIdx].GetPosition();
                secondPos.y = 0f;
                // ���� flag�� ������ flag�� distance ���
                float dist = Vector3.Distance(
                    firstPos, secondPos);
                // if�� true�Ǹ� �� while����. ++curIdx���ְ� ���� �������� ���õǴ� �ٱ�while�� ����.
                if (dist < 1f) break;

                yield return null;
            }
            ++curIdx;
            yield return new WaitForSeconds(0.5f);
        }
        // curIdx == pathFlags.Length�Ǹ� �׸������δ�.
        isMoving = false;
    }
} // end of class PathFinder
