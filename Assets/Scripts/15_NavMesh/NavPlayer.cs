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
        // agent ������ ����
        //agent.SetDestination(destTr.position);
        destPtTr.gameObject.SetActive(false);

    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastProcess();
        }
        // �����̴� ��
        if(agent.velocity !=Vector3.zero)
        {
            if (DistanceToDestination() < 0.5f)
                destPtTr.gameObject.SetActive(false);
        }
    }
    private void RaycastProcess()
    {
        // ���콺�� ��ũ����ǥ -> ������ǥ���ؾ� ��.
        // ���콺�� ���� ���������� �ٷ� ����� ��
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        int layerMaskBitFlag = 0;
        layerMaskBitFlag = 1 << LayerMask.NameToLayer("NavMesh"); // �׺�޽� �ڸ� ��Ʈ�÷��� ���ϵǴ°� or����
        if (Physics.Raycast(ray, out hit, 1000f, layerMaskBitFlag)) // layerMask�� �˻�
        {
            //���̾��ũ �̿��ؼ� ���ϴ� obj�鸸 �˻��� �� �ִ�.
            //  ���̾� ����ũ ���� �̰� ��� �ȴ�.
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
