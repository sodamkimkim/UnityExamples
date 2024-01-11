using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public struct TileIdx
    {
        public int x, y;
        public TileIdx(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
    } // end of struct TileIdx
    private TileIdx tileIdx = new TileIdx(0,0);


    public void MoveUp()
    {
        --tileIdx.y;
    } // end of MoveUp()
    public void MoveDown()
    {
        ++tileIdx.y;
    }

    public void MoveLeft()
    {
        --tileIdx.x;
    }

    public void MoveRight()
    {
        ++tileIdx.x;
    }

    public TileIdx GetCurIndex()
    {
        return tileIdx;
    }

    // Builder로 부터 타일의 위치 정보를 받아서 그 position으로 player옮겨주는 함수
    public void SetPosition(Vector3 _pos)
    {
        _pos.z = -1f;
        transform.position = _pos;
        
    }

} // end of class Character
