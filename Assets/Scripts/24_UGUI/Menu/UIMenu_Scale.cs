using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenu_Scale : MonoBehaviour
{
    private Transform tr = null;
    private RectTransform rt = null;

    private bool isAnimation = false;
    private float sizingSpeed = 5f;
    private bool isBig = true;

    private void Awake()
    {
        tr = transform;
        rt = GetComponent<RectTransform>();
    }
    private void Update()
    {
        if (isAnimation == false && Input.GetKeyDown(KeyCode.Alpha2))
        {
            isBig = !isBig;
            if (isBig) ScaleUp();
            else ScaleDown();
        }
    }
    public void ScaleDown()
    {

        StartCoroutine(SizingCoroutine(1f, -1f));
    }
    public void ScaleUp()
    {
        StartCoroutine(SizingCoroutine(-1f, 1f));
    }
    private IEnumerator SizingCoroutine(float _startSz, float _endSz)
    {
        isAnimation = true;
        Vector3 newSz = Vector3.zero;
        float t = 0f;
        while (t < 1f)
        {
            newSz = new Vector3(Mathf.Lerp(tr.localScale.x, _endSz, Time.deltaTime * sizingSpeed), Mathf.Lerp(tr.localScale.y, _endSz, Time.deltaTime * sizingSpeed), 0f);
            rt.localScale = newSz;

            t += Time.deltaTime * sizingSpeed;
            yield return null;
        }
        newSz = rt.localScale;
        newSz = new Vector3(_endSz, _endSz, 0f);
        rt.localScale = newSz;
        isAnimation = false;
    }
}
