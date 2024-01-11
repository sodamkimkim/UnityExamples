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

    // Builder�� ���� Ÿ���� ��ġ ������ �޾Ƽ� �� position���� player�Ű��ִ� �Լ�
    public void SetPosition(Vector3 _pos)
    {
        _pos.z = -1f;
        transform.position = _pos;
        
    }

} // end of class Character
