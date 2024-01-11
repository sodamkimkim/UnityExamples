using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenu : MonoBehaviour
{
    private Transform tr = null;
    private RectTransform rt = null;
    private bool isAnimation = false;
    private float movingSpeed = 5f;
    private bool isShow = true;

    private void Awake()
    {
        tr = transform;
        rt = GetComponent<RectTransform>();
    }
    private void Start()
    {

   
    }
    private void Update()
    {
        //if (isAnimation == false && Input.GetKeyDown(KeyCode.Space))
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isShow = !isShow;
            if (isShow)
            {
                Show();
            }
            else Hide();
        }
    }
    public void Show()
    {
        StartCoroutine(MovingCoroutine(-rt.sizeDelta.x, 0f));
    }
    public void Hide()
    {
        StartCoroutine(MovingCoroutine(0f, -rt.sizeDelta.x));
    }
    private IEnumerator MovingCoroutine(float _startX, float _endX)
    {
        isAnimation = true;
        Vector3 newPos = Vector3.zero;
        float t = 0f;

        while (t < 1f)
        {
            IsAnimationDestChanging(ref _startX, ref _endX);
            // # Lerp(Linear Intepolation)
            // ���� ��Ĵ�� newX���� �����ϸ�(tr.position.x ���) ���۰� �������� �Ÿ��� ���� �پ��ϱ�
            // tr.position.x -> endX���� ���� �ӵ��� ���� ��������.
            float newX = Mathf.Lerp(tr.position.x, _endX, Time.deltaTime * movingSpeed);
            //float newX = Mathf.Lerp(_startX, _endX, Time.deltaTime * movingSpeed);
            newPos = rt.position;
            newPos.x = newX;
            rt.position = newPos;

            t += Time.deltaTime * movingSpeed;
            yield return null;
        }
        IsAnimationDestChanging(ref _startX, ref _endX);
        newPos = rt.position;
        newPos.x = _endX;
        rt.position = newPos;
        isAnimation = false;
    }
    private void IsAnimationDestChanging(ref float _startX, ref float _endX)
    {
        if (isAnimation == true && Input.GetKeyDown(KeyCode.Space))
        {
            // Show()�ϰ� �ִ� ��� -> �� �ڸ����� Hide()
            if (isShow)
            {
                _startX = tr.position.x;
                _endX = -rt.sizeDelta.x;

                // Hide()�ϰ� �ִ� ��� -> �� �ڸ����� Show()
            }
            else
            {
                _startX = tr.position.x;
                _endX = 0f;
            }

        }
    }
} // end of class
