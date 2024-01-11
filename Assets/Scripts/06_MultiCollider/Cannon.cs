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

            // # 방법1)  현재 마우스 위치를 월드로 보냄 (Screen -> World), 이후 반직선 따로 만들어주기
            Vector3 screenToWorld =
                Camera.main.ScreenToWorldPoint(
                Input.mousePosition);

            // 반직선으로 충돌 검출
            // # 방법2) screenpoint에 있는 거를 월드좌표말고 그냥 아예 레이로 만드는 거도 있음
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // # 반직선 만들어주는 코드
            // # out과 ref모두 주소접근 키워드. out은 함수 내부에서 값이 들어간다는 보장이 있는 경우 사용
            if (Physics.Raycast(ray, out hit))
            {
                // hit안에는 현재 hit된 객체의 정보가 들어가 있다.
                Debug.Log("(Cannon) Hit: " + hit.transform.name);

                // hit포인트에다가 이펙트 넣어줘야 하는데, instantiate매개변수로 무조건 rotation값이 들어간다.
                // => Quaternion기본 값을 넣어주면 된다.
                Instantiate(hitFXPrefab, hit.point, Quaternion.identity);
            }
        }
    
    }
    private void OnTriggerEnter(Collider _other)
    {
        Debug.Log("Collision : " + _other.name);
    }
}
