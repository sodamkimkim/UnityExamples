using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class FlagPlayer : MonoBehaviour
{
    [SerializeField]
    private Flag[] flagPath = null;

    private NavMeshAgent agent = null;
    private int curIdx = 0;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        if (flagPath == null || flagPath.Length == 0) return;
        //agent.SetDestination(flagPath[curIdx].transform.position);
        agent.SetDestination(flagPath[curIdx].GetPosition());
    }
    private void Update()
    {
        if (IsMoving())
        {
            if(DistanceToDestination() < 0.5f)
            {
                ++curIdx;
                if (curIdx == flagPath.Length)
                    curIdx = 0;
                agent.SetDestination(flagPath[curIdx].GetPosition());
            }
        }
    }
    private bool IsMoving()
    {
        return agent.velocity != Vector3.zero;
    }
    private float DistanceToDestination()
    {
        Vector3 playerPos = transform.position;
        playerPos.y = 0f;
        Vector3 destPos = agent.destination;
        destPos.y = 0f;
        return Vector3.Distance(playerPos, destPos);
    }
}
