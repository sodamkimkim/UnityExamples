using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1. 광고 이미지 추가할 수 있어야함
// 2. 이미지 변경 시간(간격)설정
// 3. 순차적 or 무작위?
public class AdPanel : MonoBehaviour
{
    [SerializeField]
    private Texture2D[] adImgs = null;
    [SerializeField]
    private float interval = 0.5f;
    [SerializeField]
    private bool shuffle = false;

    private MeshRenderer mr = null;
    private void Awake()
    {
        mr = GetComponent<MeshRenderer>();

    }

    private void Start()
    {
        if (adImgs == null || adImgs.Length == 0)
            return;
        mr.material = Resources.Load<Material>("Materials\\M_AdPanel_W");
        StartCoroutine(ChangeImageCoroutine());
    }
    private IEnumerator ChangeImageCoroutine()
    {
        int idx = 0;
        while (true)
        {
            if (!shuffle)
            {
                mr.material.mainTexture = adImgs[idx];
                ++idx;
                if (idx >= adImgs.Length) idx = 0;
                //idx %= adImgs.Length;
            }
            else
            {
                // # 배열 인덱스 랜덤함수 돌릴 때, int 매개변수 오버로딩된 거 쓴다. 이때 주의할 점은 int maxExclusive라는 것.
                //Random.Range(int minInclusive, int maxExclusive)
                //Random.Range(float minInclusive, float maxInclusive)
                mr.material.mainTexture = adImgs[Random.Range(0, adImgs.Length)]; 
            }
            yield return new WaitForSeconds(interval);
        }
    }
} // end of class
