using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class pr_PathFinding : MonoBehaviour
{
    [SerializeField]
    private Flag startFlag = null;
    [SerializeField]
    private Flag endFlag = null;
    private Flag[] flags = null;

    public List<List<Flag>> pathList = new List<List<Flag>>();

    private void Awake()
    {
        flags = GetComponentsInChildren<Flag>();
    }
    private void Start()
    {
        startFlag.SetScale(2f);
        endFlag.SetScale(2f);
    }
    private void Searching()
    {
        List<Flag> path = new List<Flag>();
        SearchingRecursive(path, startFlag);
        for(int i = 0; i < pathList.Count; ++i )
        {
            // endFlag를 가지고 있지 않은 List<Flag> path는 pathList에서 지운다.
            if(!pathList[i].Contains(endFlag))
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
        if(_curFlag == endFlag || _curFlag.IsNextEmpty())
        {
            List<Flag> tmp = new List<Flag>(_path);
            pathList.Add(tmp);
            return;
        }
        foreach(Flag nextFlag in _curFlag.GetNextFlags())
        {
            SearchingRecursive(_path, nextFlag);
            _path.RemoveAt(_path.Count - 1);

        }
    }
    public void PrintPathList()
    {
        StringBuilder sb = new StringBuilder();
        foreach(List<Flag> path in pathList)
        {
            sb.Clear();
            foreach(Flag flag in path)
            {
                sb.Append(flag.name);
                sb.Append(" - ");

                if (flag == endFlag)
                    sb.Append(" OK ");
            }
            Debug.Log(sb.ToString());
        }
    }
    public Flag[] GetShortPath()
    {
        float[] distList = new float[pathList.Count];
        for(int i = 0; i<pathList.Count; ++i)
        {
            List<Flag> path = pathList[i];
            float elapsedDist = 0f;
            for(int j = 0; j<path.Count-1; ++j)
            {
                Vector3 firstPos = path[j].GetPosition();
                Vector3 secondPos = path[j + 1].GetPosition();
                elapsedDist += Vector3.Distance(firstPos, secondPos);
            }
            distList[i] = elapsedDist;
        }

        int minIdx = 0;
        for(int i = 1; i<distList.Length; i++)
        {
            if (distList[i] < distList[minIdx])
                minIdx = i;
        }
        return pathList[minIdx].ToArray();
    }
} // end of class PathFinding
