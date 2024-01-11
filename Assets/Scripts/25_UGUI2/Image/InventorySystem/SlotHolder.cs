using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SlotHolder : MonoBehaviour
{
    [SerializeField]
    private GameObject itemSlotImgPrefab = null;
    [SerializeField]
    private Button btnInventory = null;

    private RectTransform rtr = null;

    public delegate void BtnClickCallbackDelegate();
    private BtnClickCallbackDelegate callback;

    private int slotTotalCnt = 12;
    private int slotColCnt = 6;
    private float slotWidth = 70;
    private float slotHeight = 70f;

    private Vector3 startPos = Vector3.zero;
    private float horizontalOffset =3f;
    private float verticalOffset = 3f;

    private List<GameObject> slotList = new List<GameObject>();

    private void Awake()
    {
        rtr = GetComponent<RectTransform>();
        btnInventory.onClick.AddListener(() =>
        {
            callback?.Invoke();
        });
    }
    private void Start()
    {
        callback = OpenInventory;
    }
    private void OpenInventory()
    {
        DestroySlots();
        for(int i = 0; i< slotTotalCnt; i++)
        {
            GameObject slot = Instantiate(itemSlotImgPrefab);
            slot.transform.SetParent(rtr);
            startPos.x = (transform.position.x - (((slotWidth + horizontalOffset) * slotHeight + horizontalOffset) / 2));
            startPos.y = transform.position.y;

            DropItemSlot itemSlot = slot.GetComponent<DropItemSlot>();
            
            // itemslot position 설정
            Vector3 slotPos = new Vector3(
                startPos.x + (horizontalOffset + slotWidth) * (i % slotColCnt),
                startPos.y - (verticalOffset + slotHeight) * (i / slotColCnt),
                0f);
            itemSlot.SetLocalPosition(slotPos);

            // itemslot size설정
            Vector2 slotSize = new Vector2(slotWidth, slotHeight);
            itemSlot.SetSize(slotSize);
            slotList.Add(slot);

        }
        transform.localPosition = new Vector3(1804f, -190f, 0f);
    }
    private void DestroySlots()
    {
        if (slotList == null) return;
        foreach (GameObject slot in slotList)
            Destroy(slot);
        slotList.Clear();
        transform.localPosition = new Vector3(313f, 0f, 0f);
    }


}
