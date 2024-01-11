using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coroutine : MonoBehaviour
{
    /*
     StartCoroutine()하면 새로운 객체가 생성되는 개념이기 때문에 
    메모리 주소를 따로 만들어서 그 메모리를 StopCoroutine()한다.
     */
    private UnityEngine.Coroutine coroutineExample = null;
    private void Start()
    {
        // # coroutine은 Multi - Threading으로 돌림
        // # CouroutineExample()을 task manager에 등록 ㄱ
        coroutineExample = StartCoroutine(CoroutineExample());
        StartCoroutine(CountCoroutine());
        StartCoroutine("CountCoroutine");
    } // end of Start()
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            // 특정 Coroutine stop
            StopCoroutine(coroutineExample);
        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            // CountCoroutine()문자열로 start 했으면 문자열로 stop
            StopCoroutine("CountCoroutine");
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            // 모든 Coroutine 정지
            // 현재 스크립트에서 만들어진거만 stop
            // ㄴ 즉 taskmanager는 스크립트에 하나씩만들어진다는 뜻.
            StopAllCoroutines();
        }
    } // end of Update()
    private IEnumerator CoroutineExample()
    {
        while (true)
        {
            // # Couroutine
            // ㄴ couroutine 쓰려면 반환타입 IEnumerator해줘야 함.
            // couroutine은 무한루프 안도는 상황에서는 함수 끝나면 끝남.
            Debug.Log("1");
            // # WaitForSeconds
            //  ㄴ Suspends the coroutine execution for the given amount of seconds using scaled time.
            yield return new WaitForSeconds(1f);
            Debug.Log("2");

            // # yield return - 중단점
            // ㄴ 잠깐만 CPU사용 권한 반환
            yield return new WaitForSeconds(1f);
            Debug.Log("3");
        }
    } // end of CoroutineExample()
    private IEnumerator CountCoroutine()
    {
        while (true)
        {
            Debug.Log("-");
            yield return new WaitForSeconds(0.3f);

            // # yield return null
            // 대기시간은 없지만 한 프레임은 양도하는 것 (권한 갔다가 돌아옴)
            // 한발짝 두발짝 세발짝 사이에 frame이 그려질 term을 줌. 
            yield return null;

            // # yield break
            // 만나면 이 코루틴 종료
            // stopCoroutine은 밖에서, yield break는 함수 내에서 종료시키는 것.
            yield break;

        }
    } // end of CountCoroutine()
} // end of class
