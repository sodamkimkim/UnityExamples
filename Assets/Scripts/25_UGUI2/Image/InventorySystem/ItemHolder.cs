using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemHolder : MonoBehaviour
{
    [SerializeField]
    private GameObject itemImgPrefab = null;
    [SerializeField]
    private Button BtnShowItems = null;
    public delegate void BtnClickCallbackDelegate();
    private BtnClickCallbackDelegate callback;

    private Sprite[] iconImgs = null;
    private int itemTotalCnt = 0;
    private int itemColCnt = 5;
    private float itemWidth = 50f;
    private float itemHeigtht = 50f;

    private Vector3 startPos = Vector3.zero;
    private float horizontalOffset = 2f;
    private float verticalOffset = 2f;

    private List<GameObject> itemList = new List<GameObject>();

    private RectTransform rtr = null;

    //public enum EMenuImgs
    //{
    //    A_ODeng, B_MulTeock, C_GonYack, D_YUBUPoket, E_TeockBokki,
    //    F_AssortedTempura, G_ChiliTempura, H_PenFriedDumpling, i_BuchuJeon, J_BinDaeJeon,
    //    K_BibimDangMyeon, L_PartyNoodle, M_UDong, N_BibimNoodle,
    //    O_MulMilMyeon, P_BibimMilMyeon, Q_KimBap, R_YUBUChoBap,
    //    S_SickHye, T_Beverages, len
    //};

    private void Awake()
    {
        BtnShowItems.onClick.AddListener(() => {
            callback?.Invoke();
        });
        iconImgs = Resources.LoadAll<Sprite>("Sprites\\UI_Menus\\UI_Menu");
        itemTotalCnt = iconImgs.Length;
        rtr = GetComponent<RectTransform>();
    }
    private void Start()
    {
        callback = OpenItems;
    }
    private void OpenItems()
    {
        DestroyImgs();
        for (int i= 0; i< itemTotalCnt; i++)
        {
            // itemImg 생성
            GameObject ItemImg = Instantiate(itemImgPrefab);
            ItemImg.transform.SetParent(transform);
            startPos.x = (transform.position.x - (((itemWidth + horizontalOffset) * itemColCnt + horizontalOffset) / 2));
            startPos.y = transform.position.y;
            // item에 해당하는 이미지 넣어주기
            DragItem item = ItemImg.GetComponent<DragItem>();
            item.SetImgSprite(iconImgs[i]);
            item.SetParentTr(rtr);

            // icon img position 설정
            Vector3 imgPos = new Vector3(
                startPos.x + (horizontalOffset + itemWidth)*(i %itemColCnt),
                startPos.y - (verticalOffset + itemHeigtht)*(i/itemColCnt),
                0f);
            item.SetLocalPosition(imgPos);

            // icon img size 설정
            Vector2 imgSize = new Vector2(itemWidth, itemHeigtht);
            item.SetSize(imgSize);
            itemList.Add(ItemImg);
        }
        // 부모 포지션 셋팅
            transform.localPosition = new Vector3(-510f, -219f, 0f);
    }
    private void DestroyImgs()
    {
        if (itemList == null) return;
        foreach (GameObject img in itemList)
            Destroy(img);
        itemList.Clear();
        transform.localPosition = new Vector3(-270f, 55f, 0f);
    }


}
