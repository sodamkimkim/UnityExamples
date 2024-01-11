using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragIcon : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler
{
    private RectTransform rt = null;
    // drag�̹����� Ŭ���� point�� ��ġ�� �������ֱ� ���� offset����
    private Vector3 offset = Vector3.zero;
    private Image img = null;

    // ��ü ���������� �޸� ���� �ϳ��̹Ƿ� �ڵ����� �����ϰ� �ϳ��� �����ϰ� �ȴ�.
    // �� �̱��� ������ ������� �ʾƵ� static ������ Ȱ���ϸ� �ȴ�.
    static public GameObject draggingObj = null;
    private void Awake()
    {
        rt = GetComponent<RectTransform>();
        img = GetComponent<Image>();
        // singleton ��ü ���� / �������
        //GameObject do1 = DraggingObject.Instance.draggingObj;
        //DraggingObject do2 = new DraggingObject();
    }
    void IBeginDragHandler.OnBeginDrag(PointerEventData _eventData)
    {
        // (�̹��� ��ġ - ���� Ŀ�� ��ġ) �ؾ� (���� Ŀ�� ��ġ -> �̹��� ��ġ)
        // �� ���ϴ� ���Ͱ� ��������.
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
