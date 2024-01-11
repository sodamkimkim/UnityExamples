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

    // 외부 파일 로드해서 정보를 채울 예정
    private int rowCnt = 0;
    private int colCnt = 0;
    private int[][] mapInfo = null;
    //private int rowCnt = 5;
    //private int colCnt = 5;

    //// 0 : grass, 1 : road, 2 : Sea, 3 : Stone


    ///* 타일 배치 info
    // * # C#에서 이중배열 선언하는 2가지 방식
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
     1. 맵 생성
     2. Character 초기위치 지정 
     */
    private void Start()
    {
        FileManager fm = new FileManager();
        // 우리 게임에서 쓸 .map확장자로 저장
        //fm.Save("Stage.map", rowCnt, colCnt, mapInfo);
        fm.Load("Stage.map", out rowCnt, out colCnt, out mapInfo);

        if (rowCnt != 0 && colCnt != 0)
            mapBuilder.Building(rowCnt, colCnt, mapInfo);

        // private TileIdx tileIdx = new TileIdx(0, 0);
        // character의 초기 인덱스 정보를 가지고 tile의 index랑 맵핑해서 tile의 position으로 character를 옮겨 줌
        UpdateCharPos();
    }
    /*
     : 키 이벤트 감지해주는 코드 작성
    1. 캐릭터의 현재 위치 tileIdx받아와서
    2. 그 값에 ++ / -- 해준 인덱스를 계산해 보고
    3. 그 인덱스에 해당하는 tile에 move가능한지 체크하고 가능하면
    4. 실제로 character의 tileIdx를 업데이트 해주고
    5. character를 그 타일 위치로(position)이동
   */
    private void Update()
    {
        // 오른쪽 이동
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Character.TileIdx curIdx = character.GetCurIndex();
            curIdx.x += 1;
            // 갈수 있는 맵인지 체크
            if (CheckCanMove(curIdx))
            {
                // 'character index 구조체 정보(TileIdx)' update
                character.MoveRight();
                // 위의 index를 기반으로 '실제 character position' Update
                UpdateCharPos();
            }
        }

        // 왼쪽 이동
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

        // 위로 이동
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

        // 아래로 이동
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
     * 요약) 맵에 캐릭터 실제 위치 조정, 연동해주는 함수
     Update()에서 키 입력 마다 Character에서 Move함수를 호출한다.
    Move함수에서 tileIdx의 변화가 일어나고, 
    그 tileIdx를 받아와서 tile의 실제 position을 구한다음
    그 위치로 Character를 이동한다.
    ㄴ TileMapManager가 Character와 TileMapBuilder를 들고와서 그려주는 클래스 이기 때문에
    이 곳에서 두 객체의 정보를 필요에 따라 수정 혹은 받아와서
    두 객체를 연동해 주는 것이다.
     */
    private void UpdateCharPos()
    {
        Character.TileIdx tileIdx = character.GetCurIndex();
        Vector3 tilePos = mapBuilder.GetPosWithIdx(tileIdx, colCnt);
        character.SetPosition(tilePos);

    }
    // Player가 이동할 수 있는 Map인지 확인하는 함수
    public bool CheckCanMove(Character.TileIdx _tileIdx)
    {
        // 맵 범위 벗어나면 못간다.
        if (_tileIdx.x < 0 || _tileIdx.x > colCnt - 1)
            return false;
        if (_tileIdx.y < 0 || _tileIdx.y > rowCnt - 1)
            return false;
        // tille의 인덱스 들고와서 Sea or Stone이면 못들어간다.
        int tileInfo = mapInfo[_tileIdx.y][_tileIdx.x];
        if (tileInfo == (int)EType.Sea || tileInfo == (int)EType.Stone)
            return false;

        return true;
    }
} // end of class TileMapManager
