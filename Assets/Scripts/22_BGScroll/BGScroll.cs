using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    [SerializeField]
    private GameObject bgPrefab = null;
    [SerializeField]
    private int bgCnt = 3;
    [SerializeField, Range(1f, 15f)]
    private float scrollSpeed = 1f;

    // 똑같은 이미지 두개가 자연스럽게 이어지는 간격
    [SerializeField, Range(0f, 100f)]
    private float bgOffset = 8.5f;

    private float boundLeft = 0f; // 이곳을 벗어나면 스크롤 돌아가는거
    private List<Transform> bgList = new List<Transform>();

    private int firstIdx = 0;
    private int lastIdx = 0;

    private void Start()
    {
        BuildBackground();
        firstIdx = 0;
        lastIdx = bgCnt - 1;
        StartCoroutine(ScrollCoroutine());
    }

    private void BuildBackground()
    {
        for (int i = 0; i < bgCnt; ++i)
        {
            GameObject go = Instantiate(bgPrefab, new Vector3(i * bgOffset, 0f, 0f), Quaternion.identity);
            if (go.CompareTag("BGLayer"))
                go.transform.position = transform.position + new Vector3(i * bgOffset, -1.29f, 0f);
            bgList.Add(go.transform);
        }

    }
    private IEnumerator ScrollCoroutine()
    {
        while (true)
        {
            // 움직이기
            foreach(Transform tr in bgList )
            {
                Vector3 newPos = tr.position;
                newPos.x -= scrollSpeed * Time.deltaTime;
                tr.position = newPos;
            }
            // 범위 검사
            if(bgList[firstIdx].position.x <= boundLeft)
            {
                // 위치 옮기기
                Vector3 newPos = bgList[firstIdx].position;
                newPos.x += bgOffset;
                bgList[firstIdx].position = newPos;
                // list에 저장된 프리팹은 0,1,2 그대로 저장되어있고, 스크롤하며 보여지는 인덱스순서는 0,1,2 -> 1,2,0 -> 2,0,1 -> 0,1,2--> 이렇게 변화한다.
                lastIdx = firstIdx;
                firstIdx = (firstIdx  + 1) % bgCnt;

            }
            yield return null;
        }
    }
} // end of class BGScroll
