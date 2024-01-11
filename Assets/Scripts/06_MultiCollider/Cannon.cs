using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private GameObject hitFXPrefab = null;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            // # ���1)  ���� ���콺 ��ġ�� ����� ���� (Screen -> World), ���� ������ ���� ������ֱ�
            Vector3 screenToWorld =
                Camera.main.ScreenToWorldPoint(
                Input.mousePosition);

            // ���������� �浹 ����
            // # ���2) screenpoint�� �ִ� �Ÿ� ������ǥ���� �׳� �ƿ� ���̷� ����� �ŵ� ����
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // # ������ ������ִ� �ڵ�
            // # out�� ref��� �ּ����� Ű����. out�� �Լ� ���ο��� ���� ���ٴ� ������ �ִ� ��� ���
            if (Physics.Raycast(ray, out hit))
            {
                // hit�ȿ��� ���� hit�� ��ü�� ������ �� �ִ�.
                Debug.Log("(Cannon) Hit: " + hit.transform.name);

                // hit����Ʈ���ٰ� ����Ʈ �־���� �ϴµ�, instantiate�Ű������� ������ rotation���� ����.
                // => Quaternion�⺻ ���� �־��ָ� �ȴ�.
                Instantiate(hitFXPrefab, hit.point, Quaternion.identity);
            }
        }
    
    }
    private void OnTriggerEnter(Collider _other)
    {
        Debug.Log("Collision : " + _other.name);
    }
}
