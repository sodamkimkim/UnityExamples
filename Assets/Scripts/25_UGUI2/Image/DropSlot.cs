using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour, IDropHandler
{
    private RectTransform rt = null;

    //private DraggingObject doInst = null;
    // �̹��� ���� �Ÿ� ������ �Ǹ� �ٵ���
    private readonly float magneticDist = 100f;
    private void Awake()
    {
        rt = GetComponent<RectTransform>();
        //doInst = DraggingObject.Instance;
    }
    void IDropHandler.OnDrop(PointerEventData _eventData)
    {
        Debug.Log(_eventData.pointerDrag.name);
    }
    private void Update()
    {
        // # singleton ��ü ���
        //if (doInst.draggingObj == null)
        //    return;
        //RectTransform doRt = doInst.draggingObj.GetComponent<RectTransform>();
        //float dist = Vector3.Distance(rt.position, doRt.position);
        //if (dist < magneticDist)
        //    doRt.position = rt.position;

        // singletone ��� x -> static ���� ���
        if (DragIcon.draggingObj == null)
            return;
        //RectTransform doRt = DragIcon.draggingObj.GetComponent<RectTransform>();
        float dist = Vector3.Distance(rt.position, DragIcon.GetDraggingObjPosition());
        if (dist < magneticDist)
            DragIcon.SetDraggingObjPosition(rt.position);
    }


} // end of class
