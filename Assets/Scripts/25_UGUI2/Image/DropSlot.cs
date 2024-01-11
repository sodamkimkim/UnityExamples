using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour, IDropHandler
{
    private RectTransform rt = null;

    //private DraggingObject doInst = null;
    // 이미지 사이 거리 이정도 되면 붙도록
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
        // # singleton 객체 사용
        //if (doInst.draggingObj == null)
        //    return;
        //RectTransform doRt = doInst.draggingObj.GetComponent<RectTransform>();
        //float dist = Vector3.Distance(rt.position, doRt.position);
        //if (dist < magneticDist)
        //    doRt.position = rt.position;

        // singletone 사용 x -> static 변수 사용
        if (DragIcon.draggingObj == null)
            return;
        //RectTransform doRt = DragIcon.draggingObj.GetComponent<RectTransform>();
        float dist = Vector3.Distance(rt.position, DragIcon.GetDraggingObjPosition());
        if (dist < magneticDist)
            DragIcon.SetDraggingObjPosition(rt.position);
    }


} // end of class
