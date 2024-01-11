using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class pr_PathFinder : MonoBehaviour
{
    private NavMeshAgent agent = null;
    private Flag[] pathFlags = null;
    private int curIdx = 0;
    private bool isMoving = false;

    private void Awake()
    {

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
        while (curIdx != pathFlags.Length)
        {
            agent.SetDestination(pathFlags[curIdx].GetPosition());
            while (true)
            {
                Vector3 firstPos = transform.position;
                firstPos.y = 0f;
                Vector3 secondPos = pathFlags[curIdx].GetPosition();
                secondPos.y = 0f;

                float dist = Vector3.Distance(firstPos, secondPos);
                if (dist < 1f) break;

                yield return null;
            }

            ++curIdx;
            yield return new WaitForSeconds(0.5f);
        }
        isMoving = false;
    }
} // end of PathFinder
