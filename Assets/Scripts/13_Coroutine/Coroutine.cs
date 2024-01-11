using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coroutine : MonoBehaviour
{
    /*
     StartCoroutine()�ϸ� ���ο� ��ü�� �����Ǵ� �����̱� ������ 
    �޸� �ּҸ� ���� ���� �� �޸𸮸� StopCoroutine()�Ѵ�.
     */
    private UnityEngine.Coroutine coroutineExample = null;
    private void Start()
    {
        // # coroutine�� Multi - Threading���� ����
        // # CouroutineExample()�� task manager�� ��� ��
        coroutineExample = StartCoroutine(CoroutineExample());
        StartCoroutine(CountCoroutine());
        StartCoroutine("CountCoroutine");
    } // end of Start()
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            // Ư�� Coroutine stop
            StopCoroutine(coroutineExample);
        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            // CountCoroutine()���ڿ��� start ������ ���ڿ��� stop
            StopCoroutine("CountCoroutine");
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            // ��� Coroutine ����
            // ���� ��ũ��Ʈ���� ��������Ÿ� stop
            // �� �� taskmanager�� ��ũ��Ʈ�� �ϳ�����������ٴ� ��.
            StopAllCoroutines();
        }
    } // end of Update()
    private IEnumerator CoroutineExample()
    {
        while (true)
        {
            // # Couroutine
            // �� couroutine ������ ��ȯŸ�� IEnumerator����� ��.
            // couroutine�� ���ѷ��� �ȵ��� ��Ȳ������ �Լ� ������ ����.
            Debug.Log("1");
            // # WaitForSeconds
            //  �� Suspends the coroutine execution for the given amount of seconds using scaled time.
            yield return new WaitForSeconds(1f);
            Debug.Log("2");

            // # yield return - �ߴ���
            // �� ��� CPU��� ���� ��ȯ
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
            // ���ð��� ������ �� �������� �絵�ϴ� �� (���� ���ٰ� ���ƿ�)
            // �ѹ�¦ �ι�¦ ����¦ ���̿� frame�� �׷��� term�� ��. 
            yield return null;

            // # yield break
            // ������ �� �ڷ�ƾ ����
            // stopCoroutine�� �ۿ���, yield break�� �Լ� ������ �����Ű�� ��.
            yield break;

        }
    } // end of CountCoroutine()
} // end of class
