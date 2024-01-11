using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour
{
    [SerializeField]
    private Flag startFlag = null;
    [SerializeField]
    private Flag endFlag = null;

    private Flag[] flags = null;

    public List<List<Flag>> pathList =
            new List<List<Flag>>();

    private void Awake()
    {
        /*
        - Flags오브젝트의 자식들로 넣어준 1, 4, 2, 3, 6, 5 flag에서 Flag스크립트를 들고온다.
        - Flags오브젝트에는 Flag스크립트가 없기 때문에 [0]에는 1의 Flag 스크립트가 들어가게 된다.
         */
        flags = GetComponentsInChildren<Flag>();
    }

    private void Start()
    {
        startFlag.SetScale(2f);
        endFlag.SetScale(2f);
    }
    public void Searching()
    {
        List<Flag> path = new List<Flag>();
        SearchingRecursive(path, startFlag);

        /* SearchingRecursive에서 startFlag를 매개변수로 넣었는데 이것이 return 되었다는 말은,
         * 모든 path를 다 검사했다는 뜻이다.
         * (왜냐하면 start의 next의 next들을 recursive로 전부 방문하기 때문)
         * SearchingRecursive에서 pathList를 구성해 주므로
         * SearchingRecursive(path, startFlag); 이 코드 이후의 pathList에는 모든 path가 들어가 있다.
         * (ㄴ 여기서 모든 path는 1 ~> 4이거나, 더이상 nextNode가 없는 노드까지 간 path를 말한다.)
         * 
         * <endFlag까지 갈 수 있는 경로만 남기는 for문>
         * 이 for문에 의해 path( 1 - 2 - 5 )는 pathlist에서 사라진다.
         */
        for (int i = 0; i < pathList.Count; ++i)
        {
            // endFlag를 가지고 있지 않은 List<Flag> path는 pathList에서 지운다.
            if (!pathList[i].Contains(endFlag))
            {
                pathList.RemoveAt(i);
                // for문 i는 증가하는데,  이 if문에 들어와서 path를 하나 remove해 줬으면 --i해 줘야 한다.
                --i;
            }
        }
    }

    private void SearchingRecursive(List<Flag> _path, Flag _curFlag)
    {
        _path.Add(_curFlag);
        Debug.Log("_path.Add : " + _curFlag.ToString());
        if (_curFlag == endFlag || _curFlag.IsNextEmpty())
        {
            // _path 복사
            List<Flag> tmp = new List<Flag>(_path);
            pathList.Add(tmp);
           foreach( List<Flag> path in pathList)
            {
                Debug.Log("=======================================");
                foreach(Flag pathflag in path)
                {

                Debug.Log("pathflag in pathlist : " + pathflag);
                }
                Debug.Log("=======================================");
            }
            return;
        }

        /*
         *  _curFlag의 next flags를 검사
         */ 
        foreach (Flag nextFlag in _curFlag.GetNextFlags())
        {
            Debug.Log("nextFlag: " + nextFlag + "to _path : " + _path.ToString());
            SearchingRecursive(_path, nextFlag);
            Debug.Log("_path.Remove : " + _path[_path.Count-1] +" at : "+(_path.Count - 1));
            /*
             * next가 없거나 endflag는 path에 지워 줘서,
             * 그 앞번째 노드의 next를 add하여 검사할 수 있게 한다.
             */
            _path.RemoveAt(_path.Count - 1);
        }
    }
    public void PrintPathList()
    {
        System.Text.StringBuilder sb =
            new System.Text.StringBuilder();

        foreach(List<Flag> path in pathList)
        {
            sb.Clear();
            foreach (Flag flag in path)
            {
                sb.Append(flag.name);
                sb.Append(" - ");

                // 끝 플래그까지 갔다면 가능한 경로
                if (flag == endFlag)
                    sb.Append("OK!");
            }
            Debug.Log(sb.ToString());
        }
    }

    public Flag[] GetShortPath()
    {
        // distList는 각 path의 flag사이 거리를 구해서 배열로 저장해 둔 것.
        float[] distList = new float[pathList.Count];
        for (int i = 0; i < pathList.Count; ++i)
        {
            List<Flag> path = pathList[i];
            float elapsedDist = 0f;
            /*
             * path의 Flag의 position사이 거리계산해서 elapsedDist에 누적해 주는 for문
             * ㄴ j == Count-2일때 까지 돌고, [Count-2]  [Count-1] 에 해당하는 flag까지 (즉 path의 끝노드까지)
             * ㄴ 거리값 누적 계산한다.
             * */
            for (int j = 0; j < path.Count - 1; ++j)
            {
                Vector3 firstPos = path[j].GetPosition();
                Vector3 secondPos = path[j + 1].GetPosition();
                elapsedDist +=
                    Vector3.Distance(firstPos, secondPos);
            }
          
            distList[i] = elapsedDist;
            //Debug.Log("distLize[" + i + "]: " + distList[i]);
        }

        // 최소 elapsedDist가진 인덱스 찾기(minIdx)
        int minIdx = 0;
        for (int i = 1; i < distList.Length; ++i)
        {
            if (distList[i] < distList[minIdx])
                minIdx = i;
        }

        return pathList[minIdx].ToArray();
    }
} // end of class PathFinding
