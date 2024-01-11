using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragIcon : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler
{
    private RectTransform rt = null;
    // drag이미지랑 클릭한 point의 위치를 보정해주기 위한 offset변수
    private Vector3 offset = Vector3.zero;
    private Image img = null;

    // 객체 여러개여도 메모리 변수 하나이므로 자동으로 유일하게 하나만 저장하게 된다.
    // 즉 싱글톤 패턴을 사용하지 않아도 static 변수를 활용하면 된다.
    static public GameObject draggingObj = null;
    private void Awake()
    {
        rt = GetComponent<RectTransform>();
        img = GetComponent<Image>();
        // singleton 객체 생성 / 갖고오기
        //GameObject do1 = DraggingObject.Instance.draggingObj;
        //DraggingObject do2 = new DraggingObject();
    }
    void IBeginDragHandler.OnBeginDrag(PointerEventData _eventData)
    {
        // (이미지 위치 - 현재 커서 위치) 해야 (현재 커서 위치 -> 이미지 위치)
        // 를 향하는 벡터가 구해진다.
        //offset = rt.position - new Vector3(_eventData.position.x, _eventData.position.y);
        offset = (Vector2)rt.position - _eventData.position;
        img.raycastTarget = false;
        //DraggingObject.Instance.draggingObj= gameObject;
        draggingObj = gameObject;
    }

    public void OnDrag(PointerEventData _eventData)
    {
        rt.position = _eventData.position+(Vector2)offset;
        
    }
    void IEndDragHandler.OnEndDrag(PointerEventData _eventData)
    {
        img.raycastTarget = true;
        //DraggingObject.Instance.draggingObj = null;
        draggingObj = null;
    }
    public void OnPointerEnter(PointerEventData _eventData)
    {
        Debug.Log("On Pointer Enter");
    }
    
    public static Vector3 GetDraggingObjPosition()
    {
        return draggingObj.transform.position;
    }
    public static void SetDraggingObjPosition(Vector3 _pos)
    {
        draggingObj.transform.position = _pos;
    }

} // end of class
