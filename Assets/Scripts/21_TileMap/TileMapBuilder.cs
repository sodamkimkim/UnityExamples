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

                // SetSprite�ϱ� ���ؼ� tileGo�� Tile�� ����
                Tile tile = tileGo.GetComponent<Tile>();
                // mapInfo�� �˸´� tileImg�� ã�Ƽ� sprite�� ������
                tile.SetSprite(tileImgs[_mapInfo[r][c]]);
                // list�� �߰�. list ������ 2���� �迭�� mapInfo������ ���ƾ� �Ѵ�.
                tileList.Add(tile);
            }
        }
    } // end of Building()

    /*
     character�� tileIdx�� �޾Ƽ� 
    return tile�� position; 
    => TileMapManager���� �� �Լ��� �̿��ؼ� character�� tileIdx�� tile�� �ش��ϴ� ��ġ�� ���Եȴ�.
     */
    public Vector3 GetPosWithIdx(
        Character.TileIdx _tileIdx, int _colCnt)
    {
        // tileList���� ���� �迭 ������ 1�������� ����Ǿ��ִ�.
        // ���� list�� index�� (_tileIdx.y * colCnt) + _tileIdx.x�� ����� �ش�.
        Tile tile = tileList[(_tileIdx.y * _colCnt) + _tileIdx.x];
        // Ÿ���� ���� position����
        return tile.GetPosition();
    }

} // end of class TileMapBuilder
