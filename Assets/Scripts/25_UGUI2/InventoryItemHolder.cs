using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemHolder : MonoBehaviour
{
    private RectTransform rtr = null;
    private Sprite[] iconImgs = null;
    private int itemTotalCnt = 0;
    private int itemColCnt = 3;

    private float itemWidth = 30f;
    private float itemHeight = 30f;

    private Vector3 startPos = Vector3.zero;
    private float horizontalOffset = 2f;
    private float verticalOffset = 2f;

    private List<GameObject> itemList = new List<GameObject>();

    private void Awake()
    {
        //Build
    }
    private void BuildItems()
    {

    }
} // end of class
