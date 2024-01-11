using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Image img = null;
    private RectTransform rtr = null;

    private Vector3 offset = Vector3.zero;
    static public GameObject draggingObj = null;

    private Transform parentRtr = null;

    private void Awake()
    {
        img = GetComponent<Image>();
        rtr = GetComponent<RectTransform>();
       
    }
    public void SetImgSprite(Sprite _imgSprite)
    {
        img.sprite = _imgSprite;
    }
    public void SetLocalPosition(Vector3 _localPos)
    {
        rtr.localPosition = _localPos;
    }
    public void SetSize(Vector2 _size)
    {
        rtr.sizeDelta = _size;
    }

    // EventSystem
    void IBeginDragHandler.OnBeginDrag(PointerEventData _eventData)
    {
        offset = (Vector2)rtr.position - _eventData.position;
        img.raycastTarget = false;
        draggingObj = gameObject;
    }

    void IDragHandler.OnDrag(PointerEventData _eventData)
    {
        rtr.position = _eventData.position + (Vector2)offset;
        transform.SetParent(parentRtr);
    }

    void IEndDragHandler.OnEndDrag(PointerEventData _eventData)
    {
        img.raycastTarget = true;
        draggingObj = null;
    }
    public static Vector3 GetDraggingObjPosition()
    {
        return draggingObj.transform.position;
    }
    public static void SetDraggingObjPosition(Vector3 _pos)
    {
        draggingObj.transform.position = _pos;
    }
    public void SetParentTr(Transform _parentRtr)
    {
        parentRtr = _parentRtr;
    }
} // end of class
