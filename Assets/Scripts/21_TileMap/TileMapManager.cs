using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapManager : MonoBehaviour
{
    public enum EType { Grass, Road, Sea, Stone };
    [SerializeField]
    private TileMapBuilder mapBuilder = null;
    [SerializeField]
    private Character character = null;

    // �ܺ� ���� �ε��ؼ� ������ ä�� ����
    private int rowCnt = 0;
    private int colCnt = 0;
    private int[][] mapInfo = null;
    //private int rowCnt = 5;
    //private int colCnt = 5;

    //// 0 : grass, 1 : road, 2 : Sea, 3 : Stone


    ///* Ÿ�� ��ġ info
    // * # C#���� ���߹迭 �����ϴ� 2���� ���
    // * private int [ ] [ ]  or int[,]
    // */
    //private int[][] mapInfo = new int[5][]
    //{
    //     new int[5]{ 1,0,0,2,2 },
    //     new int[5] { 1,1,0,2,2 },
    //     new int[5]{ 0,1,1,0,2 },
    //     new int[5]{ 3,0,1,1,0 },
    //     new int[5]{ 3,3,0,1,1 }
    //};
    /*
     1. �� ����
     2. Character �ʱ���ġ ���� 
     */
    private void Start()
    {
        FileManager fm = new FileManager();
        // �츮 ���ӿ��� �� .mapȮ���ڷ� ����
        //fm.Save("Stage.map", rowCnt, colCnt, mapInfo);
        fm.Load("Stage.map", out rowCnt, out colCnt, out mapInfo);

        if (rowCnt != 0 && colCnt != 0)
            mapBuilder.Building(rowCnt, colCnt, mapInfo);

        // private TileIdx tileIdx = new TileIdx(0, 0);
        // character�� �ʱ� �ε��� ������ ������ tile�� index�� �����ؼ� tile�� position���� character�� �Ű� ��
        UpdateCharPos();
    }
    /*
     : Ű �̺�Ʈ �������ִ� �ڵ� �ۼ�
    1. ĳ������ ���� ��ġ tileIdx�޾ƿͼ�
    2. �� ���� ++ / -- ���� �ε����� ����� ����
    3. �� �ε����� �ش��ϴ� tile�� move�������� üũ�ϰ� �����ϸ�
    4. ������ character�� tileIdx�� ������Ʈ ���ְ�
    5. character�� �� Ÿ�� ��ġ��(position)�̵�
   */
    private void Update()
    {
        // ������ �̵�
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Character.TileIdx curIdx = character.GetCurIndex();
            curIdx.x += 1;
            // ���� �ִ� ������ üũ
            if (CheckCanMove(curIdx))
            {
                // 'character index ����ü ����(TileIdx)' update
                character.MoveRight();
                // ���� index�� ������� '���� character position' Update
                UpdateCharPos();
            }
        }

        // ���� �̵�
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Character.TileIdx curIdx = character.GetCurIndex();
            curIdx.x -= 1;
            if (CheckCanMove(curIdx))
            {
                character.MoveLeft();
                UpdateCharPos();
            }
        }

        // ���� �̵�
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Character.TileIdx curIdx = character.GetCurIndex();
            curIdx.y -= 1;
            if (CheckCanMove(curIdx))
            {
                character.MoveUp();
                UpdateCharPos();
            }
        }

        // �Ʒ��� �̵�
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Character.TileIdx curIdx = character.GetCurIndex();
            curIdx.y += 1;
            if (CheckCanMove(curIdx))
            {
                character.MoveDown();
                UpdateCharPos();
            }
        }
    }

    /*
     * ���) �ʿ� ĳ���� ���� ��ġ ����, �������ִ� �Լ�
     Update()���� Ű �Է� ���� Character���� Move�Լ��� ȣ���Ѵ�.
    Move�Լ����� tileIdx�� ��ȭ�� �Ͼ��, 
    �� tileIdx�� �޾ƿͼ� tile�� ���� position�� ���Ѵ���
    �� ��ġ�� Character�� �̵��Ѵ�.
    �� TileMapManager�� Character�� TileMapBuilder�� ���ͼ� �׷��ִ� Ŭ���� �̱� ������
    �� ������ �� ��ü�� ������ �ʿ信 ���� ���� Ȥ�� �޾ƿͼ�
    �� ��ü�� ������ �ִ� ���̴�.
     */
    private void UpdateCharPos()
    {
        Character.TileIdx tileIdx = character.GetCurIndex();
        Vector3 tilePos = mapBuilder.GetPosWithIdx(tileIdx, colCnt);
        character.SetPosition(tilePos);

    }
    // Player�� �̵��� �� �ִ� Map���� Ȯ���ϴ� �Լ�
    public bool CheckCanMove(Character.TileIdx _tileIdx)
    {
        // �� ���� ����� ������.
        if (_tileIdx.x < 0 || _tileIdx.x > colCnt - 1)
            return false;
        if (_tileIdx.y < 0 || _tileIdx.y > rowCnt - 1)
            return false;
        // tille�� �ε��� ���ͼ� Sea or Stone�̸� ������.
        int tileInfo = mapInfo[_tileIdx.y][_tileIdx.x];
        if (tileInfo == (int)EType.Sea || tileInfo == (int)EType.Stone)
            return false;

        return true;
    }
} // end of class TileMapManager
