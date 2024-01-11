using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform destTr = null;
    [SerializeField]
    private Transform destPtTr = null;
    [SerializeField]
    private LayerMask layerMask;

    private NavMeshAgent agent = null;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        // agent 목적지 지정
        //agent.SetDestination(destTr.position);
        destPtTr.gameObject.SetActive(false);

    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastProcess();
        }
        // 움직이는 중
        if(agent.velocity !=Vector3.zero)
        {
            if (DistanceToDestination() < 0.5f)
                destPtTr.gameObject.SetActive(false);
        }
    }
    private void RaycastProcess()
    {
        // 마우스를 스크린좌표 -> 월드좌표로해야 함.
        // 마우스를 레이 반직선으로 바로 만들어 줌
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        int layerMaskBitFlag = 0;
        layerMaskBitFlag = 1 << LayerMask.NameToLayer("NavMesh"); // 네비메쉬 자리 비트플레그 리턴되는거 or연산
        if (Physics.Raycast(ray, out hit, 1000f, layerMaskBitFlag)) // layerMask만 검사
        {
            //레이어마스크 이용해서 원하는 obj들만 검사할 수 있다.
            //  레이어 마스크 쓰면 이거 없어도 된다.
            Debug.Log("Hit: " + hit.transform.name);
            if (hit.transform.CompareTag("Floor"))
            {
                destPtTr.gameObject.SetActive(true);
                destPtTr.position = hit.point;
                agent.SetDestination(hit.point);
            }
            Debug.Log("Hit: " + hit.transform.name);
        }
    }

    private float DistanceToDestination()
    {
        Vector3 playerPos = transform.position;
        playerPos.y = 0f;
        Vector3 destPos = agent.destination;
        destPos.y = 0f;

        return Vector3.Distance(playerPos, destPos);
    }
} // end of class
