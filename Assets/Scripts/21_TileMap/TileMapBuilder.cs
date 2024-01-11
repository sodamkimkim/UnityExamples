using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapBuilder : MonoBehaviour
{

    [SerializeField]
    private Sprite[] tileImgs = null;
    [SerializeField]
    private GameObject tilePrefab = null;

 
    private List<Tile> tileList = new List<Tile>();

    public void Building(int _rowCnt, int _colCnt, int[][] _mapInfo)
    {
        float tileW = 1f;
        float tileH = 1f;
        float tileWHalf = tileW * 0.5f;
        float tileHHalf = tileH * 0.5f;

        float startPosX = ((_colCnt * tileW) * 0.5f * -1f) + tileWHalf;
        float startPosY = ((_rowCnt * tileH) * 0.5f) - tileHHalf;

        Vector3 startPos = new Vector3(startPosX, startPosY, 0f);

        for (int r = 0; r < _rowCnt; r++)
        {
            for (int c = 0; c < _colCnt; c++)
            {
                float rowOffset = r * tileH;
                float colOffset = c * tileW;
                Vector3 tilePos = new Vector3(startPos.x + colOffset, startPos.y - rowOffset, startPos.z);

                GameObject tileGo = Instantiate(tilePrefab, tilePos, Quaternion.identity);
                tileGo.transform.SetParent(transform);

                // SetSprite하기 위해서 tileGo의 Tile을 들고옴
                Tile tile = tileGo.GetComponent<Tile>();
                // mapInfo에 알맞는 tileImg를 찾아서 sprite에 던져줌
                tile.SetSprite(tileImgs[_mapInfo[r][c]]);
                // list에 추가. list 순서는 2차원 배열인 mapInfo순서랑 같아야 한다.
                tileList.Add(tile);
            }
        }
    } // end of Building()

    /*
     character의 tileIdx를 받아서 
    return tile의 position; 
    => TileMapManager에서 이 함수를 이용해서 character가 tileIdx의 tile에 해당하는 위치로 가게된다.
     */
    public Vector3 GetPosWithIdx(
        Character.TileIdx _tileIdx, int _colCnt)
    {
        // tileList에는 이중 배열 정보가 1차원으로 저장되어있다.
        // 따라서 list의 index를 (_tileIdx.y * colCnt) + _tileIdx.x로 계산해 준다.
        Tile tile = tileList[(_tileIdx.y * _colCnt) + _tileIdx.x];
        // 타일의 실제 position정보
        return tile.GetPosition();
    }

} // end of class TileMapBuilder
