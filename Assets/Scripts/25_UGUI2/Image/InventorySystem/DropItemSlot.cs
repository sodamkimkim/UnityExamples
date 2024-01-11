using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class DropItemSlot : MonoBehaviour
{
    private RectTransform rtr = null;
    private Image img = null;
    private readonly float magneticDist = 50f;
    private void Awake()
    {
        rtr = GetComponent<RectTransform>();
        img = GetComponent<Image>();
    }
    public void SetLocalPosition(Vector3 _pos)
    {
        rtr.localPosition = _pos;
    }
    public void SetSize(Vector2 _size)
    {
        rtr.sizeDelta = _size;
    }
    private void Update()
    {
        if (DragItem.draggingObj == null)
            return;
        float dist = Vector3.Distance(this.rtr.position, DragItem.GetDraggingObjPosition());
        if (dist < magneticDist)
            DragItem.SetDraggingObjPosition(this.rtr.position);
        DragItem.draggingObj.transform.SetParent(this.rtr);
    }

} // end of class
