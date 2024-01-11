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
            // 밑의 방식대로 newX값을 보간하면(tr.position.x 사용) 시작과 끝점과의 거리가 점점 줄어드니까
            // tr.position.x -> endX까지 가는 속도가 점점 빨라진다.
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
            // Show()하고 있던 경우 -> 그 자리에서 Hide()
            if (isShow)
            {
                _startX = tr.position.x;
                _endX = -rt.sizeDelta.x;

                // Hide()하고 있던 경우 -> 그 자리에서 Show()
            }
            else
            {
                _startX = tr.position.x;
                _endX = 0f;
            }

        }
    }
} // end of class
