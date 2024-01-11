using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBarHolder : MonoBehaviour
{
    [SerializeField]
    private RectTransform frontRt = null;
    private RectTransform rt = null;

    private float oriSizeX = 0f;

    private void Awake()
    {
        rt = GetComponent<RectTransform>();
        oriSizeX = frontRt.sizeDelta.x;
    }
    public void SetPosition(Vector3 _worldPos)
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(_worldPos);
        screenPos.y += 70f;
        rt.position = screenPos;
        //rt.position = _worldPos;
    }
    public void UpdateHpBar(int _maxHp, int _curHp)
    {
        float percent = (float)_curHp / _maxHp;
        Vector2 newSize = frontRt.sizeDelta;
        newSize.x = oriSizeX * percent;
        frontRt.sizeDelta = newSize;
    }
}
