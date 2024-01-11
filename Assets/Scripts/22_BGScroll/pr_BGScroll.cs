using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pr_BGScroll : MonoBehaviour
{
    [SerializeField]
    private GameObject bgPrefab = null;
    [SerializeField]
    private int bgCnt = 3;
    [SerializeField, Range(1f, 15f)]
    private float scrollSpeed = 1f;

    [SerializeField, Range(0f, 1000f)]
    private float bgOffset = 8.5f;
    private float boundLeft = 0f;
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
        for (int i = 0; i > bgCnt; ++i)
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
            foreach(Transform tr in bgList)
            {
                Vector3 newPos = tr.position;
                newPos.x -= scrollSpeed * Time.deltaTime;
                tr.position = newPos;
            }
            // 범위 검사
           if(bgList[firstIdx].position.x <=boundLeft)
            {
                // 위치 옮기기
                Vector3 newPos = bgList[firstIdx].position;
                newPos.x += bgOffset;
                bgList[firstIdx].position = newPos;
                lastIdx = firstIdx;
                firstIdx = (firstIdx + 1) % bgCnt;
            }
            yield return null;
        }
    }
} // end of BGScroll
